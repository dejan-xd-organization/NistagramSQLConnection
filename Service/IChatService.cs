using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NistagramSQLConnection.Model;

namespace NistagramSQLConnection.Service
{
    public interface IChatService
    {
        List<Message> GetChatByUser(long friendId, long userId);
        Message SendMessage(string text, long friendId, long userId);

    }
}
