using System;
using System.Collections.Generic;
using System.Text;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class UsersRolesViewModel
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long RoleID { get; set; }
        public bool Status { get; set; }
    }
}
