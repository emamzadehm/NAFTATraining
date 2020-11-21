using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.Interfaces
{
    public interface ICourseInstructorApplication
    {
        OperationResult Create(CourseInstructorViewModel command);
        OperationResult Edit(CourseInstructorViewModel command);
        OperationResult Remove(long id);
        CourseInstructorViewModel GetDetails(long id);
        List<CourseInstructorViewModel> Search(CourseInstructorViewModel searchmodel = null);
    }
}
