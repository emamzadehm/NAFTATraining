using _01.Framework.Application;
using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using NT.CM.Domain;
using NT.CM.Domain.CourseInstructorAgg;
using NT.UM.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CourseInstructorRepository : BaseRepository<long, CourseInstructor>, ICourseInstructorRepository
    {
        private readonly NTContext _ntcontext;
        private readonly NTUMContext _ntumcontext;

        public CourseInstructorRepository(NTContext ntcontext, NTUMContext ntumcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
            _ntumcontext = ntumcontext;
        }

        public CourseInstructorViewModel GetDetails(long id)
        {
            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.FirstName, x.LastName, x.Sex, x.Email, x.Tel, x.IMG, x.IDCardIMG, x.Password }).ToList();

            var Query = _ntcontext.Tbl_Course_Instructor.Where(x => x.Status == true).Select(listitem => new CourseInstructorViewModel
            {
                ID = listitem.ID,
                CourseID = listitem.CourseID,
                CourseName = listitem.Course.CName,
                Capacity = listitem.Capacity,
                SDate = listitem.SDate,
                EDate = listitem.EDate,
                InstructorID = listitem.InstructorID,
                Location = listitem.Location,
                LocationName = listitem.BaseInfo.Title,
                Venue = listitem.Venue,
                UserID = listitem.Instructor.UserId
            });

            foreach (var instructoruser in Query)
            {
                var user = users.FirstOrDefault(x => x.ID == instructoruser.UserID);
                if (user != null)
                {
                    instructoruser.InstructorName = user.Sex.ToSexName() + " " + user.FirstName + " " + user.LastName;
                }
            };
            return Query.FirstOrDefault(x=>x.ID==id);
        }

        public List<CourseInstructorViewModel> Search(CourseInstructorViewModel command = null)
        {
            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true)
                .Select(x => new { x.ID, x.FirstName, x.LastName, x.Sex, x.Email, x.Tel, x.IMG, x.IDCardIMG, x.Password }).ToList();

            var Query = _ntcontext.Tbl_Course_Instructor.Where(x => x.Status == true)
                .Select(listitem => new CourseInstructorViewModel
            {
                ID = listitem.ID,
                CourseID=listitem.CourseID,
                CourseName=listitem.Course.CName,
                Capacity=listitem.Capacity,
                SDate=listitem.SDate,
                EDate=listitem.EDate,
                InstructorID=listitem.InstructorID,
                Location=listitem.Location,
                LocationName=listitem.BaseInfo.Title,
                Venue=listitem.Venue,
                UserID=listitem.Instructor.UserId,
                CourseInfo = listitem.Course.CName + ", " + listitem.SDate
            }).ToList();

            foreach (var instructoruser in Query)
            {
                var user = users.FirstOrDefault(x => x.ID == instructoruser.UserID);
                if (user != null)
                {
                    instructoruser.InstructorName = user.Sex.ToSexName() + " " + user.FirstName + " " + user.LastName;
                    instructoruser.CourseInfo = instructoruser.CourseInfo + ", " + instructoruser.InstructorName;
                }
            };

            if (command != null)
            {
                if (command.SDate > DateTime.MinValue)
                    Query = Query.Where(x => x.SDate >= command.SDate).ToList();
                if (command.EDate > DateTime.MinValue)
                    Query = Query.Where(x => x.EDate <= command.EDate).ToList();
                if (command.InstructorID > 0)
                    Query = Query.Where(x => x.InstructorID == command.InstructorID).ToList();
                if (command.Location > 0)
                    Query = Query.Where(x => x.Location == command.Location).ToList();
                if (command.CourseID > 0)
                    Query = Query.Where(x => x.CourseID == command.CourseID).ToList();
            }
            
            return Query.OrderBy(x => x.ID).ToList();
        }
    }
}
