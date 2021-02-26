using System;
using WebBotCore.Interfase;

namespace WebBotCore.Operation
{
    public interface IOperationResult
    {
        IOperation Operation { get; }
        Exception OperationException { get; }
    }
}
