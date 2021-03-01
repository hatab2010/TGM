using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBotCore.Interfase;

namespace WebBotCore.Model
{
    public class AutorizationTicket : IAuthorizationTicket
    {
        public ISiteProfile SiteProfile { get; private set; }
        public IChromeProfile ChromeProfile { get; private set; }
        public AutorizationTicket(ISiteProfile siteProfile, IChromeProfile chromeProfile)
        {
            SiteProfile = siteProfile;
            ChromeProfile = chromeProfile;
        }
    }
}
