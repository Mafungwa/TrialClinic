using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class Trial
    {
        [PrimaryKey, AutoIncrement]

        public int TrialId { get; set; }

        public string TrialName { get; set; }

        public int TrialPhase { get; set; }

        public DateTime TrialStartDate { get; set; }
        public DateTime TrialEndDate { get; set; }

        [ForeignKey(nameof(Location))]

        public int LocationId { get; set; }

        public string TrialDescription { get; set; }
    }
}
