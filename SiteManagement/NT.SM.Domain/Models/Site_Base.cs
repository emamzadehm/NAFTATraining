using _01.Framework.Domain;
using System;
using System.Collections.Generic;

namespace NT.SM.Domain.Models
{
    public class Site_Base : DomainBase
    {
        public string MainTitle { get; private set; }
        public string MainDescription { get; private set; }
        public List<Site_About> Site_Abouts { get; private set; }
        public List<Site_CertifiedProgram> Site_CertifiedPrograms { get; private set; }
        public List<Site_Course> Site_Courses { get; private set; }
        public List<Site_Facility> Site_Facilities { get; private set; }
        public List<Site_WhyNafta> Site_WhyNaftas { get; private set; }

        protected Site_Base()
        {

        }
        public Site_Base(string mainTitle, string mainDescription)
        {
            MainTitle = mainTitle;
            MainDescription = mainDescription;
            Site_Abouts = new List<Site_About>();
            Site_CertifiedPrograms = new List<Site_CertifiedProgram>();
            Site_Courses = new List<Site_Course>();
            Site_Facilities = new List<Site_Facility>();
            Site_WhyNaftas = new List<Site_WhyNafta>();
        }
        public void Edit(string mainTitle, string mainDescription)
        {
            MainTitle = mainTitle;
            MainDescription = mainDescription;
        }

    }
}
