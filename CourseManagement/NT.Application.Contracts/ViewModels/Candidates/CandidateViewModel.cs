using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Application.Contracts.ViewModels.Companies;
using System.Collections.Generic;

namespace NT.CM.Application.Contracts.ViewModels.Candidates
{
    public class CandidateViewModel
    {
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public long? CompanyID { get; set; }
        public string NID { get; set; }
        public string? DOB { get; set; }
        public long NationalityID { get; set; }
        public string NationalityName { get; set; }
        public string CityOfBirth { get; set; }
        public List<CompanyViewModel> CompanyList { get; set; }
        public List<BaseInfoViewModel> Nationality { get; set; }

    }
}
