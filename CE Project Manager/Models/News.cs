using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CDP_Manager.Models
{
    public class News
    {
        public int NewsId { get; set; }

        [MaxLength(1024), StringLength(1024, ErrorMessage = "{0} can have max length of {1} characters")]
        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public virtual User User { get; set; }
    }
}
