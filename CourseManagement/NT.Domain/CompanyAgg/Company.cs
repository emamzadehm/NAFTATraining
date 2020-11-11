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
        public byte[]? Logo { get; private set; }
        public long TypeID { get; private set; }
        public BaseInfo BaseInfo { get; private set; }
        public ICollection<Candidate> Candidates { get; private set; }

        protected Company()
        {

        }
        public Company(string companyname, string? website, byte[]? logo, long typeid)
        {
            CompanyName = companyname;
            Website = website;
            Logo = logo;
            TypeID = typeid;
            Candidates = new List<Candidate>();
        }
        public void Edit(string companyname, string? website, byte[]? logo, long typeid)
        {
            CompanyName = companyname;
            Website = website;
            Logo = logo;
            TypeID = typeid;
        }

    }
}
