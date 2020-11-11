using _01.Framework.Infrastructure.EFCore;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Interfaces;
using NT.SM.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace NT.SM.Infrastructure.EFCore.Repository
{
    public class Site_ClientAllianceRepository : BaseRepository<long, Site_ClientAlliance>, ISite_ClientAllianceRepository
    {
        private readonly NTSMContext _smcontext;
        public Site_ClientAllianceRepository(NTSMContext smcontext) : base(smcontext)
        {
            _smcontext = smcontext;
        }

        public List<Site_ClientAllianceViewModel> Search(Site_ClientAllianceViewModel command)
        {
            var Query = _smcontext.Tbl_Site_ClientAlliance.Where(x => x.Status == true).Select(x => new Site_ClientAllianceViewModel
            {
                Id = x.ID,
                Name=x.Name,
                Logo = x.Logo,
                Type = x.Type,
                Site_Base_Id = x.Site_Base_Id
            });
            if (!string.IsNullOrWhiteSpace(command.Name))
                Query = Query.Where(x => x.Name.Contains(command.Name));

            return Query.ToList();
        }
    }
}
