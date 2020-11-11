using _01.Framework.Domain;
using System;


namespace NT.UM.Domain.UsersAgg
{
    public class UsersRoles: DomainBase
    {
        public long UserID { get; private set; }
        public Users Users { get; private set; }
        public long RoleID { get; private set; }
        public Roles Roles { get; private set; }

        protected UsersRoles()
        {

        }
        public UsersRoles(long userid, long roleid)
        {
            UserID = userid;
            RoleID = roleid;
        }
        public void Edit(long userid, long roleid)
        {
            UserID = userid;
            RoleID = roleid;
        }
    }
}
