using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Data;
using app.src.Sistem.dto;
using app.src.Sistem.model;

namespace app.src.Sistem.Service
{
    public class MessageService(UserDbContext context) : IMessageService
    {
        public async Task<MessageSendRequest> SendMessageAsync(MessageSendRequest MsgReq, Guid UserId)
        {
            var msg = new Message();
            msg.Msg = MsgReq.Msg;
            msg.UserId = UserId;

            await context.Messages.AddAsync(msg);
            await context.SaveChangesAsync();

            return MsgReq;
        }
    }
}