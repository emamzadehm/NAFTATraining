using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using NT.CM.Domain.CourseInstructorAgg;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface ICourseInstructorRepository : IRepository<long, CourseInstructor>
    {
        List<CourseInstructorViewModel> Search(CourseInstructorViewModel command);
        CourseInstructorViewModel GetDetails(long id);
    }
}
