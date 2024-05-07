using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrialClinic.Models
{
    public class Language
    {
        [PrimaryKey, AutoIncrement]

        public int LanguageId { get; set; }

        public string LanguageName { get; set; }
    }
}
