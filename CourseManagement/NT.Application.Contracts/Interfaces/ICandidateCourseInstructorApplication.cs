using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts
{
    public interface ICandidateCourseInstructorApplication
    {
        OperationResult Create(CandidateCourseInstructorViewModel command);
        OperationResult Edit(CandidateCourseInstructorViewModel command);
        OperationResult Remove(long id);
        CandidateCourseInstructorViewModel GetBy(long id);
        List<CandidateCourseInstructorViewModel> Search(CandidateCourseInstructorViewModel searchmodel);
    }
}
