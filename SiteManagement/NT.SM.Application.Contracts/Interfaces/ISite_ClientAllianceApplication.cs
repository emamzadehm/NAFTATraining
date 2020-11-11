using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_ClientAllianceApplication
    {
        OperationResult Create(Site_ClientAllianceViewModel command);
        OperationResult Edit(Site_ClientAllianceViewModel command);
        OperationResult Remove(Site_ClientAllianceViewModel command);
        Site_ClientAllianceViewModel GetBy(int id);
        List<Site_ClientAllianceViewModel> Search(Site_ClientAllianceViewModel command);
    }
}
