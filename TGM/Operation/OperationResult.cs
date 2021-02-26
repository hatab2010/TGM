using System;
using System.Diagnostics;
using System.Reflection;
using WebBotCore.Interfase;

namespace WebBotCore.Operation
{
    public class OperationResult : IOperationResult
    {
        public Exception OperationException { internal set; get; }
        public IOperation Operation { private set; get; }        

        public OperationResult(IOperation operation)
        {
            Operation = operation;
        }
    }
}
