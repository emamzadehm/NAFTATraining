using System.Collections.Generic;

namespace _01.Framework.Application
{
    public interface IAuthHelper
    {
        void SignIn(AuthViewModel account);
        void SignOut();
        bool IsAuthenticated();
        List<long> GetPermissions();
        List<string> GetPermissionsTitle();
        List<long> CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();


    }
}
