using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.Companies
{
    public class CompanyViewModel
    {
        public long ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string CompanyName { get; set; }
        public string Website { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public IFormFile Logo { get; set; }
        public bool IsPartner { get;  set; }
        public bool IsClient { get;  set; }
        public string FileAddress { get; set; }

    }
}
