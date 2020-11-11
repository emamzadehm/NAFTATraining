using _01.Framework.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using NT.CM.Application.Contracts.ViewModels.CandidateCourseInstructor;
using NT.CM.Domain;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CandidateCourseInstructorRepository : BaseRepository<long, CandidateCourseInstructor>, ICandidateCourseInstructorRepository
    {
        private readonly NTContext _ntcontext;
        public CandidateCourseInstructorRepository(NTContext ntcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<CandidateCourseInstructorViewModel> Search(CandidateCourseInstructorViewModel command)
        {
            var Query = _ntcontext.Tbl_Candidate_Course_Instructor.Where(x => x.Status == true).Select(listitem => new CandidateCourseInstructorViewModel
            {
                ID = listitem.ID,
                CandidateID=listitem.CandidateID,
                Course_InstructorID=listitem.Course_InstructorID,
                RegistrationDate=listitem.RegistrationDate
            });
            return Query.OrderByDescending(x => x.RegistrationDate).ToList();
        }





        //public CandidateCourseInstructor GetCandidateCourseInstructorBy(int id)
        //{
        //    return _ntcontext
        //                .Tbl_Candidate_Course_Instructor
        //                .Include(x => x.CourseInstructors)
        //                .Include(x => x.Candidates)
        //                .FirstOrDefault(x => x.ID == id);
        //}

        //public List<CourseCandidateViewModel> GetList()
        //{
        //    return _ntcontext
        //        .Tbl_Candidate_Course_Instructor
        //        .Include(x => x.CourseInstructor)
        //        .Include(x => x.Users)
        //        .Select(x => new CourseCandidateViewModel
        //        {
        //            Id = x.ID,
        //            CandidateId = x.CandidateID,
        //            CourseName = x.CourseInstructor.CName,
        //            Fullname = x.Users.FirstName + " " + x.Users.LastName,
        //            Organization = x.Users.Company.,
        //            Tel = x.Candidates.Tel,
        //            Email=x.Candidates.Email
        //        })
        //        .OrderByDescending(x => x.Id)
        //        .ToList();
        //}
    }
}
