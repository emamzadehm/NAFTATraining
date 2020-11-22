using _01.Framework.Application;
using NT.CM.Application.Contracts;
using NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor;
using NT.CM.Domain;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using System.Collections.Generic;

namespace NT.CM.Application
{
    public class CandidateCourseInstructorApplication : ICandidateCourseInstructorApplication
    {
        private readonly ICandidateCourseInstructorRepository _icandidatecourseinstructorRepository;
        private readonly IUnitOfWorkNT _IUnitOfWorkNT;

        public CandidateCourseInstructorApplication(ICandidateCourseInstructorRepository icandidatecourseinstructorRepository, IUnitOfWorkNT IUnitOfWorkNT)
        {
            _icandidatecourseinstructorRepository = icandidatecourseinstructorRepository;
            _IUnitOfWorkNT = IUnitOfWorkNT;
        }

        public OperationResult Create(CreateEditCandidateCourseInstructorViewModel command)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            var Newitem = new CandidateCourseInstructor(command.Course_InstructorID, command.CandidateID);
            _icandidatecourseinstructorRepository.Create(Newitem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public OperationResult Edit(CreateEditCandidateCourseInstructorViewModel command)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            var selecteditem = _icandidatecourseinstructorRepository.GetBy(command.ID);
            selecteditem.Edit(command.Course_InstructorID, command.CandidateID);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }
        public List<CandidateCourseInstructorViewModel> GetRegisteredCandidates(long courseinstructorid)
        {
            return _icandidatecourseinstructorRepository.GetRegisteredCandidates(courseinstructorid);
        }
        public CandidateCourseInstructorViewModel GetDetails(long id)
        {
            return _icandidatecourseinstructorRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operationresult = new OperationResult();
            _IUnitOfWorkNT.BeginTran();
            var selecteditem = _icandidatecourseinstructorRepository.GetBy(id);
            _icandidatecourseinstructorRepository.Create(selecteditem);
            _IUnitOfWorkNT.CommitTran();
            return operationresult.Successful();
        }

        public List<CandidateCourseInstructorViewModel> Search(CandidateCourseInstructorViewModel searchmodel = null)
        {
            return _icandidatecourseinstructorRepository.Search(searchmodel);
        }
    }
}