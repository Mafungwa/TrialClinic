using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    internal class User
    {
        [PrimaryKey, AutoIncrement]

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(UserType))]

        public string UserTypeId { get; set; }
        
    }
}
