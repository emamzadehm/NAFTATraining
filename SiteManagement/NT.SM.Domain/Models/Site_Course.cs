using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_Course : DomainBase
    {
        public string Icon { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public long Site_Base_Id { get; private set; }
        public Site_Base Sitebases { get; private set; }
        protected Site_Course()
        {

        }
        public Site_Course(string icon, string title, string description, long site_Base_Id)
        {
            Icon = icon;
            Title = title;
            Description = description;
            Site_Base_Id = site_Base_Id;
        }
        public void Edit(string icon, string title, string description)
        {
            Icon = icon;
            Title = title;
            Description = description;
        }
    }
}
