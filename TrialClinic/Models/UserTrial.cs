using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrialClinic.Models
{
    public class UserTrial
    {
        [PrimaryKey, AutoIncrement]

        [ForeignKey(nameof(User))]

        public string UserId { get; set; }

        [ForeignKey(nameof(Trial))]

        public string TrialId { get; set;}
    }
}
