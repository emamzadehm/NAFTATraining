using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using System.Collections.Generic;

namespace NT.UM.Application
{
    public class PermissionTypes : IPermissionTypes
    {
        public List<PermissionTypesDto> Expose()
        {
            List<PermissionTypesDto> list = new List<PermissionTypesDto>
            {
                new PermissionTypesDto(1 , "Module", 0),
                new PermissionTypesDto(2 , "Section", 1),
                new PermissionTypesDto(3 , "Operation", 2)
            };
            return list;
        }

        //public List<PermissionTypesDto> PTList()
        //{

        //}
    }
}