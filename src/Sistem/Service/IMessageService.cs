using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Sistem.dto;

namespace app.src.Sistem.Service
{
    public interface IMessageService
    {
        public Task<MessageSendRequest> SendMessageAsync(MessageSendRequest MsgReq, Guid UserId);
    }
}