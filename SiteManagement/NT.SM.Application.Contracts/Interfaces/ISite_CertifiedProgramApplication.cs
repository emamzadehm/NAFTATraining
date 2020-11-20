using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_CertifiedProgramApplication
    {
        OperationResult Create(Site_CertifiedProgramViewModel command);
        OperationResult Edit(Site_CertifiedProgramViewModel command);
        OperationResult Remove(long id);
        Site_CertifiedProgramViewModel GetBy(long id);
        List<Site_CertifiedProgramViewModel> Search(Site_CertifiedProgramViewModel command);
    }
}
