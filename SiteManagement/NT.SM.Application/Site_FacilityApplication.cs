using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_FacilityApplication : ISite_FacilityApplication
    {
        private readonly ISite_FacilityRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;
        private readonly IFileUploader _ifileuploader;

        public Site_FacilityApplication(ISite_FacilityRepository irepository, IUnitOfWorkNTSM iunitofwork, IFileUploader ifileuploader)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(Site_FacilityViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var path = $"SiteManagement//Facility";
            var filename = _ifileuploader.Upload(command.Img, path);
            var newitem = new Site_Facility(command.Title, command.Description, command.HasBullet, filename, command.Site_Base_Id);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_FacilityViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            var path = $"SiteManagement//Facility";
            var filename = _ifileuploader.Upload(command.Img, path);
            selecteditem.Edit(command.Title, command.Description, command.HasBullet, filename);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_FacilityViewModel GetBy(long id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_FacilityViewModel
            {
                Id=selecteditem.ID,
                Title = selecteditem.Title,
                Description = selecteditem.Description,
                HasBullet=selecteditem.HasBullet,
                FileAddress=selecteditem.Img,
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

        public List<Site_FacilityViewModel> Search(Site_FacilityViewModel command = null)
        {
            return _irepository.Search(command);
        }
    }
}
