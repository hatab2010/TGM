using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBotCore.Interfase
{    
    public interface IAuthorizationTicket
    {
        ISiteProfile SiteProfile { get; }
        IChromeProfile ChromeProfile { get; }
    }
}
