using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBotCore.Interfase
{
    public interface ICustomeCookie
    {
        Guid Id { set; get; }
        Guid ProfileId { set; get; }
        string Key  { set; get; }
        string Value { set; get; }
    }
}
