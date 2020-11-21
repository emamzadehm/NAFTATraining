using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_FAQRepository : BaseRepository<long, Site_FAQ>, ISite_FAQRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_FAQRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_FAQViewModel> Search(Site_FAQViewModel command=null)
        {
            var Query = _smcontext.Tbl_Site_FAQ.Where(x => x.Status == true).Select(x => new Site_FAQViewModel
            {
                Id = x.ID,
                Question = x.Question,
                Answer = x.Answer
            });

            return Query.ToList();
        }
    }
}
