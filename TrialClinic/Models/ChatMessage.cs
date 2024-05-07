using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using SQLite;

namespace TrialClinic.Models
{
    public class ChatMessage
    {
        [PrimaryKey, AutoIncrement]

        public int MessageId { get; set; }

        [ForeignKey(nameof(UserType))]

        public UserType SenderId { get; set;}

        [ForeignKey(nameof(UserType))]

        public UserType RecieverId { get; set;}

        public string MessageContent { get; set;}

        public DateTime DateTime { get; set;}
    }
}
