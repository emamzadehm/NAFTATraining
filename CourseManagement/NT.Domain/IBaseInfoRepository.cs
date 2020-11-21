using _01.Framework.Domain;
using Domain.BaseInfoAgg;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using System.Collections.Generic;

namespace NT.CM.Domain
{
    public interface IBaseInfoRepository : IRepository<long ,BaseInfo>
    {
        List<BaseInfoViewModel> Search(BaseInfoViewModel command = null);
        List<BaseInfoViewModel> GetAllTypes();
        List<BaseInfoViewModel> GetByTypeId(long typeid);
    }
}