using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.Candidates;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts
{
    public interface ICandidateApplication
    {
        OperationResult Create(CandidateViewModel command);
        OperationResult Edit(CandidateViewModel command);
        OperationResult Remove(long id);
        CandidateViewModel GetDetails(long id);
        List<CandidateViewModel> Search(CandidateViewModel searchmodel = null);
    }
}
