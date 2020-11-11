using _01.Framework.Application;
using NT.SM.Application.Contracts.Interfaces;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Application
{
    public class Site_CourseApplication : ISite_CourseApplication
    {
        private readonly ISite_CourseRepository _irepository;
        private readonly IUnitOfWorkNTSM _iunitofwork;

        public Site_CourseApplication(ISite_CourseRepository irepository, IUnitOfWorkNTSM iunitofwork)
        {
            _irepository = irepository;
            _iunitofwork = iunitofwork;
        }

        public OperationResult Create(Site_CourseViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var newitem = new Site_Course(command.Icon, command.Title, command.Description, command.Site_Base_Id);
            _irepository.Create(newitem);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(Site_CourseViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Edit(command.Icon, command.Title, command.Description);
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public Site_CourseViewModel GetBy(int id)
        {
            var selecteditem = _irepository.GetBy(id);
            return new Site_CourseViewModel
            {
                Id=selecteditem.ID,
                Icon=selecteditem.Icon,
                Title = selecteditem.Title,
                Description = selecteditem.Description,
                Site_Base_Id=selecteditem.Site_Base_Id
            };
        }

        public OperationResult Remove(Site_CourseViewModel command)
        {
            _iunitofwork.BeginTran();
            var operationresult = new OperationResult();
            var selecteditem = _irepository.GetBy(command.Id);
            selecteditem.Remove();
            _iunitofwork.CommitTran();
            return operationresult.Successful();
        }

        public List<Site_CourseViewModel> Search(Site_CourseViewModel command)
        {
            return _irepository.Search(command);
        }
    }
}
