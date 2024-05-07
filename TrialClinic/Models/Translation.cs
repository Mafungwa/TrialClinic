using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrialClinic.Models
{
    public class Translation
    {
        [PrimaryKey, AutoIncrement]

        public int TranslationId { get; set; }

        [ForeignKey(nameof(Language.LanguageId))]

        public Language SourceLanguage { get; set; }

        [ForeignKey(nameof(Language.LanguageId))]

        public string TargetLanguage { get; set; }

        public string SourceText { get; set; }

        public string TranslatedText { get; set; }

    }
}
