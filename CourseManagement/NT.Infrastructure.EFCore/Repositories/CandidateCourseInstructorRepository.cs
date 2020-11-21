using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor;
using NT.CM.Domain;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using NT.UM.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CandidateCourseInstructorRepository : BaseRepository<long, CandidateCourseInstructor>, ICandidateCourseInstructorRepository
    {
        private readonly NTContext _ntcontext;
        private readonly NTUMContext _ntumcontext;

        public CandidateCourseInstructorRepository(NTContext ntcontext, NTUMContext ntumcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
            _ntumcontext = ntumcontext;
        }

        public CandidateCourseInstructorViewModel GetDetails(long id)
        {
            var CandidateCourseInstructor = _ntcontext.Tbl_Candidate_Course_Instructor
                .Where(x => x.Status == true)
                .Select(listitem => new CandidateCourseInstructorViewModel
                {
                    ID = listitem.ID,
                    CandidateID = listitem.CandidateID,
                    Fullname = MaptoUser(listitem.Candidates.UserId),
                    Course_InstructorID = listitem.Course_InstructorID,
                    InstructorName = MaptoUser(listitem.CourseInstructors.Instructor.UserId),
                    CourseName = listitem.CourseInstructors.Course.CName,
                    RegistrationDate = listitem.RegistrationDate,
                    CompanyID = listitem.Candidates.CompanyID,
                    CompanyName = listitem.Candidates.Company.CompanyName,
                    SDate = listitem.CourseInstructors.SDate,
                    EDate = listitem.CourseInstructors.EDate,
                    Venue=listitem.CourseInstructors.Venue,
                    Location=listitem.CourseInstructors.Location,
                    LocationName=listitem.CourseInstructors.BaseInfo.Title
                }).FirstOrDefault(x => x.ID == id);
            return CandidateCourseInstructor;
        }

        private string MaptoUser(long userId)
        {
            var selecteduser = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.Sex, x.FirstName, x.LastName }).FirstOrDefault(x => x.ID == userId);
            return selecteduser.Sex + " " + selecteduser.FirstName + " " + selecteduser.LastName;
        }

        public List<CandidateCourseInstructorViewModel> Search(CandidateCourseInstructorViewModel command = null)
        {
            var Query = _ntcontext.Tbl_Candidate_Course_Instructor
                .Where(x => x.Status == true)
                .Select(listitem => new CandidateCourseInstructorViewModel
                {
                    ID = listitem.ID,
                    CandidateID = listitem.CandidateID,
                    Fullname = MaptoUser(listitem.Candidates.UserId),
                    InstructorID = listitem.CourseInstructors.Instructor.ID,
                    InstructorName = MaptoUser(listitem.CourseInstructors.Instructor.UserId),
                    CourseID = listitem.CourseInstructors.Course.ID,
                    CourseName = listitem.CourseInstructors.Course.CName,
                    RegistrationDate = listitem.RegistrationDate,
                    CompanyID=listitem.Candidates.CompanyID,
                    CompanyName = listitem.Candidates.Company.CompanyName,
                    SDate = listitem.CourseInstructors.SDate,
                    EDate = listitem.CourseInstructors.EDate,
                    Venue = listitem.CourseInstructors.Venue,
                    Location = listitem.CourseInstructors.Location,
                    LocationName = listitem.CourseInstructors.BaseInfo.Title
                });
            if (command != null)
            {
                if (command.CourseID > 0)
                    Query = Query.Where(x => x.CourseID == command.CourseID);

                if (command.CompanyID > 0)
                    Query = Query.Where(x => x.CompanyID == command.CompanyID);

                if (command.InstructorID > 0)
                    Query = Query.Where(x => x.InstructorID == command.InstructorID);

                if (!string.IsNullOrWhiteSpace(command.Fullname))
                    Query = Query.Where(x => x.Fullname.Contains(command.Fullname));
            }


            return Query.OrderByDescending(x=>x.RegistrationDate).ToList();
        }

    }
}
