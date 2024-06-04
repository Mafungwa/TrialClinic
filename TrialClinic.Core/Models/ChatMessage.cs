using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace TrialClinic.Models
{
    public class ChatMessage
    {
        internal int ForumId;

        [PrimaryKey, AutoIncrement]

        public int MessageId { get; set; }

        [ForeignKey(nameof(User))]

        public int SenderId { get; set;}

        [ForeignKey(nameof(User))]

        public int RecieverId { get; set;}

        public string MessageContent { get; set;}


        public DateTime DateTime { get; set;}
        public int UserId { get; internal set; }
        public DateTime MessageDate { get; set;}
    }
}
