using System;
using System.Collections.Generic;

namespace NetFood.Models
{
    public partial class User
    {
        public User()
        {
            Admininstrators = new HashSet<Admininstrator>();
            Managers = new HashSet<Manager>();
            Staffs = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime? HireDate { get; set; }

        public virtual ICollection<Admininstrator> Admininstrators { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
