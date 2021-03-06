﻿using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_CertifiedProgramApplication : ISite_CertifiedProgramApplication
    {
        private readonly ISite_CertifiedProgramRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;
        private readonly IFileUploader _ifileuploader;

        public Site_CertifiedProgramApplication(ISite_CertifiedProgramRepository irepository, IUnitOfWorkNTSM iunitofwork, IFileUploader ifileuploader)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(Site_CertifiedProgramViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var path = $"SiteManagement//CertifiedProgram";
            var filename = _ifileuploader.Upload(command.Logo, path);
            var newitem = new Site_CertifiedProgram(filename, command.Title, command.ShortDescription, command.Description, command.Site_Base_Id);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_CertifiedProgramViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            var path = $"SiteManagement//CertifiedProgram";
            var filename = _ifileuploader.Upload(command.Logo, path);
            selecteditem.Edit(filename, command.Title, command.ShortDescription, command.Description);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_CertifiedProgramViewModel GetBy(long id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_CertifiedProgramViewModel
            {
                Id=selecteditem.ID,
                FileAddress = selecteditem.Logo,
                Title = selecteditem.Title,
                ShortDescription = selecteditem.ShortDescription,
                Description = selecteditem.Description,
                Site_Base_Id=selecteditem.Site_Base_Id
            };
        }

        public OperationResult Remove(long id)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(id);
            selecteditem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<Site_CertifiedProgramViewModel> Search(Site_CertifiedProgramViewModel command = null)
        {
            return _irepository.Search(command);
        }
    }
}
