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
        public int EnrollmentStatusId { get; set; }

        public string Status { get; set; }
    }
}
