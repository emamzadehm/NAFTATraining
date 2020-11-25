using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_CertifiedProgramRepository : BaseRepository<long, Site_CertifiedProgram>, ISite_CertifiedProgramRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_CertifiedProgramRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_CertifiedProgramViewModel> Search(Site_CertifiedProgramViewModel command=null)
        {
            var Query = _smcontext.Tbl_Site_CertifiedProgram.Where(x => x.Status == true).Select(x => new Site_CertifiedProgramViewModel
            {
                Id = x.ID,
                Title=x.Title,
                Description=x.Description,
                FileAddress=x.Logo,
                ShortDescription=x.ShortDescription,
                Site_Base_Id=x.Site_Base_Id
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
