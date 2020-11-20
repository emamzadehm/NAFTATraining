using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using NT.CM.Domain.InstructorAgg;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface IInstructorRepository : IRepository<long, Instructor>
    {
        List<InstructorsViewModel> Search(InstructorsViewModel command);
        InstructorsViewModel GetDetails(long id);
    }
}
