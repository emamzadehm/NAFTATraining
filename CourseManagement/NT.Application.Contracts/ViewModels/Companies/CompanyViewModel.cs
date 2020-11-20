using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using System.Collections.Generic;
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
        public string Logo { get; set; }
        public bool IsPartner { get;  set; }
        public bool IsClient { get;  set; }
    }
}
