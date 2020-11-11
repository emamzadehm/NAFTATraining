using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_FAQRepository : IRepository<long, Site_FAQ>
    {
        List<Site_FAQViewModel> Search(Site_FAQViewModel command);
    }
}
