using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_ClientAllianceApplication : ISite_ClientAllianceApplication
    {
        private readonly ISite_ClientAllianceRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;

        public Site_ClientAllianceApplication(ISite_ClientAllianceRepository irepository, IUnitOfWorkNTSM iunitofwork)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
        }

        public OperationResult Create(Site_ClientAllianceViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var newitem = new Site_ClientAlliance(command.Name, command.Logo, command.Type, command.Site_Base_Id);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_ClientAllianceViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Edit(command.Name, command.Logo, command.Type);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_ClientAllianceViewModel GetBy(int id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_ClientAllianceViewModel
            {
                Id=selecteditem.ID,
                Name = selecteditem.Name,
                Logo = selecteditem.Logo,
                Type = selecteditem.Type,
                Site_Base_Id =selecteditem.Site_Base_Id
            };
        }

        public OperationResult Remove(Site_ClientAllianceViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<Site_ClientAllianceViewModel> Search(Site_ClientAllianceViewModel command)
        {
            return _irepository.Search(command);
        }
    }
}
