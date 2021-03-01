using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBotCore.Interfase;

namespace WebBotCore.Data
{
    public class SiteProfile : ISiteProfile
    {
        public Uri Page { set; get; }

        public string Login { set; get; }

        public string Password { set; get; }

        public bool IsBan { set; get; }
    }
}
