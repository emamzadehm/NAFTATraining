using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using NT.CM.Domain;
using NT.CM.Domain.InstructorAgg;
using NT.UM.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class InstructorRepository : BaseRepository<long, Instructor>, IInstructorRepository
    {
        private readonly NTContext _ntcontext;
        private readonly NTUMContext _ntumcontext;

        public InstructorRepository(NTContext ntcontext, NTUMContext ntumcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
            _ntumcontext = ntumcontext;
        }

        public InstructorsViewModel GetDetails(long id)
        {
            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.FirstName, x.LastName, x.Sex, x.Email, x.Tel, x.IMG, x.IDCardIMG, x.Password }).ToList();
            var instructors = _ntcontext.Tbl_Instructor
                                .Where(x => x.Status == true)
                                .Select(listitem => new InstructorsViewModel
                                {
                                    ID = listitem.ID,
                                    EducationLevel = listitem.EducationLevel,
                                    Resume = listitem.Resume,
                                    UserID = listitem.UserId
                                }).ToList();

            foreach (var instructor in instructors)
            {
                var userInstructor = users.FirstOrDefault(x => x.ID == instructor.UserID);
                if (userInstructor != null)
                {
                    instructor.UserID = userInstructor.ID;
                    instructor.Fullname = userInstructor.Sex + " " + userInstructor.FirstName + " " + userInstructor.LastName;
                    instructor.Sex = userInstructor.Sex;
                    instructor.FirstName = userInstructor.FirstName;
                    instructor.LastName = userInstructor.LastName;
                    instructor.Email = userInstructor.Email;
                    instructor.Tel = userInstructor.Tel;
                    instructor.IMG = userInstructor.IMG;
                    instructor.IDCardIMG = userInstructor.IDCardIMG;
                    instructor.Password = userInstructor.Password;
                }
            };

            return instructors.FirstOrDefault(x => x.ID == id);
        }

        public List<InstructorsViewModel> Search(InstructorsViewModel command = null)
        {

            var users = _ntumcontext.Tbl_Users.Where(x => x.Status == true).Select(x => new { x.ID, x.FirstName, x.LastName, x.Sex, x.Email, x.Tel, x.IMG, x.IDCardIMG, x.Password }).ToList();
            var instructors = _ntcontext.Tbl_Instructor
                                .Where(x => x.Status == true)
                                .Select(listitem => new InstructorsViewModel
                                {
                                    ID = listitem.ID,
                                    EducationLevel = listitem.EducationLevel,
                                    Resume = listitem.Resume,
                                    UserID = listitem.UserId
                                }).ToList();
            
            foreach (var instructor in instructors)
            {
                var userInstructor = users.FirstOrDefault(x => x.ID == instructor.UserID);
                if (userInstructor != null)
                {
                    instructor.UserID = userInstructor.ID;
                    instructor.Fullname = userInstructor.Sex + " " + userInstructor.FirstName + " " + userInstructor.LastName;
                    instructor.Email = userInstructor.Email;
                    instructor.Tel = userInstructor.Tel;
                    instructor.IMG = userInstructor.IMG;
                    instructor.IDCardIMG = userInstructor.IDCardIMG;
                    instructor.Password = userInstructor.Password;
                }
            };
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Resume))
                    instructors = instructors.Where(x => x.Resume.Contains(command.Resume)).ToList();
            }
            
            return instructors.OrderBy(x => x.ID).ToList();
        }
    }
}
