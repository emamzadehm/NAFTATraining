using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_FunFactRepository : BaseRepository<long, Site_FunFact>, ISite_FunFactRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_FunFactRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_FunFactViewModel> Search(Site_FunFactViewModel command)
        {
            var Query = _smcontext.Tbl_Site_FunFact.Where(x => x.Status == true).Select(x => new Site_FunFactViewModel
            {
                Id = x.ID,
                Title = x.Title,
                ValueNumber = x.ValueNumber
            });

            return Query.ToList();
        }
    }
}
