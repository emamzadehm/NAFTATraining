using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.Companies;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.Interfaces
{
    public interface ICompanyApplication
    {
        OperationResult Create(CompanyViewModel command);
        OperationResult Edit(CompanyViewModel command);
        OperationResult Remove(long id);
        CompanyViewModel GetBy(long id);
        List<CompanyViewModel> Search(CompanyViewModel searchmodel = null);
    }
}
