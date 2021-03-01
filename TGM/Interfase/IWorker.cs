using System;
using System.Collections.Generic;
using WebBotCore.Operation;

namespace WebBotCore.Interfase
{
    public interface IWorker
    {
        IChromeProfile Profile { get; }
        event Action<OperationResult> OperationExecuted;
        bool IsActive { get; }
        List<IOperation> Operations { get; }
        void Start(IChromeProfile profile = null);
        void AddOperation(IOperation operation);
        void Dispose();
    }
}