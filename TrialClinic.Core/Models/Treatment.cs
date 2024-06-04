using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class Treatment
    {
        [PrimaryKey, AutoIncrement]

        public int TreatmentId { get; set; }

        public string TreatmentType { get; set;}

        public string TreatmentName { get; set; }

        public string TreatmentDescription { get; set; }

        [ForeignKey(nameof(Trial))]

        public int TrialId { get; set; }

    }
}
