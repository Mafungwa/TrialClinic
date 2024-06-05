using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class Recruiter: User
    {
        [Ignore]
        public List<Trial> Trials { get; set; }
    }
}
