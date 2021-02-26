using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebBotCore.Interfase;

namespace TelegramWebBot.Data
{
    public class TelegramProfile : IProfile
    {
        public Guid Id { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
    }

    public class MyCookie : ICustomeCookie
    {
        public Guid Id { set; get; }
        public Guid ProfileId { set; get; }
        public string Key { set; get; }
        public string Value { set; get; }
    }
}
