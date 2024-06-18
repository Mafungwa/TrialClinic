using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TrialClinic.Models
{
    public class TrialTreatment
    {
        [PrimaryKey, AutoIncrement]

        public int TrialTreatmentId { get; set; }

        [ForeignKey(typeof(Trial))]

        public int TrialId { get; set; }

        [ManyToOne]
        public Trial? Trial { get; set; }

        [ForeignKey(typeof(Treatment))]

        public int TreatmentId { get; set; }

        [ManyToOne]
        public Treatment? Treatment { get; set; }

    }
}
