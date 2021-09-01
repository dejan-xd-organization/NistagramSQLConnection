using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NistagramSQLConnection.Data;
using NistagramSQLConnection.Model;

namespace NistagramSQLConnection.Service.Implementation
{
    public class ChatServiceImpl : IChatService
    {
        private readonly DataContext _db;

        public ChatServiceImpl(DataContext db)
        {
            _db = db;
        }

        public List<Message> GetChatByUser(long friendId, long userId)
        {
            ChatBox cBox = _db.ChatBoxes
                .Where(x => x.me.id == userId && x.you.id == friendId)
                .Include(x => x.chatBoxMessages).ThenInclude(x => (x as ChatBoxMessages).message).ThenInclude(x => x.user)
                .FirstOrDefault();

            List<Message> messages = cBox?.chatBoxMessages?.Select(x => x.message).ToList();

            return messages;

        }

        public Message SendMessage(string text, long friendId, long userId)
        {
            User user = _db.Users.FirstOrDefault(x => x.id == userId);

            Message message = new Message();

            message.text = text;
            message.user = user;
            _db.Messages.Add(message);
            _db.SaveChanges();



            ChatBox cBox = _db.ChatBoxes
                .Where(x => x.me.id == userId && x.you.id == friendId)
                .FirstOrDefault();

            if (cBox != null)
            {
                ChatBoxMessages cbMesg = new ChatBoxMessages();
                cbMesg.chatBoxId = cBox.id;
                cbMesg.chatBox = cBox;
                cbMesg.messageId = message.id;
                cbMesg.message = message;

                _db.ChatBoxMessages.Add(cbMesg);
                _db.SaveChanges();

                cBox.chatBoxMessages.Add(cbMesg);
                _db.SaveChanges();
                return message;
            }

            User you = _db.Users.FirstOrDefault(x => x.id == friendId);

            ChatBox newCBox = new ChatBox();
            newCBox.me = user;
            newCBox.you = you;
            _db.ChatBoxes.Add(newCBox);
            _db.SaveChanges();

            ChatBoxMessages newCbMesg = new ChatBoxMessages();
            newCbMesg.chatBoxId = newCBox.id;
            newCbMesg.chatBox = newCBox;
            newCbMesg.messageId = message.id;
            newCbMesg.message = message;

            _db.ChatBoxMessages.Add(newCbMesg);
            _db.SaveChanges();

            newCBox.chatBoxMessages.Add(newCbMesg);
            _db.SaveChanges();

            return message;

        }
    }
}
