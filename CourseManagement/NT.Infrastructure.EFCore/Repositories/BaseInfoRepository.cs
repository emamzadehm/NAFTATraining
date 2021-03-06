﻿using _01.Framework.Infrastructure.EFCore;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Domain;
using NT.CM.Domain.BaseInfoAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.CM.Infrastructure.EFCore.Repositories
{
    public class BaseInfoRepository : BaseRepository<long, BaseInfo>, IBaseInfoRepository
    {
        private readonly NTContext _ntcontext;
        public BaseInfoRepository(NTContext ntcontext) : base(ntcontext)
        {
            _ntcontext = ntcontext;
        }

        public List<BaseInfoViewModel> GetAllTypes()
        {
            var Query = _ntcontext
                .Tbl_Base_Info
                .Where(x => x.Status == true)
                .Where(x => x.ParentID == null)
                .Where(x => x.TypeID == null)
                .Select(listitem => new BaseInfoViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
                TypeName = listitem.Type.Title,
                ParentName = listitem.Parent.Title,
                ParentID = listitem.ParentID
            }).ToList();
            return Query;
        }

        public List<BaseInfoViewModel> GetByTypeId(long typeid)
        {
            var Query = _ntcontext
            .Tbl_Base_Info
            .Where(x => x.Status == true)
            .Select(listitem => new BaseInfoViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
                TypeName = listitem.Type.Title,
                ParentName = listitem.Parent.Title,
                ParentID = listitem.ParentID
            }).Where(x=>x.TypeID==typeid);

            return Query.ToList();
        }

        public List<BaseInfoViewModel> Search(BaseInfoViewModel command = null)
        {
            var Query = _ntcontext.Tbl_Base_Info.Where(x => x.Status == true).Select(listitem => new BaseInfoViewModel
            {
                ID = listitem.ID,
                Title = listitem.Title,
                TypeID = listitem.TypeID,
                TypeName = listitem.Type.Title,
                ParentName = listitem.Parent.Title,
                ParentID = listitem.ParentID
            }).ToList();
            if (command!=null)
            {
                if (command.TypeID > 0)
                    Query = Query.Where(x => x.TypeID == command.TypeID).ToList();
                if (!string.IsNullOrWhiteSpace(command.Title))
                    Query = Query.Where(x => x.Title.Contains(command.Title)).ToList();
            }
            return Query.OrderBy(x=>x.ID).ToList();
        }
    }
}
