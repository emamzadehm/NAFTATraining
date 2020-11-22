using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts
{
    public interface ICandidateCourseInstructorApplication
    {
        OperationResult Create(CreateEditCandidateCourseInstructorViewModel command);
        OperationResult Edit(CandidateCourseInstructorViewModel command);
        OperationResult Remove(long id);
        List<CandidateCourseInstructorViewModel> GetRegisteredCandidates(long courseinstructorid);
        CandidateCourseInstructorViewModel GetDetails(long id);
        List<CandidateCourseInstructorViewModel> Search(CandidateCourseInstructorViewModel searchmodel = null);
    }
}
