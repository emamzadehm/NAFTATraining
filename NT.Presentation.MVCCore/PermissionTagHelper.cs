using _01.Framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace NT.Presentation.MVCCore
{
    [HtmlTargetElement(Attributes = "PermissionTitle")]

    public class PermissionTagHelper : TagHelper
    {
        public string PermissionTitle { get; set; }
        private readonly IAuthHelper _iauthhelper;

        public PermissionTagHelper(IAuthHelper iauthhelper)
        {
            _iauthhelper = iauthhelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_iauthhelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }
            var permissionsTitle = _iauthhelper.GetPermissionsTitle();
            var TagHelperValue = output.Attributes.FirstOrDefault(attribute => attribute.Name == "PermissionTitle");
            if (!permissionsTitle.Any(x => x == TagHelperValue.Value.ToString()))
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}
