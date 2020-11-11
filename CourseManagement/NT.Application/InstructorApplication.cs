using _01.Framework.Application;
using NT.CM.Application.Contracts.Interfaces;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using NT.CM.Domain;
using NT.CM.Domain.InstructorAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application
{
    public class InstructorApplication : IInstructorApplication
    {
        private readonly IInstructorRepository _iinstructorRepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;

        public InstructorApplication(IInstructorRepository iinstructorRepository, IUnitOfWorkNT iUnitOfWorkNT)
        {
            _iinstructorRepository = iinstructorRepository;
            _IUnitOfWorkNT = iUnitOfWorkNT;
        }

        public OperationResult Create(InstructorsViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var NewItem = new Instructor(command.EducationLevel, command.Resume);
            _iinstructorRepository.Create(NewItem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(InstructorsViewModel command)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iinstructorRepository.GetBy(command.ID);
            SelectedItem.Edit(command.EducationLevel, command.Resume);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Remove(long id)
        {
            _IUnitOfWorkNT.BeginTran();
            var operationresult = new OperationResult();
            var SelectedItem = _iinstructorRepository.GetBy(id);
            SelectedItem.Remove();
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public InstructorsViewModel GetBy(long id)
        {
            var SelectedItem = _iinstructorRepository.GetBy(id);
            var result = new InstructorsViewModel
            {
                ID = SelectedItem.ID,
                EducationLevel=SelectedItem.EducationLevel,
                Resume=SelectedItem.Resume
            };
            return result;
        }

        public List<InstructorsViewModel> Search(InstructorsViewModel searchmodel)
        {
            return _iinstructorRepository.Search(searchmodel);
        }
    }
}
