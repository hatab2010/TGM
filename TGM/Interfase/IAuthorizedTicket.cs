using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBotCore.Interfase
{
    public interface IAuthorizedTicket
    {
        IProfile Profile { get; }
        Uri Site { get; }
        List<ICustomeCookie> AuthorizedCookies { set; get; }
    }
}
