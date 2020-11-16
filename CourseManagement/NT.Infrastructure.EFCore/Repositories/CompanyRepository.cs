using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.Companies;
using NT.CM.Domain;
using NT.CM.Domain.CompanyAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CompanyRepository : BaseRepository<long, Company> , ICompanyRepository
    {
        private readonly NTContext _ntcontext;
        public CompanyRepository(NTContext ntcontext): base(ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<CompanyViewModel> Search(CompanyViewModel command)
        {
            var Query = _ntcontext.Tbl_Companies.Where(x => x.Status == true).Select(listitem => new CompanyViewModel
            {
                ID = listitem.ID,
                CompanyName=listitem.CompanyName,
                Logo=listitem.Logo,
                Website=listitem.Website,
                IsPartner=listitem.IsPartner,
                IsClient=listitem.IsClient
            });
            if (!string.IsNullOrWhiteSpace(command.CompanyName))
                Query = Query.Where(x => x.CompanyName.Contains(command.CompanyName));
            return Query.OrderBy(x => x.ID).ToList();
        }
    }
}
