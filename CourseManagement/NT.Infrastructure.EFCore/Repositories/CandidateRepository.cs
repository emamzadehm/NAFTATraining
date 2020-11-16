using _01.Framework.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Domain;
using NT.CM.Domain.CandidateAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CandidateRepository : BaseRepository<long, Candidate>,ICandidateRepository
    {

        private readonly NTContext _ntcontext;
        public CandidateRepository(NTContext context) : base(context)
        {
            _ntcontext = context;
        }

        public List<CandidateViewModel> Search(CandidateViewModel command)
        {

            var Query = _ntcontext.Tbl_Candidate.Include(x => x.BaseInfo).Include(x => x.Company)
                .Where(x => x.Status == true).Select(x => new CandidateViewModel
                {
                    ID = x.ID,
                    CityOfBirth = x.CityOfBirth,
                    CompanyID = x.CompanyID,
                    DOB = x.DOB,
                    NationalityID = x.NationalityID,
                    NationalityName = x.BaseInfo.Title,
                    CompanyName = x.Company.CompanyName,
                    NID = x.NID
                });
                
                if (!string.IsNullOrWhiteSpace(command.NID))
                    Query = Query.Where(x=>x.NID.Contains(command.NID));
            return Query.ToList();
        }
    }
}
