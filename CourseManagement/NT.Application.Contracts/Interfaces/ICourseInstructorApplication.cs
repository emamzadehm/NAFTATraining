using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts.Interfaces
{
    public interface ICourseInstructorApplication
    {
        OperationResult Create(CourseInstructorViewModel command);
        OperationResult Edit(CourseInstructorViewModel command);
        OperationResult Remove(long id);
        CourseInstructorViewModel GetBy(long id);
        List<CourseInstructorViewModel> Search(CourseInstructorViewModel searchmodel);
    }
}
