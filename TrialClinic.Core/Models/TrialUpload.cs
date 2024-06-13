using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialUploader.Models
{
    public class TrialUpload
    {
        public string TrialName { get; set; }
        public string NCTNumber { get; set; }
        public string URL { get; set; }
        public string TrialPhase { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public DateTime TrialStartDate { get; set; }
        public DateTime TrialEndDate { get; set; }
        public string Location { get; set; } // Assuming this is a string in the CSV
        public string Condition { get; set; }
        public string TrialDescription { get; set; }
        public string Status { get; set; }
        public int ParticipantCount { get; set; }
        public int RecruiterId { get; set; }
        public string Treatment { get; set; } // Assuming this is a string in the CSV
    }
}
