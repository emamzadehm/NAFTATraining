using _01.Framework.Domain;
using System.Collections.Generic;

namespace NT.UM.Domain.UsersAgg
{
    public class Users : DomainBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool Sex { get; private set; }
        public string Email { get; private set; }
        public string Tel { get; private set; }
        public string IMG { get; private set; }
        public string Password { get; private set; }
        public string IDCardIMG { get; private set; }
        public ICollection<UsersRoles> UsersRoless { get; private set; }

        protected Users()
        {

        }
        public Users(string firstname, string lastname, bool sex, string email, string img, string tel, string password,
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
            //UsersRoless = new List<UsersRoles> {
            //    new UsersRoles(ID, roleid)
            //};
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