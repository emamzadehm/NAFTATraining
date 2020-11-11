using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.ViewModels
{
    public class Site_AboutViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Site_Base_Id { get; set; }
    }
}
