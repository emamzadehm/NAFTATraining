using _01.Framework.Application;
using System;
using System.ComponentModel.DataAnnotations;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class UsersRolesViewModel
    {
        public long ID { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long UserID { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleID { get; set; }
        public bool Status { get; set; }
    }
}
