using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_FacilityRepository : BaseRepository<long, Site_Facility>, ISite_FacilityRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_FacilityRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_FacilityViewModel> Search(Site_FacilityViewModel command)
        {
            var Query = _smcontext.Tbl_Site_Facility.Where(x => x.Status == true).Select(x => new Site_FacilityViewModel
            {
                Id = x.ID,
                Title = x.Title,
                Description = x.Description,
                HasBullet=x.HasBullet,
                Img=x.Img,
                Site_Base_Id = x.Site_Base_Id
            });
            if (!string.IsNullOrWhiteSpace(command.Description))
                Query = Query.Where(x => x.Description.Contains(command.Description));

            return Query.ToList();
        }
    }
}
