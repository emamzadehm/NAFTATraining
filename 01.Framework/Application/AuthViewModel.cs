using System.Collections.Generic;

namespace _01.Framework.Application
{
    public class AuthViewModel
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public List<URolesViewModel> RolesList { get; set; }
        public AuthViewModel()
        {

        }

        public AuthViewModel(long iD, string username, string fullname, List<URolesViewModel> rolesList)
        {
            ID = iD;
            Username = username;
            Fullname = fullname;
            RolesList = rolesList;
        }
    }
}