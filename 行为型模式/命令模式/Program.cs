using System;

/*
命令模式包含以下主要角色。
抽象命令类（Command）角色：声明执行命令的接口，拥有执行命令的抽象方法 execute()。
具体命令角色（Concrete    Command）角色：是抽象命令类的具体实现类，它拥有接收者对象，并通过调用接收者的功能来完成命令要执行的操作。
实现者/接收者（Receiver）角色：执行命令功能的相关操作，是具体命令对象业务的真正实现者。
调用者/请求者（Invoker）角色：是请求的发送者，它通常拥有很多的命令对象，并通过访问命令对象来执行相关请求，它不直接访问接收者。
*/
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
