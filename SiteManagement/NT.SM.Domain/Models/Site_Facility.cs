using _01.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.SM.Domain.Models
{
    public class Site_Facility : DomainBase
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool HasBullet { get; private set; }
        public string Img { get; private set; }
        public long Site_Base_Id { get; private set; }
        public Site_Base Sitebases { get; private set; }
        protected Site_Facility()
        {

        }

        public Site_Facility(string title, string description, bool hasBullet, string img, long site_Base_Id)
        {
            Title = title;
            Description = description;
            HasBullet = hasBullet;
            Img = img;
            Site_Base_Id = site_Base_Id;
        }
        public void Edit(string title, string description, bool hasBullet, string img)
        {
            Title = title;
            Description = description;
            HasBullet = hasBullet;
            Img = img;
        }
    }
}
