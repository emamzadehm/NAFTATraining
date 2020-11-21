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
            return _ntcontext.Tbl_Course_Instructor.Where(x => x.Status == true).Select(listitem => new CourseInstructorViewModel
            {
                ID = listitem.ID,
                CourseID = listitem.CourseID,
                CourseName = listitem.Course.CName,
                Capacity = listitem.Capacity,
                SDate = listitem.SDate,
                EDate = listitem.EDate,
                InstructorID = listitem.InstructorID,
                InstructorName = MaptoUser(listitem.Instructor.UserId),
                Location = listitem.Location,
                LocationName = listitem.BaseInfo.Title,
                Venue = listitem.Venue
            }).FirstOrDefault(x=>x.ID==id);
        }

        public List<CourseInstructorViewModel> Search(CourseInstructorViewModel command = null)
        {
            var Query = _ntcontext.Tbl_Course_Instructor.Where(x => x.Status == true).Select(listitem => new CourseInstructorViewModel
            {
                ID = listitem.ID,
                CourseID=listitem.CourseID,
                CourseName=listitem.Course.CName,
                Capacity=listitem.Capacity,
                SDate=listitem.SDate,
                EDate=listitem.EDate,
                InstructorID=listitem.InstructorID,
                InstructorName= MaptoUser(listitem.Instructor.UserId),
                Location=listitem.Location,
                LocationName=listitem.BaseInfo.Title,
                Venue=listitem.Venue,
                CourseInfo= listitem.Course.CName + "," + MaptoUser(listitem.Instructor.UserId) + "," + listitem.SDate
            });

            if (command != null)
            {
                if (command.SDate > DateTime.MinValue)
                    Query = Query.Where(x => x.SDate >= command.SDate);
                if (command.EDate > DateTime.MinValue)
                    Query = Query.Where(x => x.EDate <= command.EDate);
                if (command.InstructorID > 0)
                    Query = Query.Where(x => x.InstructorID == command.InstructorID);
                if (command.Location > 0)
                    Query = Query.Where(x => x.Location == command.Location);
                if (command.CourseID > 0)
                    Query = Query.Where(x => x.CourseID == command.CourseID);
            }
            
            return Query.OrderBy(x => x.ID).ToList();
        }

        private string MaptoUser(long userId)
        {
            var selecteduser = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.Sex, x.FirstName, x.LastName }).FirstOrDefault(x => x.ID == userId);
            return selecteduser.Sex + " " + selecteduser.FirstName + " " + selecteduser.LastName;
        }
    }
}
