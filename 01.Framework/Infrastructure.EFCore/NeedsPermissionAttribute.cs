using System;

namespace _01.Framework.Infrastructure.EFCore
{
    public class NeedsPermissionAttribute : Attribute
    {
        public string Module { get; set; }
        public string Section { get; set; }
        public string Operation { get; set; }

        public NeedsPermissionAttribute(string module, string section, string operation)
        {
            Module = module;
            Section = section;
            Operation = operation;
        }
    }
}
