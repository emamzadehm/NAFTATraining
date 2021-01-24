using _01.Framework.Application;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Application
{
    public class RolesApplication : IRolesApplication
    {
        private readonly IUnitOfWorkNTUM _iunitofwork;
        private readonly IRolesRepository _irolesrepository;
        private readonly IRolePermissionRepository _irolespermissionrepository;

        public RolesApplication(IUnitOfWorkNTUM iunitofwork, IRolesRepository irolesrepository,
            IRolePermissionRepository irolespermissionrepository)
        {
            _iunitofwork = iunitofwork;
            _irolesrepository = irolesrepository;
            _irolespermissionrepository = irolespermissionrepository;
        }

        public OperationResult Create(RolesViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var permissions = new List<RolePermission>();
            foreach (var item in command.SelectedPermissions)
            {
                permissions.Add(new RolePermission(command.ID, item));
            }
            var NewItem = new Role(command.RoleName, command.Description, permissions);
            _irolesrepository.Create(NewItem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(RolesViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irolesrepository.GetBy(command.ID);
            var permissions = new List<RolePermission>();

            if (command.SelectedPermissions != null)
            {
                var addedpermissions = command.SelectedPermissions.Except(_irolesrepository.GetDetails(command.ID).SelectedPermissions).ToList();
                var removedpermissions = _irolesrepository.GetDetails(command.ID).SelectedPermissions.Except(command.SelectedPermissions).ToList();

                if (addedpermissions.Count > 0)
                {
                    foreach (var item in addedpermissions)
                    {
                        permissions.Add(new RolePermission(command.ID, item));
                    }
                }
                if (removedpermissions.Count > 0)
                {
                    foreach (var item in removedpermissions)
                    {
                        var selectedpermission = _irolespermissionrepository.GetIdByRoleAndPermission(item, command.ID);
                        selectedpermission.Remove();
                    }
                }
            }
            else
            {
                var selectedpermission = _irolespermissionrepository.GetPermissionsByRoleId(command.ID);
                foreach (var item in selectedpermission)
                {
                    item.Remove();
                }

            }
            SelectedItem.Edit(command.RoleName, command.Description, permissions);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public RolesViewModel GetDetails(long id)
        {
            return _irolesrepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irolesrepository.GetBy(id);
            SelectedItem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<RolesViewModel> Search(RolesViewModel searchmodel = null)
        {
            return _irolesrepository.Search(searchmodel);
        }
    }
}
