using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TrialClinic.Models
{
    public class ChatMessage
    {
        internal int ForumId;

        [PrimaryKey, AutoIncrement]

        public int MessageId { get; set; }

        [ForeignKey(typeof(User))]

        public int SenderId { get; set;}

        [ForeignKey(typeof(User))]

        public int RecieverId { get; set;}

        public string MessageContent { get; set;}
        public int Forum {  get; set;}

        public DateTime DateTime { get; set;}

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
        public DateTime MessageDate { get; set;}
    }
}
