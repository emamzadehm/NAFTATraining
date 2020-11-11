using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface ICandidateCourseInstructorRepository : IRepository<long, CandidateCourseInstructor>
    {
        List<CandidateCourseInstructorViewModel> Search(CandidateCourseInstructorViewModel command);

    }
}
