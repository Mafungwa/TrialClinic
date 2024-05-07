using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class TrialSite
    {

        [PrimaryKey, AutoIncrement]
        public int? TrialSiteId { get; set; }

        public string? TrialSiteName { get; set; }

        [ForeignKey(nameof(Location))]
        public string? LocationId { get; set; }
    }
}
