using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_BaseRepository : BaseRepository<long, Site_Base>, ISite_BaseRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_BaseRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_BaseViewModel> Search(Site_BaseViewModel command)
        {
            var Query = _smcontext.Tbl_Site_Base.Where(x => x.Status == true).Select(x => new Site_BaseViewModel
            {
                Id = x.ID,
                MainTitle = x.MainTitle,
                MainDescription = x.MainDescription
            });
            if (!string.IsNullOrWhiteSpace(command.MainDescription))
                Query = Query.Where(x => x.MainDescription.Contains(command.MainDescription));
            return Query.ToList();
        }
    }
}
