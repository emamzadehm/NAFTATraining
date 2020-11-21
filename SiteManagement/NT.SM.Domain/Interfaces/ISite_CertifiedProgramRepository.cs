using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_CertifiedProgramRepository : IRepository<long, Site_CertifiedProgram>
    {
        List<Site_CertifiedProgramViewModel> Search(Site_CertifiedProgramViewModel command = null);
    }
}
