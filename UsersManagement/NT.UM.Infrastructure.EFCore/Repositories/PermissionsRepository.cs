using _01.Framework.Infrastructure.EFCore;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class PermissionsRepository : BaseRepository<long, Permissions> , IPermissionsRepository
    {
        private readonly NTUMContext _ntumcontext;
        public PermissionsRepository(NTUMContext ntumcontext) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
        }


        public List<PermissionsViewModel> Search(PermissionsViewModel command = null)
        {
            var Query = _ntumcontext.Tbl_Permissions.Where(x => x.Status == true).Select(x => new PermissionsViewModel
            {
                ID = x.ID,
                Title=x.Title,
                Status = x.Status
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Title))
                    Query = Query.Where(x => x.Title.Contains(command.Title));
            }
            

            return Query.ToList();
        }
    }
}
