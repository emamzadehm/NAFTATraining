using _01.Framework.Domain;
using System.Collections.Generic;

namespace NT.UM.Domain.UsersAgg
{
    public class Role : DomainBase
    {
        public string RoleName { get; private set; }
        public string Description { get; private set; }
        public List<UserRole> UserRoles { get; private set; }
        public List<RolePermission> RolePermissions { get; private set; }

        protected Role()
        {

        }
        public Role(string rolename, string description, List<RolePermission> rolePermissions)
        {
            RoleName = rolename;
            Description = description;
            RolePermissions = rolePermissions;
        }
        public void Edit(string rolename, string description, List<RolePermission> rolePermissions)
        {
            RoleName = rolename;
            Description = description;
            RolePermissions = rolePermissions;
        }
    }
}
