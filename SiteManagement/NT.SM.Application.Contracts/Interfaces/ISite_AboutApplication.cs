﻿using _01.Framework.Application;
using NT.SM.Application.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Application.Contracts.Interfaces
{
    public interface ISite_AboutApplication
    {
        OperationResult Create(Site_AboutViewModel command);
        OperationResult Edit(Site_AboutViewModel command);
        OperationResult Remove(long id);
        Site_AboutViewModel GetBy(long id);
        List<Site_AboutViewModel> Search(Site_AboutViewModel command = null);
    }
}
