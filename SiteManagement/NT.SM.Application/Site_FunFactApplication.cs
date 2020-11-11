using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_FunFactApplication : ISite_FunFactApplication
    {
        private readonly ISite_FunFactRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;

        public Site_FunFactApplication(ISite_FunFactRepository irepository, IUnitOfWorkNTSM iunitofwork)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
        }

        public OperationResult Create(Site_FunFactViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var newitem = new Site_FunFact(command.Title, command.ValueNumber);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_FunFactViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Edit(command.Title, command.ValueNumber);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_FunFactViewModel GetBy(int id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_FunFactViewModel
            {
                Id=selecteditem.ID,
                Title = selecteditem.Title,
                ValueNumber = selecteditem.ValueNumber
            };
        }

        public OperationResult Remove(Site_FunFactViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<Site_FunFactViewModel> Search(Site_FunFactViewModel command)
        {
            return _irepository.Search(command);
        }
    }
}
