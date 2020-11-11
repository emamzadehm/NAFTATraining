using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.CourseCandidateInstructorDetails;
using NT.CM.Domain;
using NT.CM.Domain.CourseCandidateInstructorDetailsAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CourseCandidateInstructorDetailsRepository: BaseRepository<long, CourseCandidateInstructorDetails>, ICourseCandidateInstructorDetailsRepository
    {
        private readonly NTContext _ntcontext;
        public CourseCandidateInstructorDetailsRepository(NTContext ntcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<CourseCandidateInstructorDetailsViewModel> Search(CourseCandidateInstructorDetailsViewModel command)
        {
            var Query = _ntcontext.Tbl_Course_Candidate_Instructor_Details.Where(x => x.Status == true).Select(listitem => new CourseCandidateInstructorDetailsViewModel
            {
                ID = listitem.ID,
                TypeID=listitem.TypeID,
                BaseInfoName=listitem.BaseInfo.Title,
                CCI_ID=listitem.CCI_ID,
                DocumentIMG=listitem.DocumentIMG,
                Value=listitem.Value
            });
            if (!string.IsNullOrWhiteSpace(command.BaseInfoName))
                Query = Query.Where(x => x.BaseInfoName.Contains(command.BaseInfoName));
            return Query.OrderBy(x => x.ID).ToList();
        }
    }
}
