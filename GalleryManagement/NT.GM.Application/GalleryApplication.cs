using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using NT.GM.Application.Contracts.Interfaces;
using NT.GM.Application.Contracts.ViewModels.Galleries;
using NT.GM.Domain;
using NT.GM.Domain.GalleryAgg;
using System.Collections.Generic;

namespace NT.GM.Application
{
    public class GalleryApplication : IGalleryApplication
    {
        private readonly IGalleryRepository _igalleryRepository;
        private readonly IUnitOfWorkNTGM _IUnitOfWorkNTGM;
        private readonly IFileUploader _ifileuploader;

        public GalleryApplication(IGalleryRepository igalleryRepository, IUnitOfWorkNTGM iUnitOfWorkNTGM,
            IFileUploader ifileuploader)
        {
            _igalleryRepository = igalleryRepository;
            _IUnitOfWorkNTGM = iUnitOfWorkNTGM;
            _ifileuploader = ifileuploader;
        }

        public OperationResult Create(GalleryViewModel command, List<IFormFile> files)
        {
            _IUnitOfWorkNTGM.BeginTran();
            var operationresult = new OperationResult();
            foreach (var photoAddress in files)
            {
                var path = $"GalleryManagement//" + command.Title.Slugify();
                var filename = _ifileuploader.Upload(photoAddress, path);
                var NewItem = new Gallery(command.Title, command.TypeID, filename, command.ParentID,
                    command.CourseInstructorId, command.MetaDescription, command.Keywords, command.Slug, command.CanonicalAddress);
                _igalleryRepository.Create(NewItem);
            }

            _IUnitOfWorkNTGM.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(GalleryViewModel command)
        {
            _IUnitOfWorkNTGM.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _igalleryRepository.GetBy(command.ID);
            var path = $"GalleryManagement//" + command.Title.Slugify();
            var filename = _ifileuploader.Upload(command.PhotoAddress, path);
            SelectedItem.Edit(command.Title, command.TypeID, filename, command.ParentID, command.CourseInstructorId,
                command.MetaDescription, command.Keywords, command.Slug, command.CanonicalAddress);
            _IUnitOfWorkNTGM.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNTGM.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _igalleryRepository.GetBy(id);
            SelectedItem.Remove();
            _IUnitOfWorkNTGM.CommitTran();
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

        public List<GalleryViewModel> GetAlbums()
        {
            return _igalleryRepository.GetAlbums();
        }

        public List<GalleryViewModel> GetPhotoByAlbum(long id)
        {
            return _igalleryRepository.GetPhotoByAlbum(id);
        }
    }
}
