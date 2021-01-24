using _01.Framework.Application;
using _01.Framework.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace NT.Presentation.MVCCore
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _iauthhelper;

        public SecurityPageFilter(IAuthHelper iauthhelper)
        {
            _iauthhelper = iauthhelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {

        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission = (NeedsPermissionAttribute)context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(NeedsPermissionAttribute));
            var userPermissions = _iauthhelper.GetPermissionsTitle();
            if (handlerPermission == null)
            {
                return;
            }
            else
            {
                var handlerPermissionTitle = handlerPermission.Module + "-" + handlerPermission.Section + "-" + handlerPermission.Operation;
                if (!userPermissions.Contains(handlerPermissionTitle))
                {
                    context.HttpContext.Response.Redirect("/Login");
                }

            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {

        }
    }
}
