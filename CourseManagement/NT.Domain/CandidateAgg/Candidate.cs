using _01.Framework.Domain;
using NT.CM.Domain.BaseInfoAgg;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using NT.CM.Domain.CompanyAgg;
using System;
using System.Collections.Generic;

namespace NT.CM.Domain.CandidateAgg
{
    public class Candidate : DomainBase
    {
        public long? CompanyID { get; private set; }
        public Company Company { get; private set; }
        public string NID { get; private set; }
        public DateTime DOB { get; private set; }
        public long NationalityID { get; private set; }
        public BaseInfo BaseInfo { get; private set; }
        public string CityOfBirth { get; private set; }
        public long UserId { get; private set; }
        public ICollection<CandidateCourseInstructor> CandidateCourseInstructors { get; private set; }

        protected Candidate()
        {

        }
        public Candidate(long? companyid, string nid, DateTime dob, long nationalityid, string cityofbirth, long userid)
        {
            CompanyID = companyid;
            NID = nid;
            DOB = dob;
            NationalityID = nationalityid;
            CityOfBirth = cityofbirth;
            CandidateCourseInstructors = new List<CandidateCourseInstructor>();
            UserId = userid;
        }
        public void Edit(long? companyid, string nid, DateTime dob, long nationalityid, string cityofbirth)
        {
            CompanyID = companyid;
            NID = nid;
            DOB = dob;
            NationalityID = nationalityid;
            CityOfBirth = cityofbirth;
        }
    }
}


