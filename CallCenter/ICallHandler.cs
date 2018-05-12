using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CallCenter
{
    interface ICallHandler
    {
        void GenerateCalls(ConcurrentQueue<ICall> calls);

        void HandleCalls(ConcurrentQueue<ICall> calls, List<IOperator> operators);
    }
}
