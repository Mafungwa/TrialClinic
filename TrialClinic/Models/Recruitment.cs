using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class Recruitment
    {
        [PrimaryKey, AutoIncrement]
        public int RecruitmentId { get; set; }

        public int UserId { get; set; }

        public int RecruitmentStatusId { get; set; }

        public int TrialId { get; set; }

        public DateOnly EnrollmentDate { get; set; }

        public string Status { get; set; }
    }
}
