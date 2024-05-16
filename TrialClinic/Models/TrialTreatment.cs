using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrialClinic.Models
{
    public class TrialTreatment
    {
        [PrimaryKey, AutoIncrement]

        public int TrialTreatmentId { get; set; }

        [ForeignKey(nameof(Trial))]

        public int TrialId { get; set; }

        [ForeignKey(nameof(Treatment))]

        public int TreatmentId { get; set; }

    }
}
