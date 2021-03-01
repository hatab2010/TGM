using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBotCore.Interfase
{
    public interface ISiteProfile
    {
        Uri Page { get; }
        string Login { get; }
        string Password { get; }
        bool IsBan { get; }
    }
}
