using System;
using System.Collections.Generic;
using System.Text;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class RolePermissionViewModel
    {
        public long ID { get; set; }
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        public long PermissionID { get; set; }
        public string PermissionName { get; set; }
        public bool Status { get; set; }
    }
}
