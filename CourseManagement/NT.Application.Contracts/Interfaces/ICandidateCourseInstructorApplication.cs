using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts
{
    public interface ICandidateCourseInstructorApplication
    {
        OperationResult Create(CreateEditCandidateCourseInstructorViewModel command);
        OperationResult Edit(CreateEditCandidateCourseInstructorViewModel command);
        OperationResult Remove(long id);
        CandidateCourseInstructorViewModel GetDetails(long id);
        List<CandidateCourseInstructorViewModel> Search(CandidateCourseInstructorViewModel searchmodel = null);
    }
}
