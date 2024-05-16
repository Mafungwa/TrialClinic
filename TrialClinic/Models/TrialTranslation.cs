using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class TrialTranslation
    {
        [PrimaryKey, AutoIncrement]
        public int TrialTranslationId { get; set; }

        [ForeignKey(nameof(Language))]

        public string TargetLanguage { get; set; }

        [ForeignKey(nameof(Trial))]

        public string TargetTrial { get; set; }

        public string TransaltionText { get; set; }
    }
}
