using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrialClinic.Models
{
    public class RecruitmentEffort
    {
        [PrimaryKey, AutoIncrement]

        public int RecruitmentEffortId { get; set; }

        [ForeignKey(nameof(UserType))]

        public UserType UserTypeId { get; set;}

        [ForeignKey(nameof(Trial))]

        public Trial Trial { get; set;}

        public DateOnly RecruitmentDate { get; set; }

        public string Status { get; set; }
    }
}
