using _01.Framework.Application;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Companies;
using NT.CM.Domain;
using NT.CM.Domain.CompanyAgg;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;
        private readonly ICompanyRepository _companyrepository;
        private readonly IFileUploader _ifileuploader;

        public CompanyApplication(IUnitOfWorkNT iUnitOfWorkNT, ICompanyRepository companyrepository, IFileUploader ifileuploader)
        {
            _IUnitOfWorkNT = iUnitOfWorkNT;
            _companyrepository = companyrepository;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(CompanyViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var Company = _companyrepository.GetBy(command.ID);
            var path = $"AdminPanel//CourseManagement//Uploads//CompanyLogo//" + command.CompanyName.Slugify();
            var filename = _ifileuploader.Upload(command.Logo, path);
            var newcompany = new Company(command.CompanyName, command.Website, filename, command.IsPartner, command.IsClient);
            _companyrepository.Create(newcompany);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CompanyViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var Company = _companyrepository.GetBy(command.ID);
            var path = $"AdminPanel//CourseManagement//Uploads//CompanyLogo//" + command.CompanyName.Slugify();
            var filename = _ifileuploader.Upload(command.Logo, path);
            Company.Edit(command.CompanyName,command.Website,filename, command.IsPartner, command.IsClient);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();

        }

        public CompanyViewModel GetBy(long id)
        {
            var SelectedCompany = _companyrepository.GetBy(id);
            return new CompanyViewModel
            {
                ID=SelectedCompany.ID,
                CompanyName = SelectedCompany.CompanyName,
                Website = SelectedCompany.Website,
                FileAddress = SelectedCompany.Logo,
                IsClient=SelectedCompany.IsClient,
                IsPartner=SelectedCompany.IsPartner
            };
                
        }


        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var Company = _companyrepository.GetBy(id);
            Company.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public List<CompanyViewModel> Search(CompanyViewModel searchmodel = null)
        {
            return _companyrepository.Search(searchmodel);
        }

    }
}
