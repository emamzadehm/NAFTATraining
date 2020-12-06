using _01.Framework.Domain;
using NT.CM.Domain.BaseInfoAgg;
using NT.CM.Domain.CandidateCourseInstructorAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Domain.CourseCandidateInstructorDetailsAgg
{
    public class CourseCandidateInstructorDetails : DomainBase
    {
        public long TypeID { get; private set; }
        public string Value { get; private set; }
        public string DocumentIMG { get; private set; }
        public long CCI_ID { get; private set; }
        public BaseInfo BaseInfo { get; private set; }
        public CandidateCourseInstructor CandidateCourseInstructor { get; private set; }

        public CourseCandidateInstructorDetails()
        {

        }
        public CourseCandidateInstructorDetails(long typeid, string value, string documentimg, long cci_id)
        {
            TypeID = typeid;
            Value = value;
            DocumentIMG = documentimg;
            CCI_ID = cci_id;
        }
        public void Edit(long typeid, string value, string documentimg, long cci_id)
        {
            TypeID = typeid;
            Value = value;
            DocumentIMG = documentimg;
            CCI_ID = cci_id;
        }
    }
}
