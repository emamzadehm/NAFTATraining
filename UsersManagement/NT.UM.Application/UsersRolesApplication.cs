﻿using _01.Framework.Application;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Application
{
    public class UsersRolesApplication : IUsersRolesApplication
    {
        private readonly IUnitOfWorkNTUM _iunitofwork;
        private readonly IUsersRolesRepository _iusersrolesrepository;

        public OperationResult Create(UsersRolesViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new UsersRoles(command.UserID, command.RoleID);
            _iusersrolesrepository.Create(NewItem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(UsersRolesViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iusersrolesrepository.GetBy(command.ID);
            SelectedItem.Edit(command.UserID, command.RoleID);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public UsersRolesViewModel GetBy(long id)
        {
            var SelectedItem = _iusersrolesrepository.GetBy(id);
            return new UsersRolesViewModel
            {
               ID=SelectedItem.ID,
               RoleID=SelectedItem.RoleID,
               UserID=SelectedItem.UserID,
               Status=SelectedItem.Status
            };
        }

        public OperationResult Remove(long id)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iusersrolesrepository.GetBy(id);
            SelectedItem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<UsersRolesViewModel> Search(UsersRolesViewModel searchmodel = null)
        {
            return _iusersrolesrepository.Search(searchmodel);
        }
    }
}
