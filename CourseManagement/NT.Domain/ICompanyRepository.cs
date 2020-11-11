using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels;
using NT.CM.Domain.CompanyAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Domain
{
    public interface ICompanyRepository : IRepository<long, Company>
    {
        List<CompanyViewModel> Search(CompanyViewModel command);
    }
}
