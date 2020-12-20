﻿using _01.Framework.Domain;
using System.Collections.Generic;

namespace NT.UM.Domain.UsersAgg
{
    public class User : DomainBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool Sex { get; private set; }
        public string Email { get; private set; }
        public string Tel { get; private set; }
        public string IMG { get; private set; }
        public string Password { get; private set; }
        public string IDCardIMG { get; private set; }
        public List<UserRole> UserRoles { get; private set; }
        protected User()
        {

        }
        public User(string firstname, string lastname, bool sex, string email, string img, string tel, string password,
            string idcardimg)
        {
            FirstName = firstname;
            LastName = lastname;
            Sex = sex;
            Email = email;
            Tel = tel;
            IMG = img;
            Password = password;
            IDCardIMG = idcardimg;
        }


        public void Edit(string firstname, string lastname, bool sex, string tel, string img, string idcardimg)
        {
            FirstName = firstname;
            LastName = lastname;
            Sex = sex;
            Tel = tel;
            if (!string.IsNullOrWhiteSpace(img))
                IMG = img;
            IDCardIMG = idcardimg;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}