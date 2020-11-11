using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System.Collections.Generic;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_WhyNaftaRepository : IRepository<long, Site_WhyNafta>
    {
        List<Site_WhyNaftaViewModel> Search(Site_WhyNaftaViewModel command);
    }
}
