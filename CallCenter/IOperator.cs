using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
