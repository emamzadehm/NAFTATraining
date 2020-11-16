using _01.Framework.Infrastructure.EFCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class UsersRepository : BaseRepository<long,Users> , IUsersRepository
    {
        private readonly NTUMContext _ntumcontext;
        public UsersRepository(NTUMContext ntumcontext) :base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }

        public List<UsersViewModel> Search(UsersViewModel command)
        {
            var Query = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new UsersViewModel
            {
                ID = x.ID,
                FirstName=x.FirstName,
                LastName=x.LastName,
                Email=x.Email,
                IDCardIMG=x.IDCardIMG,
                IMG=x.IMG,
                Sex=x.Sex,
                Tel=x.Tel,
                Fullname=x.FirstName + " " + x.LastName,
                UserStatus = x.Status
            });
            if (!string.IsNullOrWhiteSpace(command.Fullname))
                Query = Query.Where(x => x.Fullname.Contains(command.Fullname));

            return Query.ToList();
        }
    }
}
