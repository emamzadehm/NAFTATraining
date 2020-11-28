using _01.Framework.Domain;
using Domain.BaseInfoAgg;
using NT.CM.Domain.CandidateAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Domain.CompanyAgg
{
    public class Company : DomainBase
    {
        public string CompanyName { get; private set; }
        public string? Website { get; private set; }
        public string? Logo { get; private set; }
        public bool IsPartner { get; private set; }
        public bool IsClient { get; private set; }

        public ICollection<Candidate> Candidates { get; private set; }


        protected Company()
        {

        }
        public Company(string companyname, string website, string logo, bool ispartner, bool isclient)
        {
            CompanyName = companyname;
            Website = website;
            Logo = logo;
            IsClient = isclient;
            IsPartner = ispartner;
            //Candidates = new List<Candidate>();
        }
        public void Edit(string companyname, string website, string logo, bool ispartner, bool isclient)
        {
            CompanyName = companyname;
            Website = website;
            if (!string.IsNullOrWhiteSpace(logo))
                Logo = logo;
            IsClient = isclient;
            IsPartner = ispartner;
        }

    }
}
