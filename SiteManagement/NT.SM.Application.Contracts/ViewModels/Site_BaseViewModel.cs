using System;

namespace NT.SM.Application.Contracts.ViewModels
{
    public class Site_BaseViewModel
    {
        public long Id { get;  set; }
        public string MainTitle { get;  set; }
        public string MainDescription { get;  set; }
        public bool Status { get;  set; }
        public DateTime CreationDate { get;  set; }

    }
}
