using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_AboutRepository : IRepository<long, Site_About>
    {
        List<Site_AboutViewModel> Search(Site_AboutViewModel command);

    }
}
