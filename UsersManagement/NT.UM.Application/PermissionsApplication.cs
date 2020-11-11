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
            var NewItem = new Permissions(command.Title);
            _ipermissionsrepository.Create(NewItem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(PermissionsViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _ipermissionsrepository.GetBy(command.ID);
            SelectedItem.Edit(command.Title);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public PermissionsViewModel GetBy(long id)
        {
            var SelectedItem = _ipermissionsrepository.GetBy(id);
            return new PermissionsViewModel
            {
                ID = SelectedItem.ID,
                Title=SelectedItem.Title,
                Status=SelectedItem.Status
            };
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

        public List<PermissionsViewModel> Search(PermissionsViewModel searchmodel)
        {
            return _ipermissionsrepository.Search(searchmodel);
        }
    }
}
