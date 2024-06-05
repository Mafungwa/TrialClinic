using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class Participant : User
    {
        [ForeignKey(nameof(Trial))]
        public int TrialId { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
