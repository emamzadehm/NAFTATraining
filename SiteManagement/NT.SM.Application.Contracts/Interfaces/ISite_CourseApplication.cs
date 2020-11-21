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
        OperationResult Remove(long id);
        Site_CourseViewModel GetBy(long id);
        List<Site_CourseViewModel> Search(Site_CourseViewModel command = null);
    }
}
