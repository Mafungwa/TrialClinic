using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialUploader.Models
{
    public class TrialUpload
    {
        public string? TrialName { get; set; }
        public string? NCTNumber { get; set; }
        public string? UrlWebViewSource { get; set; }
        public string? TrialDescription { get; set; }
        public string? TrialPhase { get; set; }
        public string? Sex { get; set; }
        public string? Age { get; set; }
        public string? TrialStartDate { get; set; }
        public string? TrialEndDate { get; set; }
        public string? Enrollment { get; set; }
        public string? RecruitmentStatus { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; }
        public string? Condition { get; set; }
        public string? Treatment { get; set; }

    }
}
