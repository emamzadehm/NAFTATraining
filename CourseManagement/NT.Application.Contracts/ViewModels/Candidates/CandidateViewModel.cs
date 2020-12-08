using _01.Framework.Application;
using Microsoft.AspNetCore.Http;
using NT.CM.Application.Contracts.ViewModels.BaseInfo;
using NT.CM.Application.Contracts.ViewModels.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NT.CM.Application.Contracts.ViewModels.Candidates
{
    public class CandidateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string LastName { get; set; }
        public string Fullname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public bool Sex { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        [DataType(DataType.EmailAddress,ErrorMessage =ValidationMessages.Email)]
        public string Email { get; set; }
        public string Tel { get; set; }

        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
       // [FileExtentionLimitation(new string[] {".jpeg", ".png", ".jpg"}, ErrorMessage = ValidationMessages.FileExtention)]
        public IFormFile IMG { get; set; }
        [Compare(nameof(RePassword), ErrorMessage = ValidationMessages.PasswordCompare)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }

        [Compare(nameof(RePassword), ErrorMessage = ValidationMessages.PasswordCompare)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string RePassword { get; set; }
        [Required(AllowEmptyStrings =true)]
        public IFormFile IDCardIMG { get; set; }
        public string IDCardIMGFileAddress { get; set; }
        public string IMGFileAddress { get; set; }



        //Candidate's table =>
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public long? CompanyID { get; set; }
        public string NID { get; set; }
        public DateTime DOB { get; set; }
        public long NationalityID { get; set; }
        public string NationalityName { get; set; }
        public string CityOfBirth { get; set; }
        public long UserID { get; set; }

        public List<CompanyViewModel> CompanyList { get; set; }
        public List<BaseInfoViewModel> Nationality { get; set; }
        //public List<UserViewModel> UserList { get; set; }


    }
}
