using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.src.Sistem.Service
{
    public interface IMessageService
    {
        public Task SendMessageAsync(String Message, Guid UserId);
    }
}