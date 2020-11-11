using _01.Framework.Domain;
using System;
using System.Collections.Generic;

namespace NT.UM.Domain.UsersAgg
{
    public class Users : DomainBase
    {
        public string? FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool Sex { get; private set; }
        public string Email { get; private set; }
        public string? Tel { get; private set; }
        public byte[]? IMG { get; private set; }
        public string? Password { get; private set; }
        public byte[]? IDCardIMG { get; private set; }
        public ICollection<UsersRoles> UsersRoless { get; private set; }

        protected Users()
        {
            //UsersRoless = new List<UsersRoles>();
        }
        public Users(string? firstname, string lastname, bool sex, string email, byte[]? img, string? tel, string? password, byte[]? idcardimg)
        {
            FirstName = firstname;
            LastName = lastname;
            Sex = sex;
            Email = email;
            Tel = tel;
            IMG = img;
            Password = password;
            IDCardIMG = idcardimg;
            //UsersRoless = new List<UsersRoles> { 
            //    new UsersRoles(ID, roleid)
            //};
            //Instructors = new Instructor(educationLevel, resume);
        }
        //public Users(string? firstname, string lastname, bool sex, string email, byte[]? img, string? tel, string? password, byte[]? idcardimg, int? companyid, string? nid, string? dob, int? nationalityid, string? cityofbirth, int roleid)
        //{
        //    FirstName = firstname;
        //    LastName = lastname;
        //    Sex = sex;
        //    Email = email;
        //    Tel = tel;
        //    IMG = img;
        //    Password = password;
        //    IDCardIMG = idcardimg;
        //    UsersRoless = new List<UsersRoles> {
        //        new UsersRoles(ID, roleid)
        //    };
        //    Candidates = new Candidate(companyid, nid, dob, nationalityid, cityofbirth);
        //}

        public void Edit(string? firstname, string lastname, bool sex, string? tel, byte[]? img, string password, byte[]? idcardimg)
        {
            FirstName = firstname;
            LastName = lastname;
            Sex = sex;
            //Email = email;
            Tel = tel;
            IMG = img;
            Password = password;
            IDCardIMG = idcardimg;
        }
    }
}