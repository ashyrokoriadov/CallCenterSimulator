using System.Collections.Concurrent;

namespace CallCenter
{
    delegate void ResponseCallDelegate(ConcurrentQueue<ICall> calls);

    interface IOperator
    {      
        event ResponseCallDelegate ReadyForNextCall;

        void ResponseCall(ConcurrentQueue<ICall> calls);

        void Conversation();

        void EndCall();
    }
}
