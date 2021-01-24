using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.UM.Application.Contracts.Interfaces
{
    public interface IPermissionTypes
    {
        List<PermissionTypesDto> Expose();
    }
}
