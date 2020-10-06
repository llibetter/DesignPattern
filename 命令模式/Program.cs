using System;

namespace 命令模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Commond commond=new ConcreteCommond();
            Invoker invoker=new Invoker(commond);
            invoker.call();

            Console.Read();
        }
    }

    class Invoker
    {
        private Commond commond;
        public Invoker(Commond c)
        {
            commond=c;
        }

        public void call()
        {
            Console.WriteLine("调用者调用call");
            commond.Execute();
        }
    }

    interface Commond
    {
        public void Execute();
    }

    class ConcreteCommond:Commond
    {
        private Receiver receiver;
        public ConcreteCommond()
        {
            receiver=new Receiver();
        }

        public void Execute()
        {
            Console.WriteLine("具体命令调用Execute");
            receiver.Action();
        }
    }

    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("接收者执行Action");
        }
    }
}
