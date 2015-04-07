using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CDP_Manager.Models
{
    public class UserPrivilege
    {
        public int PrivilegeId { get; set; }

        [MaxLength(45), StringLength(45, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Name { get; set; }

        [MaxLength(255), StringLength(255, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Description { get; set; }

        public User User { get; set; }
    }
}
