using _01.Framework.Domain;
using NT.SM.Application.Contracts.ViewModels;
using NT.SM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Interfaces
{
    public interface ISite_EvaluationResultRepository : IRepository<long, Site_EvaluationResult>
    {
        List<Site_EvaluationResultViewModel> Search(Site_EvaluationResultViewModel command);
    }
}