using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class EnrollmentStatus
    {
        [PrimaryKey, AutoIncrement]

        public int EnrallmentStatusId { get; set; }

        [ForeignKey(nameof(UserType))]

        public string UserTypeId { get; set; }

        [ForeignKey(nameof(Trial))]

        public string TrialId { get; set;}

        public DateOnly EnrollmentDate { get; set; }

        public string Status { get; set; }
    }
}
