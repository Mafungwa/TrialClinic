using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TrialClinic.Models
{
    public class TrialTranslation
    {
        [PrimaryKey, AutoIncrement]
        public int TrialTranslationId { get; set; }

        [ForeignKey(typeof(Trial))]
        public int TrialId { get; set; }

        [ManyToOne]
        public Trial Trial { get; set; }

        public string TranslatedDescription { get; set; }

        public string Language { get; set; }
        public string LanguageCode { get; set; }
    }
}
