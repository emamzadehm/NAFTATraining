using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_About : DomainBase
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public long Site_Base_Id { get; private set; }
        public Site_Base Sitebases { get; private set; }

        protected Site_About()
        {

        }

        public Site_About(string title, string description, long site_Base_Id)
        {
            Title = title;
            Description = description;
            Site_Base_Id = site_Base_Id;
        }
        public void Edit(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
