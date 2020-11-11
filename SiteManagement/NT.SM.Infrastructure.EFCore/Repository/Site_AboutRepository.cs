using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_AboutRepository : BaseRepository<long, Site_About>, ISite_AboutRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_AboutRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_AboutViewModel> Search(Site_AboutViewModel command)
        {
            var Query = _smcontext.Tbl_Site_About.Where(x => x.Status == true).Select(x => new Site_AboutViewModel
            {
                Id = x.ID,
                Title = x.Title,
                Description = x.Description,
                Site_Base_Id = x.Site_Base_Id

            });
            if (!string.IsNullOrWhiteSpace(command.Description))
                Query = Query.Where(x => x.Description.Contains(command.Description));
            return Query.ToList();
        }
    }
}
