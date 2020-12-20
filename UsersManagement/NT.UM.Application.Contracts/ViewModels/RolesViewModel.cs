using _01.Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class RolesViewModel
    {
        public long ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Granted { get; set; }
        public bool Status { get; set; }
    }
}
