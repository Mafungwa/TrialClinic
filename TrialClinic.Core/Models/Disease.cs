using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialClinic.Models;
using ForeignKeyAttribute = System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;

namespace TrialClinic.Core.Models
{
    public class Disease
    {
        [PrimaryKey, AutoIncrement]

        public int DiseaseId { get; set; }
        public string Condition { get; set; }

        [ForeignKey(nameof(Trial))]

        public int TrialId { get; set; }
    }
}
