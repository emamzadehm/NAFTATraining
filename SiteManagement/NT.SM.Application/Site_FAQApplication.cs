using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_FAQApplication : ISite_FAQApplication
    {
        private readonly ISite_FAQRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;

        public Site_FAQApplication(ISite_FAQRepository irepository, IUnitOfWorkNTSM iunitofwork)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
        }

        public OperationResult Create(Site_FAQViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var newitem = new Site_FAQ(command.Question, command.Answer);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_FAQViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Edit(command.Question, command.Answer);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_FAQViewModel GetBy(long id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_FAQViewModel
            {
                Id=selecteditem.ID,
                Question = selecteditem.Question,
                Answer = selecteditem.Answer
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

        public List<Site_FAQViewModel> Search(Site_FAQViewModel command = null)
        {
            return _irepository.Search(command);
        }
    }
}
