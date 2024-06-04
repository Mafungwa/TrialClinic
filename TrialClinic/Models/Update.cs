using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class Update
    {
        [PrimaryKey, AutoIncrement]
        public int UpdateId { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

        // If an update is related to a specific trial, you can include a foreign key to the Trial table
        [ForeignKey(typeof(Trial))]
        public int TrialId { get; set; }
    }
}
