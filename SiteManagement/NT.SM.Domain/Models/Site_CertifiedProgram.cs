using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_CertifiedProgram : DomainBase
    {
        public string Logo { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public long Site_Base_Id { get; private set; }
        public Site_Base Sitebases { get; private set; }
        protected Site_CertifiedProgram()
        {

        }

        public Site_CertifiedProgram(string logo, string title, string shortDescription, string description, long site_Base_Id)
        {
            Logo = logo;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Site_Base_Id = site_Base_Id;
        }
        public void Edit(string logo, string title, string shortDescription, string description)
        {
            Logo = logo;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;        }
    }
}
