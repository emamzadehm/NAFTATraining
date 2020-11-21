using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_CourseRepository : IRepository<long, Site_Course>
    {
        List<Site_CourseViewModel> Search(Site_CourseViewModel command = null);

    }
}
