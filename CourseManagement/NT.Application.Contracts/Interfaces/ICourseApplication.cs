using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.Courses;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts
{
    public interface ICourseApplication
    {
        OperationResult Create(CourseViewModel command);
        OperationResult Edit(CourseViewModel command);
        OperationResult Remove(long id);
        CourseViewModel GetBy(long id);
        List<CourseViewModel> Search(CourseViewModel searchmodel = null);
    }
}
