using _01.Framework.Application;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class PermissionsViewModel
    {
        public long ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }
        public long TypeId { get; set; }
        public long? ParentId { get; set; }
        public string ParentTitle { get; set; }

        public List<PermissionsViewModel> ParentList { get; set; }
        public List<PermissionsViewModel> OperationsList { get; set; }
        //public List<PermissionTypes.PermissionTypesList> PermissionTypesList { get; set; }
        public List<PermissionTypesDto> PermissionTypesList { get; set; }
        public bool Status { get; set; }
    }
}
