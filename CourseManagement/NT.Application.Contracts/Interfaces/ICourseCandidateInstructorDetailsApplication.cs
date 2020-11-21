using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.CourseCandidateInstructorDetails;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.Interfaces
{
    public interface ICourseCandidateInstructorDetailsApplication
    {
        OperationResult Create(CourseCandidateInstructorDetailsViewModel command);
        OperationResult Edit(CourseCandidateInstructorDetailsViewModel command);
        OperationResult Remove(long id);
        CourseCandidateInstructorDetailsViewModel GetBy(long id);
        List<CourseCandidateInstructorDetailsViewModel> Search(CourseCandidateInstructorDetailsViewModel searchmodel = null);
    }
}
