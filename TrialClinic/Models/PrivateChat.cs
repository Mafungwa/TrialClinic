using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrialClinic.Models
{
    public class PrivateChat
    {
        [PrimaryKey, AutoIncrement]

        public int ChatId { get; set; }

        [ForeignKey(nameof(UserType))]

        public string ParticipanCtId { get; set; }

        [ForeignKey(nameof(UserType))]

        public string RecruiterId { get; set; }
    }
}
