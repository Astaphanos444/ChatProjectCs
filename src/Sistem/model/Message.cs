using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model;

namespace app.src.Sistem.model
{
    public class Message
    {
        public int Id { get; set; }
        public string Msg { get; set; } = "";
        public Guid UserId { get; set; }
    }
}