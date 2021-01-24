using _01.Framework.Infrastructure.EFCore;
using NT.UM.Application.Contracts.Interfaces;
using NT.UM.Application.Contracts.ViewModels;
using NT.UM.Domain;
using NT.UM.Domain.UsersAgg;
using System.Collections.Generic;
using System.Linq;

namespace NT.UM.Infrastructure.EFCore.Repositories
{
    public class PermissionsRepository : BaseRepository<long, Permission>, IPermissionsRepository
    {
        private readonly NTUMContext _ntumcontext;
        private readonly IPermissionTypes _ipermissionTypes;

        public PermissionsRepository(NTUMContext ntumcontext, IPermissionTypes ipermissionTypes) : base(ntumcontext)
        {
            _ntumcontext = ntumcontext;
            _ipermissionTypes = ipermissionTypes;
        }


        //public  List<PermissionsViewModel> GetPermissionsByModule(long id=0)
        //{
        //    var ItemValue = (_ipermissionTypes.Expose().FirstOrDefault(x => x.Title == "Module").Id);

        //    return _ntumcontext.Tbl_Permissions
        //        .Where(x => x.Status == true)
        //        .Where(x => x.TypeId != ItemValue)
        //        //.Where(x => x.ParentId == id)
        //        .Select(x => new PermissionsViewModel
        //        {
        //            ID = x.ID,
        //            Title = x.Title,
        //            Status = x.Status,
        //            ParentId = x.ParentId,
        //            OperationsList = MappedOperations(id)
        //        }).ToList();
        //}

        public Dictionary<long?,List<PermissionsViewModel>> GetPermissionsByModule(long id = 0)
        {
            var ItemValue = (_ipermissionTypes.Expose().FirstOrDefault(x => x.Title == "Operation").Id);

            var permissionbymodule = _ntumcontext.Tbl_Permissions
                .Where(x => x.Status == true && x.TypeId == ItemValue)
                //.Where(x => x.ParentId == id)
                .Select(x => new PermissionsViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    Status = x.Status,
                    ParentId = x.ParentId,
                    ParentTitle=x.permission.Title,
                    TypeId=x.TypeId,
                    //OperationsList = MappedOperations(id)
                }).AsEnumerable().GroupBy(x => x.ParentId).ToList();

            return permissionbymodule.ToDictionary(k => k.Key, v => v.ToList());
        }
        //private List<PermissionsViewModel> MappedOperations(long id)
        //{
        //    var ItemValue = (_ipermissionTypes.Expose().FirstOrDefault(x => x.Title == "Operation").Id);

        //    return _ntumcontext.Tbl_Permissions
        //            .Where(x => x.Status == true && x.TypeId == ItemValue)
        //            .Where(x => x.ParentId == id)
        //        .Select(x => new PermissionsViewModel
        //        {
        //            ID = x.ID,
        //            Title = x.Title
        //        }).ToList();
        //}

        public PermissionsViewModel GetDetails(long? id)
        {
            return _ntumcontext.Tbl_Permissions.Where(x => x.Status == true).Select(x => new PermissionsViewModel
            {
                ID = x.ID,
                Title = x.Title,
                Status = x.Status
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<PermissionsViewModel> GetAllModules()
        {
            var ItemValue = (_ipermissionTypes.Expose().FirstOrDefault(x => x.Title == "Module").Id);
            return _ntumcontext.Tbl_Permissions
                .Where(x => x.Status == true)
                //.Where(x => x.ParentId == null)
                .Where(x => x.TypeId == ItemValue)
                .Select(x => new PermissionsViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    Status = x.Status
                }).ToList();
        }

        public List<PermissionsViewModel> Search(PermissionsViewModel command = null)
        {
            var ItemValue = (_ipermissionTypes.Expose().FirstOrDefault(x => x.Title == "Operation").Id);

            var Query = _ntumcontext.Tbl_Permissions
                .Where(x => x.Status == true && x.TypeId == ItemValue)
                .Select(x => new PermissionsViewModel
            {
                ID = x.ID,
                Title = "عملیات " + x.Title + " در بخش " +  x.permission.Title + " در ماژول " + x.permission.permission.Title,
                Status = x.Status
            });
            //if (command != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(command.Title))
            //        Query = Query.Where(x => x.Title.Contains(command.Title));
            //}


              return Query.ToList();
        }

        public List<PermissionsViewModel> GetPermissionOperationByType(long id)
        {
            var ItemValue = (_ipermissionTypes.Expose().FirstOrDefault(x => x.Id == id).ParentId);
            var result = _ntumcontext.Tbl_Permissions
                .Where(x => x.Status == true && x.TypeId == ItemValue & x.TypeId!=0)
                .Select(x => new PermissionsViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    TypeId=x.TypeId,
                    Status = x.Status
                }).ToList();

            return result;
        }
    }
}
