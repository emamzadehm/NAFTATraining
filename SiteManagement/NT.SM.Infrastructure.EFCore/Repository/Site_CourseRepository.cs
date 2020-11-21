using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_CourseRepository : BaseRepository<long, Site_Course>, ISite_CourseRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_CourseRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_CourseViewModel> Search(Site_CourseViewModel command=null)
        {
            var Query = _smcontext.Tbl_Site_Course.Where(x => x.Status == true).Select(x => new Site_CourseViewModel
            {
                Id = x.ID,
                Icon=x.Icon,
                Title=x.Title,
                Description=x.Description,
                Site_Base_Id = x.Site_Base_Id
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Description))
                    Query = Query.Where(x => x.Description.Contains(command.Description));
            }
            
            return Query.ToList();
        }
    }
}
