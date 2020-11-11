using _01.Framework.Domain;
using System.Collections.Generic;

namespace NT.UM.Domain.UsersAgg
{
    public class Permissions: DomainBase
    {
        public string Title { get; private set; }
        public ICollection<RolePermission> RolePermissions { get; private set; }

        protected Permissions()
        {

        }
        public Permissions(string title)
        {
            Title = title;
            RolePermissions = new List<RolePermission>();

        }
        public void Edit(string title)
        {
            Title = title;
        }
    }
}
