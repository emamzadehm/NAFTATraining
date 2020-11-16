using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using NT.CM.Domain.CandidateAgg;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface ICandidateRepository : IRepository<long, Candidate>
    {
        List<CandidateViewModel> Search(CandidateViewModel command);
    }
}
