using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NistagramSQLConnection.Model
{
    public class ChatBoxMessages
    {
        public long chatBoxId { get; set; }
        public ChatBox chatBox { get; set; }

        public long messageId { get; set; }
        public Message message { get; set; }
    }
}
