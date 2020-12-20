using _01.Framework.Domain;
using System.Collections.Generic;

namespace NT.UM.Domain.UsersAgg
{
    public class Permission: DomainBase
    {
        public string Title { get; private set; }
        public List<RolePermission> RolePermissions { get; private set; }

        protected Permission()
        {

        }
        public Permission(string title)
        {
            Title = title;
        }
        public void Edit(string title)
        {
            Title = title;
        }
    }
}
