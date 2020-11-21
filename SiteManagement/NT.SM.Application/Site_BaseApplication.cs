using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_BaseApplication : ISite_BaseApplication
    {
        private readonly ISite_BaseRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;

        public Site_BaseApplication(ISite_BaseRepository irepository, IUnitOfWorkNTSM iunitofwork)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
        }

        public OperationResult Create(Site_BaseViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var newitem = new Site_Base(command.MainTitle, command.MainDescription);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_BaseViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Edit(command.MainTitle, command.MainDescription);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_BaseViewModel GetBy(long id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_BaseViewModel
            {
                Id=selecteditem.ID,
                MainTitle = selecteditem.MainTitle,
                MainDescription = selecteditem.MainDescription
            };
        }

        public OperationResult Remove(long id)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(id);
            selecteditem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<Site_BaseViewModel> Search(Site_BaseViewModel command = null)
        {
            return _irepository.Search(command);
        }
    }
}
