using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeignKeyAttribute = System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;

namespace TrialClinic.Models
{
    public class TrialTranslation
    {
        [PrimaryKey, AutoIncrement]
        public int TrialTranslationId { get; set; }

        [ForeignKey(nameof(Trial))]
        public int TrialId { get; set; }

        [ManyToOne]
        public Trial Trial { get; set; }

    }
}
