using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.Courses;
using NT.CM.Domain.CourseAgg;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface ICourseRepository : IRepository<long, Course>
    {
        List<CourseViewModel> Search(CourseViewModel command);
        CourseViewModel  GetDetails(long id);

    }
}
