using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.ViewModels
{
    public class Site_CourseViewModel
    {
        public long Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Site_Base_Id { get; set; }
    }
}
