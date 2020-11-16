using _01.Framework.Application;
using Domain.BaseInfoAgg;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Domain;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class BaseInfoApplication : IBaseInfoApplication
    {
        private readonly IBaseInfoRepository _baseinforepository;
        private readonly IUnitOfWorkNT _unitofwork;
        public BaseInfoApplication(IBaseInfoRepository baseinforepository, IUnitOfWorkNT unitofwork)
        {
            _baseinforepository = baseinforepository;
            _unitofwork = unitofwork;
        }
        public OperationResult Create(BaseInfoViewModel command)
        {
            _unitofwork.BeginTran();
            var operationresult = new OperationResult();
            var Baseinfo = new BaseInfo(command.Title, command.TypeID, command.ParentID);
            _baseinforepository.Create(Baseinfo);
            _unitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(BaseInfoViewModel command)
        {
            _unitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedBaseinfo = _baseinforepository.GetBy(command.ID);
            SelectedBaseinfo.Edit(command.Title, command.TypeID, command.ParentID);
            _unitofwork.CommitTran();
            return operationresult.Successful();


        }
        public OperationResult Remove(long id)
        {
            _unitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedBaseinfo = _baseinforepository.GetBy(id);
            SelectedBaseinfo.Remove();
            _unitofwork.CommitTran();
            return operationresult.Successful();
        }

    public BaseInfoViewModel GetBy(long id)
        {
            var SelectedBaseInfo = _baseinforepository.GetBy(id);
            return new BaseInfoViewModel
            {
                ID = SelectedBaseInfo.ID,
                Title = SelectedBaseInfo.Title,
                TypeID = SelectedBaseInfo.TypeID,
                ParentID = SelectedBaseInfo.ParentID
            };
        }

        public List<BaseInfoViewModel> Search(BaseInfoViewModel searchmodel)
        {
            return _baseinforepository.Search(searchmodel);
        }

        public List<BaseInfoViewModel> GetAll()
        {
            return _baseinforepository.GetAll();
        }

        public List<BaseInfoViewModel> GetByTypeId(long typeid)
        {
            return _baseinforepository.GetByTypeId(typeid);
        }

        public List<BaseInfoViewModel> GetAllTypes()
        {
            return _baseinforepository.GetAllTypes();
        }
    }
}
