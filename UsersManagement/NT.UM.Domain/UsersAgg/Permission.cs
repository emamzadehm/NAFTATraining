using _01.Framework.Domain;
using System.Collections.Generic;

namespace NT.UM.Domain.UsersAgg
{
    public class Permission: DomainBase
    {
        public string Title { get; private set; }
        public long TypeId { get; private set; }
        public long? ParentId { get; private set; }
        public Permission permission { get; private set; }
        public ICollection<Permission> Permissions { get; private set; }
        public List<RolePermission> RolePermissions { get; private set; }

        protected Permission()
        {

        }
        public Permission(string title, long typeId, long? parentID)
        {
            Title = title;
            ParentId = parentID;
            TypeId = typeId;
        }
        public void Edit(string title, long typeId, long? parentID)
        {
            Title = title;
            ParentId = parentID;
            TypeId = typeId;
        }
    }
}
