using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.ViewModels
{
    public class Site_FAQViewModel
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
