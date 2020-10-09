using System;

//今天学习职责链模式。顾名思义就是一个连着一个处理模块，像链表一样,所以处理者里有个next。模式比较简单，看一眼就明白，属于行为型设计模式。

/*
职责链模式主要包含以下角色。
抽象处理者（Handler）角色：定义一个处理请求的接口，包含抽象处理方法和一个后继连接。
具体处理者（Concrete Handler）角色：实现抽象处理者的处理方法，判断能否处理本次请求，如果可以处理请求则处理，否则将该请求转给它的后继者。
客户类（Client）角色：创建处理链，并向链头的具体处理者对象提交请求，它不关心处理细节和请求的传递过程。

职责链模式存在以下两种情况。
纯的职责链模式：一个请求必须被某一个处理者对象所接收，且一个具体处理者对某个请求的处理只能采用以下两种行为之一：
自己处理（承担责任）；把责任推给下家处理。

不纯的职责链模式：允许出现某一个具体处理者对象在承担了请求的一部分责任后又将剩余的责任传给下家的情况，
且一个请求可以最终不被任何接收端对象所接收。
*/

namespace 责任链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler handler1=new ConcreteHandler1();
            Handler handler2=new ConcreteHandler2();
            handler1.SetNext(handler2);

            handler1.handleRequest("One");
            Console.WriteLine("---------------------------------------");
            handler1.handleRequest("Two");
            Console.WriteLine("---------------------------------------");
            handler1.handleRequest("Three");
                    
            Console.Read();
        }
    }

    abstract class Handler
    {
        private Handler next;

        public void SetNext(Handler h)
        {
            next = h;
        }

        public Handler GetNext()
        {
            return next;
        }

        public abstract void handleRequest(string req);
    }

    class ConcreteHandler1 : Handler
    {
        public override void handleRequest(string req)
        {
            if (req == "One")
                Console.WriteLine("具体处理者1号正在处理！");
            else
            {
                if (GetNext() != null)
                    GetNext().handleRequest(req);
                else
                    Console.WriteLine("具体处理者1号无法处理，并且无后续处理者");
            }
        }
    }

    class ConcreteHandler2 : Handler
    {
        public override void handleRequest(string req)
        {
            if (req == "Two")
                Console.WriteLine("具体处理者2号正在处理！");
            else
            {
                if (GetNext() != null)
                    GetNext().handleRequest(req);
                else
                    Console.WriteLine("具体处理者2号无法处理，并且无后续处理者");
            }
        }
    }
}
