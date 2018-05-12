using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

using CallCenter.Helpers;

namespace CallCenter.CallHandlerImplementation
{
    class ThreadPoolCallHandler : ICallHandler
    {
        public void GenerateCalls(ConcurrentQueue<ICall> calls)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(
                delegate (object state) {
                    Data.GenerateCalls(calls);
                }), null);
        }

        public void HandleCalls(ConcurrentQueue<ICall> calls, List<IOperator> operators)
        {
            foreach (IOperator callOperator in operators)
            {
               ThreadPool.QueueUserWorkItem(new WaitCallback(
               delegate (object state) {
                   callOperator.ResponseCall(calls);
               }), null);
            }
        }
    }
}
