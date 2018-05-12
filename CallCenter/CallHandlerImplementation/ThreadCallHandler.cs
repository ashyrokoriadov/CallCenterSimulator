using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

using CallCenter.Helpers;

namespace CallCenter.CallHandlerImplementation
{
    class ThreadCallHandler : ICallHandler
    {
        public void GenerateCalls(ConcurrentQueue<ICall> calls)
        {
            Thread callGeneration = new Thread(delegate () {
                Data.GenerateCalls(calls);
            });
            callGeneration.Start();
        }

        public void HandleCalls(ConcurrentQueue<ICall> calls, List<IOperator> operators)
        {
            foreach (IOperator callOperator in operators)
            {
                Thread callResponse = new Thread(delegate () {
                    callOperator.ResponseCall(calls);
                });
                callResponse.Start();
            }
        }
    }
}
