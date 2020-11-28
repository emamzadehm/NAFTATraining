using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Galleries;
using NT.CM.Domain;
using NT.CM.Domain.GalleryAgg;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class GalleryApplication : IGalleryApplication
    {
        private readonly IGalleryRepository _igalleryRepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;
        private readonly IFileUploader _ifileuploader;

        public GalleryApplication(IGalleryRepository igalleryRepository, IUnitOfWorkNT iUnitOfWorkNT, IFileUploader ifileuploader)
        {
            _igalleryRepository = igalleryRepository;
            _IUnitOfWorkNT = iUnitOfWorkNT;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(GalleryViewModel command, List<IFormFile> files)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            foreach (var photoAddress in files)
            {
                var path = $"Areas//AdminPanel//Pages//CourseManagement//Uploads//Gallery//" + command.Title.Slugify();
                var filename = _ifileuploader.Upload(photoAddress, path);
                var NewItem = new Gallery(command.Title, command.TypeID, filename, command.ParentID);
                _igalleryRepository.Create(NewItem);
            }

            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(GalleryViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _igalleryRepository.GetBy(command.ID);
            var path = $"Areas//AdminPanel//Pages//CourseManagement//Uploads//Gallery//" + command.Title.Slugify();
            var filename = _ifileuploader.Upload(command.PhotoAddress, path);
            SelectedItem.Edit(command.Title, command.TypeID, filename, command.ParentID);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _igalleryRepository.GetBy(id);
            SelectedItem.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public GalleryViewModel GetBy(long id)
        {
            return _igalleryRepository.GetDetails(id);
        }

        public List<GalleryViewModel> Search(GalleryViewModel searchmodel = null)
        {
            return _igalleryRepository.Search(searchmodel);
        }
    }
}
