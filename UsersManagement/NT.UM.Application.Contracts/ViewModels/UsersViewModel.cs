using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.UM.Application.Contracts.ViewModels
{
    public class UsersViewModel
    {
        public long ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]

        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]

        public string LastName { get; set; }
        public string Fullname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        [DataType(DataType.EmailAddress, ErrorMessage = ValidationMessages.Email)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public bool Sex { get; set; }
        public IFormFile IMG { get; set; }
        public string Tel { get; set; }

        [Compare(nameof(RePassword), ErrorMessage = ValidationMessages.PasswordCompare)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
        [Compare(nameof(RePassword), ErrorMessage = ValidationMessages.PasswordCompare)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string RePassword { get; set; }
        public bool UserStatus { get; set; }
        public IFormFile IDCardIMG { get; set; }
        public string IDCardIMGFileAddress { get; set; }
        public string IMGFileAddress { get; set; }

        public List<UsersRolesViewModel> UsersRoless { get; set; }
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
