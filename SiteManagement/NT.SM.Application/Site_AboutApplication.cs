using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_AboutApplication : ISite_AboutApplication
    {
        private readonly ISite_AboutRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;

        public Site_AboutApplication(ISite_AboutRepository irepository, IUnitOfWorkNTSM iunitofwork)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
        }

        public OperationResult Create(Site_AboutViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var newitem = new Site_About(command.Title, command.Description, command.Site_Base_Id);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_AboutViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Edit(command.Title, command.Description);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_AboutViewModel GetBy(long id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_AboutViewModel
            {
                Id=selecteditem.ID,
                Title = selecteditem.Title,
                Description = selecteditem.Description,
                Site_Base_Id=selecteditem.Site_Base_Id
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

        public List<Site_AboutViewModel> Search(Site_AboutViewModel command = null)
        {
            return _irepository.Search(command);
        }
    }
}
