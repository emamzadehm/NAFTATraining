using _01.Framework.Application;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Galleries;
using NT.CM.Domain;
using NT.CM.Domain.GalleryAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application
{
    public class GalleryApplication : IGalleryApplication
    {
        private readonly IGalleryRepository _igalleryRepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;

        public GalleryApplication(IGalleryRepository igalleryRepository, IUnitOfWorkNT IUnitOfWorkNT)
        {
            _igalleryRepository = igalleryRepository;
            _IUnitOfWorkNT = IUnitOfWorkNT;
        }

        public OperationResult Create(GalleryViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new Gallery(command.Title,command.TypeID,command.PhotoAddress);
            _igalleryRepository.Create(NewItem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(GalleryViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _igalleryRepository.GetBy(command.ID);
            SelectedItem.Edit(command.Title, command.TypeID, command.PhotoAddress);
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
            var SelectedItem = _igalleryRepository.GetBy(id);
            var result = new GalleryViewModel
            {
                ID = SelectedItem.ID,
                Title =SelectedItem.Title,
                PhotoAddress=SelectedItem.PhotoAddress,
                TypeID=SelectedItem.TypeID,
                BaseInfoName = SelectedItem.BaseInfo.Title,
                ParentID = SelectedItem.ParentID
            };
            return result;
        }

        public List<GalleryViewModel> Search(GalleryViewModel searchmodel)
        {
            return _igalleryRepository.Search(searchmodel);
        }
    }
}
