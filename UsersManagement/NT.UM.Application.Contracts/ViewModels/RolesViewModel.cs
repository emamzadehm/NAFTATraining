using System;
using System.Collections.Generic;
using System.Text;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class RolesViewModel
    {
        public long ID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
