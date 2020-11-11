using _01.Framework.Domain;

namespace NT.UM.Domain.UsersAgg
{
    public class RolePermission : DomainBase
    {
        public long RoleID { get; private set; }
        public Roles Roles { get; private set; }
        public long PermissionID { get; private set; }
        public Permissions Permissions { get; private set; }
        protected RolePermission()
        {

        }
        public RolePermission(long roleid, long permissionid)
        {
            RoleID = roleid;
            PermissionID = permissionid;
        }
        public void Edit(long roleid, long permissionid)
        {
            RoleID = roleid;
            PermissionID = permissionid;
        }
    }
}
