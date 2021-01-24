using System.Collections.Generic;

namespace _01.Framework.Application
{
    public class AuthViewModel
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        //public List<URolesPermissionsViewModel> RolesList { get; set; }
        //public List<URolesPermissionsViewModel> PermissionsList { get; set; }
        public List<long> RolesList { get; set; }
        public List<long> PermissionsList { get; set; }
        public List<string> PermissionsTitleList { get; set; }


        public AuthViewModel()
        {

        }

        public AuthViewModel(long iD, string username, string fullname, List<long> rolesList,
                List<long> permissionsList, List<string> permissionsTitleList)
        {
            ID = iD;
            Username = username;
            Fullname = fullname;
            RolesList = rolesList;
            PermissionsList = permissionsList;
            PermissionsTitleList = permissionsTitleList;
        }
    }
}