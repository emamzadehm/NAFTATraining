using _01.Framework.Application;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Application
{
    public class PermissionsApplication : IPermissionsApplication
    {
        private readonly IUnitOfWorkNTUM _iunitofwork;
        private readonly IPermissionsRepository _ipermissionsrepository;

        public PermissionsApplication(IUnitOfWorkNTUM iunitofwork, IPermissionsRepository ipermissionsrepository)
        {
            _iunitofwork = iunitofwork;
            _ipermissionsrepository = ipermissionsrepository;
        }

        public OperationResult Create(PermissionsViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new Permission(command.Title,command.TypeId,command.ParentId);
            _ipermissionsrepository.Create(NewItem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(PermissionsViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _ipermissionsrepository.GetBy(command.ID);
            SelectedItem.Edit(command.Title, command.TypeId, command.ParentId);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public PermissionsViewModel GetDetails(long? id)
        {
            return _ipermissionsrepository.GetDetails(id);
        }

        public List<PermissionsViewModel> GetAllModules()
        {
            return _ipermissionsrepository.GetAllModules();
        }

        public OperationResult Remove(long id)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _ipermissionsrepository.GetBy(id);
            SelectedItem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<PermissionsViewModel> Search(PermissionsViewModel searchmodel = null)
        {
            return _ipermissionsrepository.Search(searchmodel);
        }

        //public List<PermissionsViewModel> GetPermissionsByModule(long id=0)
        //{
        //    return _ipermissionsrepository.GetPermissionsByModule(id);
        //}

        public Dictionary<long?, List<PermissionsViewModel>> GetPermissionsByModule(long id = 0)
        {
            return _ipermissionsrepository.GetPermissionsByModule(id);
        }

        public List<PermissionsViewModel> GetPermissionOperationByType(long id)
        {
            return _ipermissionsrepository.GetPermissionOperationByType(id);
        }
    }
}
