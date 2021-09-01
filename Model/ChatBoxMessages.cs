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
