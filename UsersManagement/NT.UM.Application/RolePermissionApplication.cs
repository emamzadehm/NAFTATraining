using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using System.Collections.Generic;

namespace NT.UM.Application
{
    public class RolePermissionApplication : IRolePermissionApplication
    {
        private readonly IUnitOfWorkNTUM _iunitofwork;
        private readonly IRolePermissionRepository _irolepermissionrepository;

        public RolePermissionApplication(IUnitOfWorkNTUM iunitofwork, IRolePermissionRepository irolepermissionrepository)
        {
            _iunitofwork = iunitofwork;
            _irolepermissionrepository = irolepermissionrepository;
        }

        public Dictionary<long?, List<RolePermissionViewModel>> GetPermissionsByRole(long id = 0)
        {
            return _irolepermissionrepository.GetPermissionsByRole(id);
        }

        //public OperationResult Create(RolePermissionViewModel command)
        //{
        //    _iunitofwork.BeginTran();
        //    var operationresult = new OperationResult();
        //    var NewItem = new RolePermission(command.RoleID, command.PermissionID);
        //    _irolepermissionrepository.Create(NewItem);
        //    _iunitofwork.CommitTran();
        //    return operationresult.Successful();
        //}

        //public OperationResult Edit(RolePermissionViewModel command)
        //{
        //    _iunitofwork.BeginTran();
        //    var operationresult = new OperationResult();
        //    var SelectedItem = _irolepermissionrepository.GetBy(command.ID);
        //    SelectedItem.Edit(command.RoleID, command.PermissionID);
        //    _iunitofwork.CommitTran();
        //    return operationresult.Successful();
        //}

        //public RolePermissionViewModel GetDetailsbyRole(long id)
        //{
        //    return _irolepermissionrepository.GetDetailsbyRole(long id);
        //}

        //public OperationResult Remove(long id)
        //{
        //    _iunitofwork.BeginTran();
        //    var operationresult = new OperationResult();
        //    var SelectedItem = _irolepermissionrepository.GetBy(id);
        //    SelectedItem.Remove();
        //    _iunitofwork.CommitTran();
        //    return operationresult.Successful();
        //}

        //public List<RolePermissionViewModel> Search(RolePermissionViewModel searchmodel = null)
        //{
        //    return _irolepermissionrepository.Search(searchmodel);
        //}
    }
}
