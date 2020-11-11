using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_BaseRepository : IRepository<long, Site_Base>
    {
        List<Site_BaseViewModel> Search(Site_BaseViewModel command);

    }
}
