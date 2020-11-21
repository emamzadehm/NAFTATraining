using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_FacilityApplication
    {
        OperationResult Create(Site_FacilityViewModel command);
        OperationResult Edit(Site_FacilityViewModel command);
        OperationResult Remove(long id);
        Site_FacilityViewModel GetBy(long id);
        List<Site_FacilityViewModel> Search(Site_FacilityViewModel command = null);
    }
}
