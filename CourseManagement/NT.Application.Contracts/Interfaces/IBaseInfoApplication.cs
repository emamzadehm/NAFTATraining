using _01.Framework.Application;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.Interfaces
{
    public interface IBaseInfoApplication
    {
        OperationResult Create(BaseInfoViewModel command);
        OperationResult Edit(BaseInfoViewModel command);
        OperationResult Remove(long id);
        BaseInfoViewModel GetBy(long id);
        List<BaseInfoViewModel> Search(BaseInfoViewModel searchmodel);
        List<BaseInfoViewModel> GetAll();
        List<BaseInfoViewModel> GetAllTypes();

        List<BaseInfoViewModel> GetByTypeId(long typeid);
    }
}
