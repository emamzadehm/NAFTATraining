using _01.Framework.Domain;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Domain.BaseInfoAgg;
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