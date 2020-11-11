using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_EvaluationResultApplication : ISite_EvaluationResultApplication
    {
        private readonly ISite_EvaluationResultRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;

        public Site_EvaluationResultApplication(ISite_EvaluationResultRepository irepository, IUnitOfWorkNTSM iunitofwork)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
        }

        public OperationResult Create(Site_EvaluationResultViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var newitem = new Site_EvaluationResult(command.Title, command.Percentage);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_EvaluationResultViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Edit(command.Title, command.Percentage);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_EvaluationResultViewModel GetBy(int id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_EvaluationResultViewModel
            {
                Id=selecteditem.ID,
                Title = selecteditem.Title,
                Percentage = selecteditem.Percentage
            };
        }

        public OperationResult Remove(Site_EvaluationResultViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<Site_EvaluationResultViewModel> Search(Site_EvaluationResultViewModel command)
        {
            return _irepository.Search(command);
        }
    }
}
