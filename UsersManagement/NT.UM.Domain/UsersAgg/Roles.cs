using _01.Framework.Domain;
using System.Collections.Generic;

namespace NT.UM.Domain.UsersAgg
{
    public class Roles : DomainBase
    {
        public string RoleName { get; private set; }
        public string Description { get; private set; }
        public ICollection<UsersRoles> UsersRoless { get; private set; }
        public ICollection<RolePermission> RolePermissions { get; private set; }

        protected Roles()
        {

        }
        public Roles(string rolename, string description)
        {
            RoleName = rolename;
            Description = description;
            UsersRoless = new List<UsersRoles>();
            RolePermissions = new List<RolePermission>();
        }
        public void Edit(string rolename, string description)
        {
            RoleName = rolename;
            Description = description;
        }
    }
}
