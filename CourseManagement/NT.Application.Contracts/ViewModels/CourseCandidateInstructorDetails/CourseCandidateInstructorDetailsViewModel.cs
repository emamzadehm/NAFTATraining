using System;
using System.Collections.Generic;
using System.Text;

namespace NT.CM.Application.Contracts.ViewModels.CourseCandidateInstructorDetails
{
    public class CourseCandidateInstructorDetailsViewModel
    {
        public long ID { get; set; }
        public long TypeID { get; set; }
        public string Value { get; set; }
        public byte DocumentIMG { get; set; }
        public long CCI_ID { get; set; }
        public string BaseInfoName { get; set; }
    }
}
