using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace _01.Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
                return result;

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            result.ID = long.Parse(claims.FirstOrDefault(x => x.Type == "UserId").Value);
            result.Username = claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
            result.Fullname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            result.RolesList = JsonConvert.DeserializeObject<List<long>>(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            result.PermissionsList = JsonConvert.DeserializeObject<List<long>>(claims.FirstOrDefault(x => x.Type == "permissions")?.Value);


            //result.RolesList = JsonConvert.DeserializeObject<List<URolesViewModel>>(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            //result.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            //result.Role = Roles.GetRoleBy(result.RoleId);
            //result.RolesList = claims.Select(x => x.Type == ClaimTypes.Role).ToList();
            //result.RolesList = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value.ToList();
            return result;
        }

        public List<long> GetPermissions()
        {
            if (!IsAuthenticated())
                return new List<long>();

            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissions")
                ?.Value;
            return JsonConvert.DeserializeObject<List<long>>(permissions);
        }

        public List<long> CurrentAccountRole()
        {
            if (IsAuthenticated())
                return new List<long>();
            var roles = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            return JsonConvert.DeserializeObject<List<long>>(roles);

        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            //var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            ////if (claims.Count > 0)
            ////    return true;
            ////return false;
            //return claims.Count > 0;
        }

        public void SignIn(AuthViewModel account)
        {
            //var permissions = JsonConvert.SerializeObject(account.Permissions);
            var roles = JsonConvert.SerializeObject(account.RolesList);
            var permissions = JsonConvert.SerializeObject(account.PermissionsList);
            var permissionsTitle = JsonConvert.SerializeObject(account.PermissionsTitleList);


            var claims = new List<Claim>
            {
                new Claim("UsedId", account.ID.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim(ClaimTypes.Email, account.Username), // Or Use ClaimTypes.NameIdentifier
                new Claim(ClaimTypes.Role, roles),
                new Claim("permissions", permissions),
                new Claim("permissionsTitle", permissionsTitle),


                //new Claim(ClaimTypes.Role, account.RolesList.Select(x => x.RoleID).ToList()),
                //new Claim("permissions", permissions)
            };
            //foreach (var item in account.RolesList)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, item.RoleID.ToString()));
            //}

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public List<string> GetPermissionsTitle()
        {
            if (!IsAuthenticated())
                return new List<string>();

            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissionsTitle")
                ?.Value;
            return JsonConvert.DeserializeObject<List<string>>(permissions);
        }
    }
}
