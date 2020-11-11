using _01.Framework.Application;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels;
using NT.CM.Domain;
using NT.CM.Domain.CompanyAgg;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;
        private readonly ICompanyRepository _companyrepository;
        
        public CompanyApplication(ICompanyRepository companyrepository, IUnitOfWorkNT IUnitOfWorkNT)
        {
            _companyrepository = companyrepository;
            _IUnitOfWorkNT = IUnitOfWorkNT;
        }

        public OperationResult Create(CompanyViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var newcompany = new Company(command.CompanyName, command.Website, command.Logo, command.TypeID);
            _companyrepository.Create(newcompany);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CompanyViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var Company = _companyrepository.GetBy(command.ID);
            Company.Edit(command.CompanyName,command.Website,command.Logo,command.TypeID);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();

        }

        public CompanyViewModel GetBy(long id)
        {
            var SelectedCompany = _companyrepository.GetBy(id);
            return new CompanyViewModel
            {
                CompanyName = SelectedCompany.CompanyName,
                Website = SelectedCompany.Website,
                Logo = SelectedCompany.Logo,
                TypeID = SelectedCompany.TypeID,
                TypeName = SelectedCompany.BaseInfo.Title
            };
                
        }

        //public List<CompanyViewModel> List()
        //{
        //    var Companies = _companyrepository.GetAll();
        //    return Companies.Select(companylist => new CompanyViewModel
        //    {
        //        ID = companylist.ID,
        //        CompanyName = companylist.CompanyName,
        //        Website = companylist.Website,
        //        Logo = companylist.Logo,
        //        TypeID = companylist.TypeID,
        //        TypeName = companylist.BaseInfo?.Title
        //    }).ToList();
        //}

        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var Company = _companyrepository.GetBy(id);
            Company.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public List<CompanyViewModel> Search(CompanyViewModel searchmodel)
        {
            return _companyrepository.Search(searchmodel);
        }

    }
}
