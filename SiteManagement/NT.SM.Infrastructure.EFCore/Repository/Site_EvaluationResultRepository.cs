using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_EvaluationResultRepository : BaseRepository<long, Site_EvaluationResult>, ISite_EvaluationResultRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_EvaluationResultRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_EvaluationResultViewModel> Search(Site_EvaluationResultViewModel command=null)
        {
            var Query = _smcontext.Tbl_Site_EvaluationResult.Where(x => x.Status == true).Select(x => new Site_EvaluationResultViewModel
            {
                Id = x.ID,
                Title = x.Title,
                Percentage = x.Percentage
            });

            return Query.ToList();
        }
    }
}
