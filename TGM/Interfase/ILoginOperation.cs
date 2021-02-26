using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBotCore.Interfase
{
    public interface ISiteAuthorize
    {
        Uri OperationPage { get; }
        IProfile Profile { get; }
        Action<IAuthorizedTicket> SuccessAction { get; }
    }
}
