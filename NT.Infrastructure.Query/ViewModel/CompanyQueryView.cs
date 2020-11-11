using System;
using System.Collections.Generic;
using System.Text;

namespace NT.Infrastructure.Query.ViewModel
{
    public class CompanyQueryView
    {
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public string? Website { get; set; }
        public byte[]? Logo { get; set; }
        public long TypeID { get; set; }
        public string TypeName { get; set; }
        public List<BaseInfoQueryView> CompanyType { get; set; }
    }
}
