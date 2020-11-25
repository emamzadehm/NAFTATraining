using _01.Framework.Application;
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
            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.Sex, x.FirstName, x.LastName }).ToList();


            var candidateCourseInstructors = _ntcontext.Tbl_Candidate_Course_Instructor
                .Where(x => x.Status == true)
                .Where(x => x.CourseInstructors.Status == true)
                .Select(listitem => new CandidateCourseInstructorViewModel
                {
                    ID = listitem.ID,
                    CandidateID = listitem.CandidateID,
                    CourseID = listitem.CourseInstructors.CourseID,
                    InstructorID = listitem.CourseInstructors.InstructorID,
                    Course_InstructorID = listitem.Course_InstructorID,
                    CandidateUserID = listitem.Candidates.UserId,
                    InstructorUserID = listitem.CourseInstructors.Instructor.UserId,
                    CourseName = listitem.CourseInstructors.Course.CName,
                    RegistrationDate = listitem.RegistrationDate,
                    CompanyID = listitem.Candidates.CompanyID,
                    CompanyName = listitem.Candidates.Company.CompanyName,
                    SDate = listitem.CourseInstructors.SDate,
                    EDate = listitem.CourseInstructors.EDate,
                    Venue = listitem.CourseInstructors.Venue,
                    Location = listitem.CourseInstructors.Location,
                    LocationName = listitem.CourseInstructors.BaseInfo.Title
                }).FirstOrDefault(x => x.ID == id);

            var userinstructor = users.FirstOrDefault(x => x.ID == candidateCourseInstructors.InstructorUserID);
            if (userinstructor != null)
            {
                candidateCourseInstructors.InstructorName = userinstructor.Sex.ToSexName() + " " + userinstructor.FirstName + " " + userinstructor.LastName;
            };

            var usercandidate = users.FirstOrDefault(x => x.ID == candidateCourseInstructors.CandidateUserID);
            if (usercandidate != null)
            {
                candidateCourseInstructors.Fullname = usercandidate.Sex.ToSexName() + " " + usercandidate.FirstName + " " + usercandidate.LastName;
            };

            return candidateCourseInstructors;
        }

        public List<CandidateCourseInstructorViewModel> GetRegisteredCandidates(long courseinstructorid)
        {
            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.Sex, x.FirstName, x.LastName }).ToList();


            var candidateCourseInstructors = _ntcontext.Tbl_Candidate_Course_Instructor
                .Where(x => x.Status == true)
                .Where(x => x.CourseInstructors.Status == true)
                .Select(listitem => new CandidateCourseInstructorViewModel
                {
                    ID = listitem.ID,
                    CandidateID = listitem.CandidateID,
                    CourseID = listitem.CourseInstructors.CourseID,
                    InstructorID = listitem.CourseInstructors.InstructorID,
                    Course_InstructorID = listitem.Course_InstructorID,
                    CandidateUserID = listitem.Candidates.UserId,
                    InstructorUserID = listitem.CourseInstructors.Instructor.UserId,
                    CourseName = listitem.CourseInstructors.Course.CName,
                    RegistrationDate = listitem.RegistrationDate,
                    CompanyID = listitem.Candidates.CompanyID,
                    CompanyName = listitem.Candidates.Company.CompanyName,
                    SDate = listitem.CourseInstructors.SDate,
                    EDate = listitem.CourseInstructors.EDate,
                    Venue = listitem.CourseInstructors.Venue,
                    Location = listitem.CourseInstructors.Location,
                    LocationName = listitem.CourseInstructors.BaseInfo.Title
                }).Where(x => x.Course_InstructorID == courseinstructorid).ToList();

            foreach (var candidateCourseInstructor in candidateCourseInstructors)
            {
                var user = users.FirstOrDefault(x => x.ID == candidateCourseInstructor.InstructorUserID);
                if (user != null)
                {
                    candidateCourseInstructor.InstructorName = user.Sex.ToSexName() + " " + user.FirstName + " " + user.LastName;
                }
            };

            foreach (var candidateCourseInstructorsitem in candidateCourseInstructors)
            {
                var user = users.FirstOrDefault(x => x.ID == candidateCourseInstructorsitem.CandidateUserID);
                if (user != null)
                {
                    candidateCourseInstructorsitem.Fullname = user.Sex.ToSexName() + " " + user.FirstName + " " + user.LastName;
                }
            };

            return candidateCourseInstructors.ToList();
        }

        public List<CandidateCourseInstructorViewModel> Search(CandidateCourseInstructorViewModel command = null)
        {
            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.Sex, x.FirstName, x.LastName }).ToList();
            var candidateCourseInstructors = _ntcontext.Tbl_Candidate_Course_Instructor
                .Where(x => x.Status == true)
                .Where(x => x.CourseInstructors.Status == true)
                .Select(listitem => new CandidateCourseInstructorViewModel
                {
                    ID = listitem.ID,
                    CandidateID = listitem.CandidateID,
                    CourseID = listitem.CourseInstructors.CourseID,
                    InstructorID = listitem.CourseInstructors.InstructorID,
                    Course_InstructorID = listitem.Course_InstructorID,
                    InstructorUserID = listitem.CourseInstructors.Instructor.UserId,
                    CandidateUserID = listitem.Candidates.UserId,
                    CourseName = listitem.CourseInstructors.Course.CName,
                    RegistrationDate = listitem.RegistrationDate,
                    CompanyID = listitem.Candidates.CompanyID,
                    CompanyName = listitem.Candidates.Company.CompanyName,
                    SDate = listitem.CourseInstructors.SDate,
                    EDate = listitem.CourseInstructors.EDate,
                    Venue = listitem.CourseInstructors.Venue,
                    Location = listitem.CourseInstructors.Location,
                    LocationName = listitem.CourseInstructors.BaseInfo.Title
                }).ToList();

            foreach (var candidateCourseInstructor in candidateCourseInstructors)
            {
                var user = users.FirstOrDefault(x => x.ID == candidateCourseInstructor.InstructorUserID);
                if (user != null)
                {
                    candidateCourseInstructor.InstructorName = user.Sex.ToSexName() + " " + user.FirstName + " " + user.LastName;
                }
            };

            foreach (var candidateCourseInstructorsitem in candidateCourseInstructors)
            {
                var user = users.FirstOrDefault(x => x.ID == candidateCourseInstructorsitem.CandidateUserID);
                if (user != null)
                {
                    candidateCourseInstructorsitem.Fullname = user.Sex.ToSexName() + " " + user.FirstName + " " + user.LastName;
                }
            };


            if (command != null)
            {
                if (command.CourseID > 0)
                    candidateCourseInstructors = candidateCourseInstructors.Where(x => x.CourseID == command.CourseID).ToList();

                if (command.CompanyID > 0)
                    candidateCourseInstructors = candidateCourseInstructors.Where(x => x.CompanyID == command.CompanyID).ToList();

                if (command.InstructorID > 0)
                    candidateCourseInstructors = candidateCourseInstructors.Where(x => x.InstructorID == command.InstructorID).ToList();

                if (!string.IsNullOrWhiteSpace(command.Fullname))
                    candidateCourseInstructors = candidateCourseInstructors.Where(x => x.Fullname.Contains(command.Fullname)).ToList();
            };


            return candidateCourseInstructors.OrderByDescending(x => x.RegistrationDate).ToList();
        }
    }
}
