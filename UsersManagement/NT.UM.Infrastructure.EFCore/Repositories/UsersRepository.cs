using _01.Framework.Application;
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

        public void Save()
        {
            _ntumcontext.SaveChanges();
        }

        public List<UsersViewModel> Search(UsersViewModel command = null)
        {
            var Query = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new UsersViewModel
            {
                ID = x.ID,
                FirstName=x.FirstName,
                LastName=x.LastName,
                Email=x.Email,
                IDCardIMGFileAddress = x.IDCardIMG,
                IMGFileAddress = x.IMG,
                Sex=x.Sex,
                Tel=x.Tel,
                Fullname=x.Sex.ToSexName() + " " + x.FirstName + " " + x.LastName,
                UserStatus = x.Status
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Fullname))
                    Query = Query.Where(x => x.Fullname.Contains(command.Fullname));
            }
           

            return Query.ToList();
        }
    }
}
