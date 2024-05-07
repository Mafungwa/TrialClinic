using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialClinic.Models
{
    public class UserType
    {
        [PrimaryKey, AutoIncrement]
        public int UserTypeId { get; set; }

        public string TypeName { get; set; }
    }
}
