using System;

namespace WebBotCore.Interfase
{
    public interface ICheckLoginOperation
    {
        event Action<bool> LoginChecked;
    }
}
