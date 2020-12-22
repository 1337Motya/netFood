using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFood.Models
{
    public class UserWithToken
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime? HireDate { get; set; }
        public string Token { get; set; }

        public UserWithToken(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Password = user.Password;
            Surname = user.Surname;
            Name = user.Name;
            Patronymic = user.Patronymic;
            HireDate = user.HireDate;
        }
    }
}
