﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrialClinic.Models
{
    public class PrivateChat
    {
        [PrimaryKey, AutoIncrement]

        public int ChatId { get; set; }

        public string Message { get; set; }

        public string RecruiterId { get; set; }
    }
}
