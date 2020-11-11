using _01.Framework.Domain;
using NT.CM.Application.Contracts;
using NT.CM.Domain.CandidateAgg;
using System;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface ICandidateRepository : IRepository<long, Candidate>
    {
        List<CandidateViewModel> Search(CandidateViewModel command);
    }
}
