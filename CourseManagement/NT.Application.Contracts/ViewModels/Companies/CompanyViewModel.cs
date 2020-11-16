using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.ViewModels.Companies
{
    public class CompanyViewModel
    {
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public string? Website { get; set; }
        public byte[]? Logo { get; set; }
        public bool IsPartner { get;  set; }
        public bool IsClient { get;  set; }
    }
}
