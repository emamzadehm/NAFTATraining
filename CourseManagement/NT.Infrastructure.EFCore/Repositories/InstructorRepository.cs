using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using NT.CM.Domain;
using NT.CM.Domain.InstructorAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class InstructorRepository : BaseRepository<long, Instructor>, IInstructorRepository
    {
        private readonly NTContext _ntcontext;
        public InstructorRepository(NTContext ntcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<InstructorsViewModel> Search(InstructorsViewModel command)
        {
            var Query = _ntcontext.Tbl_Instructor.Where(x => x.Status == true).Select(listitem => new InstructorsViewModel
            {
                ID=listitem.ID,
                //FirstName= listitem.FirstName,
                //LastName=listitem.LastName,
                //Sex=listitem.Sex,
                //Email=listitem.Email,
                //IDCardIMG=listitem.IDCardIMG,
                //IMG=listitem.IMG,
                //Tel=listitem.Tel,
                //Password=listitem.Password,
                EducationLevel = listitem.EducationLevel,
                Resume=listitem.Resume
            });
            if (!string.IsNullOrWhiteSpace(command.LastName))
                Query = Query.Where(x => x.LastName.Contains(command.LastName));
            return Query.OrderBy(x => x.ID).ToList();
        }
    }
}
