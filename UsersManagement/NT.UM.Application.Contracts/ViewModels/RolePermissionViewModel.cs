using _01.Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class RolePermissionViewModel
    {
        public long ID { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long PermissionID { get; set; }
        public string PermissionName { get; set; }
        public bool Status { get; set; }
    }
}
