using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_CourseApplication
    {
        OperationResult Create(Site_CourseViewModel command);
        OperationResult Edit(Site_CourseViewModel command);
        OperationResult Remove(Site_CourseViewModel command);
        Site_CourseViewModel GetBy(int id);
        List<Site_CourseViewModel> Search(Site_CourseViewModel command);
    }
}
