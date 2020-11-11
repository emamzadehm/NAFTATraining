using System.Collections;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.ViewModels
{
    public class CompanyViewModel
    {
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public string? Website { get; set; }
        public byte[]? Logo { get; set; }
        public long TypeID { get; set; }
        public string TypeName { get; set; }
        public List<BaseInfoViewModel> CompanyType { get; set; }
    }
}
