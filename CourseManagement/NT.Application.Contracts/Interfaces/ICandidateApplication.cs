using _01.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts
{
    public interface ICandidateApplication
    {
        OperationResult Create(CandidateViewModel command);
        OperationResult Edit(CandidateViewModel command);
        OperationResult Remove(long id);
        CandidateViewModel GetBy(long id);
        List<CandidateViewModel> Search(CandidateViewModel searchmodel);
    }
}
