using _01.Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class PermissionsViewModel
    {
        public long ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
