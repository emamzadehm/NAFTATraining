using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_EvaluationResultApplication
    {
        OperationResult Create(Site_EvaluationResultViewModel command);
        OperationResult Edit(Site_EvaluationResultViewModel command);
        OperationResult Remove(long id);
        Site_EvaluationResultViewModel GetBy(long id);
        List<Site_EvaluationResultViewModel> Search(Site_EvaluationResultViewModel command = null);
    }
}
