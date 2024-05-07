using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class Results
    {
        [PrimaryKey, AutoIncrement]

        public int ResultsId { get; set; }

        public string Description { get; set; }

        public int Period { get; set; }

        [ForeignKey(nameof(Trial))]

        public int TrialId { get; set; }

    }
}
