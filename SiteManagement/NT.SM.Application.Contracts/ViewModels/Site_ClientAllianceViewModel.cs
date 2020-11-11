using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.ViewModels
{
    public class Site_ClientAllianceViewModel
    {
        public long Id { get;  set; }
        public string Name { get;  set; }
        public string Logo { get;  set; }
        public string Type { get;  set; }
        public long Site_Base_Id { get;  set; }
    }
}
