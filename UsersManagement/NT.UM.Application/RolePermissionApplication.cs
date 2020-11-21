using _01.Framework.Application;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using NT.UM.Infrastructure.EFCore.Repositories;
using System.Collections.Generic;

namespace NT.UM.Application
{
    public class RolePermissionApplication : IRolePermissionApplication
    {
        private readonly IUnitOfWorkNTUM _iunitofwork;
        private readonly RolePermissionRepository _irolepermissionrepository;

        public RolePermissionApplication(IUnitOfWorkNTUM iunitofwork, RolePermissionRepository irolepermissionrepository)
        {
            _iunitofwork = iunitofwork;
            _irolepermissionrepository = irolepermissionrepository;
        }

        public OperationResult Create(RolePermissionViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new RolePermission(command.RoleID, command.PermissionID);
            _irolepermissionrepository.Create(NewItem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(RolePermissionViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irolepermissionrepository.GetBy(command.ID);
            SelectedItem.Edit(command.RoleID, command.PermissionID);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public RolePermissionViewModel GetBy(long id)
        {
            var SelectedItem = _irolepermissionrepository.GetBy(id);
            return new RolePermissionViewModel
            {
                ID=SelectedItem.ID,
                PermissionID=SelectedItem.PermissionID,
                PermissionName =SelectedItem.Permissions.Title,
                RoleID=SelectedItem.RoleID,
                RoleName=SelectedItem.Roles.RoleName,
                Status=SelectedItem.Status
            };
        }

        public OperationResult Remove(long id)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irolepermissionrepository.GetBy(id);
            SelectedItem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<RolePermissionViewModel> Search(RolePermissionViewModel searchmodel = null)
        {
            return _irolepermissionrepository.Search(searchmodel);
        }
    }
}
