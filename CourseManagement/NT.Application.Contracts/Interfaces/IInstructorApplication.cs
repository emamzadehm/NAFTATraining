using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.Instructors;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.Interfaces
{
    public interface IInstructorApplication
    {
        OperationResult Create(InstructorsViewModel command);
        OperationResult Edit(InstructorsViewModel command);
        OperationResult Remove(long id);
        InstructorsViewModel GetBy(long id);
        List<InstructorsViewModel> Search(InstructorsViewModel searchmodel = null);
    }
}
