using SQLite;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrialClinic.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string PhysicalAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(UserType))]
        public int UserTypeId { get; set; }
    }
}