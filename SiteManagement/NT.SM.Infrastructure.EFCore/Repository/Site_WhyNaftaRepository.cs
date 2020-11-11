using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_WhyNaftaRepository : BaseRepository<long, Site_WhyNafta>, ISite_WhyNaftaRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_WhyNaftaRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_WhyNaftaViewModel> Search(Site_WhyNaftaViewModel command)
        {
            var Query = _smcontext.Tbl_Site_WhyNafta.Where(x => x.Status == true).Select(x => new Site_WhyNaftaViewModel
            {
                Id = x.ID,
                Description = x.Description,
                Site_Base_Id = x.Site_Base_Id
            });
            if (!string.IsNullOrWhiteSpace(command.Description))
                Query = Query.Where(x => x.Description.Contains(command.Description));

            return Query.ToList();
        }
    }
}
