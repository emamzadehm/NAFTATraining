using _01.Framework.Application;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;

namespace NT.UM.Application
{
    public class RolesApplication : IRolesApplication
    {
        private readonly IUnitOfWorkNTUM _iunitofwork;
        private readonly IRolesRepository _irolesrepository;

        public RolesApplication(IUnitOfWorkNTUM iunitofwork, IRolesRepository irolesrepository)
        {
            _iunitofwork = iunitofwork;
            _irolesrepository = irolesrepository;
        }

        public OperationResult Create(RolesViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new Roles(command.RoleName, command.Description);
            _irolesrepository.Create(NewItem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(RolesViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _irolesrepository.GetBy(command.ID);
            SelectedItem.Edit(command.RoleName, command.Description);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public RolesViewModel GetBy(long id)
        {
            var SelectedItem = _irolesrepository.GetBy(id);
            return new RolesViewModel
            {
                ID=SelectedItem.ID,
                RoleName=SelectedItem.RoleName,
                Status=SelectedItem.Status,
                Description=SelectedItem.Description
            };
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
