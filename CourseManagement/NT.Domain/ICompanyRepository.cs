using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.Companies;
using NT.CM.Domain.CompanyAgg;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface ICompanyRepository : IRepository<long, Company>
    {
        List<CompanyViewModel> Search(CompanyViewModel command = null);
    }
}
