using _01.Framework.Application;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.BaseInfo
{
    public class BaseInfoViewModel
    {
        
        public long ID { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }
        public long? TypeID { get; set; }
        public string TypeName { get; set; }
        public long? ParentID { get; set; }
        public string ParentName { get; set; }
        public bool Status { get; set; }
        public List<BaseInfoViewModel> Parent { get; set; }
        public List<BaseInfoViewModel> Types { get; set; }


    }
}
