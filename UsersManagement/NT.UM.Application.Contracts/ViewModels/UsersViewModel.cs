using System;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class UsersViewModel
    {
        public long ID { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public bool Sex { get; set; }
        public string? IMG { get; set; }
        public string? Tel { get; set; }
        public string? Password { get; set; }
        public bool UserStatus { get; set; }
        public string? IDCardIMG { get; set; }


        //public List<UsersRoles> UsersRoless { get; set; }
        //public InstructorsViewModel Instructor { get; set; }

        ////////Candidate Fields:
        //////public int? CompanyID { get; set; }
        //////public string? NID { get; set; }
        //////public string? DOB { get; set; }
        //////public int? NationalityID { get; set; }
        //////public string? CityOfBirth { get; set; }
        
        
        ////////Instructor's Fields:
        //////public string? EducationLevel { get; set; }
        //////public string? Resume { get; set; }
    }
}
