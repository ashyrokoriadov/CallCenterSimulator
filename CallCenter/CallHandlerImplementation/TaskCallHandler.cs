using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using CallCenter.Helpers;

namespace CallCenter.CallHandlerImplementation
{
    class TaskCallHandler : ICallHandler
    {
        public void GenerateCalls(ConcurrentQueue<ICall> calls)
        {
            Task callGeneration = Task.Run(delegate () {
                Data.GenerateCalls(calls);
            });
        }

        public void HandleCalls(ConcurrentQueue<ICall> calls, List<IOperator> operators)
        {
            foreach (IOperator callOperator in operators)
            {
                Task callResponse = Task.Run(delegate () {
                    callOperator.ResponseCall(calls);
                });
            }
        }
    }
}
