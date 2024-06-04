using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class RecruitmentStatus
    {
        [PrimaryKey, AutoIncrement]
        public int RecruitmentStatusId { get; set; }

        public string Status { get; set; }
    }
}
