using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.CourseCandidateInstructorDetails;
using NT.CM.Domain.CourseCandidateInstructorDetailsAgg;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface ICourseCandidateInstructorDetailsRepository : IRepository<long, CourseCandidateInstructorDetails>
    {
        List<CourseCandidateInstructorDetailsViewModel> Search(CourseCandidateInstructorDetailsViewModel command = null);
    }
}
