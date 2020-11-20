using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.CourseInstructor;
using NT.CM.Domain;
using NT.CM.Domain.CourseInstructorAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class CourseInstructorRepository : BaseRepository<long, CourseInstructor>, ICourseInstructorRepository
    {
        private readonly NTContext _ntcontext;

        public CourseInstructorRepository(NTContext ntcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
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
                InstructorName = listitem.Instructor.ID.ToString(),
                //InstructorName=listitem.Instructor.FirstName + " " + listitem.Instructor.LastName,
                Location = listitem.Location,
                LocationName = listitem.BaseInfo.Title,
                Venue = listitem.Venue
            }).FirstOrDefault(x=>x.ID==id);
        }

        public List<CourseInstructorViewModel> Search(CourseInstructorViewModel command)
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
                InstructorName=listitem.Instructor.ID.ToString(),
                //InstructorName=listitem.Instructor.FirstName + " " + listitem.Instructor.LastName,
                Location=listitem.Location,
                LocationName=listitem.BaseInfo.Title,
                Venue=listitem.Venue
            });
            if (command.SDate > DateTime.MinValue)
                Query = Query.Where(x => x.SDate >= command.SDate);
            if (command.EDate > DateTime.MinValue)
                Query = Query.Where(x => x.EDate <= command.EDate);
            if (command.InstructorID >0)
                Query = Query.Where(x => x.InstructorID == command.InstructorID);
            if (command.Location > 0)
                Query = Query.Where(x => x.Location == command.Location);
            if (command.CourseID > 0)
                Query = Query.Where(x => x.CourseID == command.CourseID);
            return Query.OrderBy(x => x.ID).ToList();
        }
    }
}
