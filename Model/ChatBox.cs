using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NistagramSQLConnection.Model
{
    [Table("chatbox")]
    public class ChatBox
    {
        [Key]
        public long id { get; set; }
        public User me { get; set; }
        public User you { get; set; }
        public ICollection<ChatBoxMessages> chatBoxMessages { get; set; }
        
    }
}
