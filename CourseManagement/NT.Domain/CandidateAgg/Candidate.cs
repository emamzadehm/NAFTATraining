using _01.Framework.Domain;
using Domain.BaseInfoAgg;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using NT.CM.Domain.CompanyAgg;
using System.Collections.Generic;

namespace NT.CM.Domain.CandidateAgg
{
    public class Candidate : DomainBase
    {
        public long? CompanyID { get; private set; }
        public Company Company { get; private set; }
        public string NID { get; private set; }
        public string DOB { get; private set; }
        public long NationalityID { get; private set; }
        public BaseInfo BaseInfo { get; private set; }
        public string CityOfBirth { get; private set; }
        public ICollection<CandidateCourseInstructor> CandidateCourseInstructors { get; private set; }

        protected Candidate()
        {

        }
        public Candidate(long? companyid, string nid, string dob, long nationalityid, string cityofbirth)
        {
            CompanyID = companyid;
            NID = nid;
            DOB = dob;
            NationalityID = nationalityid;
            CityOfBirth = cityofbirth;
            CandidateCourseInstructors = new List<CandidateCourseInstructor>();
        }
        //public Candidate(long companyid, string nid, string dob, long nationalityid, string cityofbirth, int courseinstructorid)
        //{
        //    CompanyID = companyid;
        //    NID = nid;
        //    DOB = dob;
        //    NationalityID = nationalityid;
        //    CityOfBirth = cityofbirth;
        //    CandidateCourseInstructors = new List<CandidateCourseInstructor>()
        //        {
        //            new CandidateCourseInstructor(courseinstructorid, ID)
        //        };
        //}
        public void Edit(long? companyid, string nid, string dob, long nationalityid, string cityofbirth)
        {
            //Users.Edit(firstname, lastname, sex, tel, img, password, idcardimg);
            CompanyID = companyid;
            NID = nid;
            DOB = dob;
            NationalityID = nationalityid;
            CityOfBirth = cityofbirth;
        }
    }
}


