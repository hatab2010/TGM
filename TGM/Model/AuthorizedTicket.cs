using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBotCore.Interfase;

namespace WebBotCore.Model
{
    public class AuthorizedTicket : IAuthorizedTicket
    {
        public AuthorizedTicket(Uri site, IProfile profile)
        {
            Site = site;
            Profile = profile;
        }

        public IProfile Profile { get; private set; }
        public Uri Site { get; set; }
        public List<ICustomeCookie> AuthorizedCookies { get; set; }
    }
}
