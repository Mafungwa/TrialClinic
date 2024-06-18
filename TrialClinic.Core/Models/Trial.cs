using SQLite;
using SQLiteNetExtensions.Attributes;
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

        [ForeignKey(typeof(Location))]
        public int LocationId { get; set; }

        [ManyToOne]
        public Location? Location { get; set; }


        [ForeignKey(typeof (Disease))]
        public int DiseaseId { get; set; }

        [ManyToOne]
        public Disease? Disease { get; set; }
        public string Status { get; set; }
        public string? TrialDescription { get; set; }

        [Ignore] // This tells SQLite to not store this property in the database
        public int ParticipantCount { get; set; }

        [ForeignKey(typeof(Recruiter))]
        public int RecruiterId { get; set; }

        [ManyToOne]

        public Recruiter? Recruiter { get; set; }
    }
}
