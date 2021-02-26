using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBotCore.Interfase
{
    public interface IProfile
    {
        Guid Id { get; }
        string Login { get; }
        string Password { get; }
    }
}
