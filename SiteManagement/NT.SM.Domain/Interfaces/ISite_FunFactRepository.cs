using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_FunFactRepository : IRepository<long, Site_FunFact>
    {
        List<Site_FunFactViewModel> Search(Site_FunFactViewModel command = null);
    }
}
