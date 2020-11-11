using _01.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts
{
    public interface ICourseApplication
    {
        OperationResult Create(CourseViewModel command);
        OperationResult Edit(CourseViewModel command);
        OperationResult Remove(long id);
        CourseViewModel GetBy(long id);
        List<CourseViewModel> Search(CourseViewModel searchmodel);
    }
}
