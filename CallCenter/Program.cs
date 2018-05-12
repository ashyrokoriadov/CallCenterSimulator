using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

using CallCenter.CallHandlerImplementation;

namespace CallCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<ICall> calls = new ConcurrentQueue<ICall>();

            IOperator callOperator1 = new Operator("Operator 1");
            IOperator callOperator2 = new Operator("Operator 2");
            IOperator callOperator3 = new Operator("Operator 3");
            List<IOperator> operators = new List<IOperator>();
            operators.AddRange(new IOperator[] { callOperator1, callOperator2, callOperator3 });

            ICallHandler callHandler;

            //TODO: Add code to read interface implementation type from configuration.
            //callHandler = new ThreadCallHandler();
            //callHandler = new ThreadPoolCallHandler();
            callHandler = new TaskCallHandler();

            callHandler.GenerateCalls(calls);
            callHandler.HandleCalls(calls, operators);

            while(true)
            {
                char input = Console.ReadKey().KeyChar;

                switch(input)
                {
                    case 'c':
                        ICall call = new Call();
                        calls.Enqueue(call);
                        Console.WriteLine("\nNew incomming call by 'C' button. Total number of calls: {0}", calls.Count);
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                }               
            }
        }
    }

    class Operator : IOperator
    {
        Random callDurationGenerator = new Random();

        public event ResponseCallDelegate ReadyForNextCall;

        public string Name { get;}

        public Operator(string Name)
        {
            this.Name = Name;
            ReadyForNextCall += ResponseCall;
        }

        public void ResponseCall(ConcurrentQueue<ICall> calls)
        {
            ICall call;
            calls.TryDequeue(out call);
            if (call != null)
            {
                Console.WriteLine("{0}: {1} has been recieved. Starting conversation...", Name, call.Name);
                Conversation();
                EndCall();                
            }
            else
            {
                //Wait 3 seconds for new calls.
                Thread.Sleep(3000);
            }

            ReadyForNextCall?.Invoke(calls);
        } 

        public void Conversation()
        {
            int callDuration = callDurationGenerator.Next(6, 10);
            Console.WriteLine("{0}: Conversation / call duration is {1} seconds", Name, callDuration.ToString());
            Thread.Sleep(callDuration*1000);
        }

        public void EndCall()
        {
            Console.WriteLine("{0}: Call has been ended.", Name);            
        }
    }

    class Call : ICall
    {
        Random callIdentifierGenerator = new Random();

        public string Name { get; }

        public Call()
        {
            Name = string.Format("Incomming call id = {0}", callIdentifierGenerator.Next(0,1000).ToString());
        }
    }

    
}
