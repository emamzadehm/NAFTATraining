using System.Collections.Generic;

namespace NT.SM.Application.Contracts.ViewModels
{
    public class Site_FacilityViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasBullet { get; set; }
        public string Img { get; set; }
        public long Site_Base_Id { get; set; }
        public List<Site_BaseViewModel> Site_BaseList { get; set; }

    }
}
