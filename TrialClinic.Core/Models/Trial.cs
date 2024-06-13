using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialClinic.Core.Models;

namespace TrialClinic.Models
{
    public class Trial
    {
        [PrimaryKey, AutoIncrement]
        public int TrialId { get; set; }
        public string? NCTNumber { get; set; }
        public string? TrialName { get; set; }
        public string URL { get; set; }
        public int TrialPhase { get; set; }
        public string? Sex { get; set; }
        public string? Age { get; set; }
        public DateTime TrialStartDate { get; set; }
        public DateTime TrialEndDate { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }

        [ForeignKey(nameof (Disease))]
        public int DiseaseId { get; set; }
        public string Status { get; set; }
        public string? TrialDescription { get; set; }

        [Ignore] // This tells SQLite to not store this property in the database
        public int ParticipantCount { get; set; }

        [ForeignKey(nameof(Recruiter))]
        public int RecruiterId { get; set; }
    }
}
