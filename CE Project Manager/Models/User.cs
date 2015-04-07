using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Services.Description;

namespace CDP_Manager.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        
        public string Password { get; set; } //SHA1

        public bool Logged { get; set; }

        public virtual List<UserPrivilege> Privilegeses { get; set; }

        public virtual List<Message> Messages { get; set; }

        public virtual List<News> News { get; set; }
    }
}