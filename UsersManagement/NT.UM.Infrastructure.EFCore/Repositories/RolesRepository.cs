using _01.Framework.Infrastructure.EFCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class RolesRepository : BaseRepository<long, Roles> , IRolesRepository
    {
        private readonly NTUMContext _ntumcontext;
        public RolesRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }

        public List<RolesViewModel> Search(RolesViewModel command = null)
        {
            var Query = _ntumcontext.Tbl_Roles.Where(x => x.Status == true).Select(x => new RolesViewModel
            {
                ID = x.ID,
                RoleName = x.RoleName,
                Description=x.Description,
                Status = x.Status
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.RoleName))
                    Query = Query.Where(x => x.RoleName.Contains(command.RoleName));
            }
            return Query.ToList();
        }
    }
}
