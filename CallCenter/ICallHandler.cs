using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter
{
    interface ICallHandler
    {
        void GenerateCalls(ConcurrentQueue<ICall> calls);

        void HandleCalls(ConcurrentQueue<ICall> calls, List<IOperator> operators);
    }
}
