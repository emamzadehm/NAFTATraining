using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_ClientAlliance : DomainBase
    {
        public string Name { get; private set; }
        public string Logo { get; private set; }
        public string Type { get; private set; }
        public long Site_Base_Id { get; private set; }
        public Site_Base Sitebases { get; private set; }
        protected Site_ClientAlliance()
        {

        }

        public Site_ClientAlliance(string name, string logo, string type, long site_Base_Id)
        {
            Name = name;
            Logo = logo;
            Type = type;
            Site_Base_Id = site_Base_Id;
        }
        public void Edit(string name, string logo, string type)
        {
            Name = name;
            Logo = logo;
            Type = type;
        }
    }
}
