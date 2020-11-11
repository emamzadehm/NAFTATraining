using NT.UM.Application.Contracts;

namespace NT.CM.Application.Contracts
{
    public class CandidateViewModel
    {
        public long ID { get; set; }
        public long? CompanyID { get; set; }
        public string? NID { get; set; }
        public string? DOB { get; set; }
        public long? NationalityID { get; set; }
        public string? CityOfBirth { get; set; }

    }
}
