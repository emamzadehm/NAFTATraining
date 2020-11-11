using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_WhyNafta : DomainBase
    {
        public string Description { get; private set; }
        public long Site_Base_Id { get; private set; }
        public Site_Base Sitebases { get; private set; }

        protected Site_WhyNafta()
        {

        }

        public Site_WhyNafta(string description, long site_Base_Id)
        {
            Description = description;
            Site_Base_Id = site_Base_Id;
        }
        public void Edit(string description)
        {
            Description = description;
        }
    }
}
