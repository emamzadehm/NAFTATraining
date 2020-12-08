using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.Instructors
{
    public class InstructorsViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string LastName { get; set; }
        public string Fullname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public bool Sex { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        [DataType(DataType.EmailAddress, ErrorMessage = ValidationMessages.Email)]
        public string Email { get; set; }
        public string Tel { get; set; }
        public IFormFile IMG { get; set; }

        [Compare(nameof(RePassword), ErrorMessage = ValidationMessages.PasswordCompare)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
        [Compare(nameof(RePassword), ErrorMessage = ValidationMessages.PasswordCompare)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string RePassword { get; set; }
        public IFormFile IDCardIMG { get; set; }
        //Instructor's table =>
        public long ID { get; set; }
        public string EducationLevel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Resume { get; set; }
        public long UserID { get; set; }
        public string IDCardIMGFileAddress { get; set; }
        public string IMGFileAddress { get; set; }

    }
}
