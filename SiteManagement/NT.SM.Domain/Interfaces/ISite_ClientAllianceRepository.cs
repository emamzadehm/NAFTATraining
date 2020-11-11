using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_ClientAllianceRepository : IRepository<long, Site_ClientAlliance>
    {
        List<Site_ClientAllianceViewModel> Search(Site_ClientAllianceViewModel command);

    }
}
