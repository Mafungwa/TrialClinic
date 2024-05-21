using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrialClinic.Models
{
    public class Enrollment
    {
        [PrimaryKey, AutoIncrement]
        public int EnrollmentId { get; set; }

        public int UserId { get; set; }

        public int EnrollmentStatusId { get; set; }

        public int TrialId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Status { get; set; }
    }
}
