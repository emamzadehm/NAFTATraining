using _01.Framework.Domain;
using NT.CM.Application.Contracts;
using NT.CM.Domain.CourseAgg;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface ICourseRepository : IRepository<long, Course>
    {
        List<CourseViewModel> Search(CourseViewModel command);
    }
}
