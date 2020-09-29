using System;
using System.Collections.Generic;
namespace 中介者模式
{
    class Program
    {
        //中介者模式和之前写过的观察者模式很相似，均属于行为型模式
        //观察者模式中观察者与被观察者（也叫主题），通常是多对一的关系
        //一个主题被多个观察者观察，观察是单方面的
        //中介者模式中，注册到中介者的各个类不直接联系，通过中介转发，呈现出多对多的关系
        //注册到中介的各个类，既可以发送通知也可以接收通知
        static void Main(string[] args)
        {
            IMediator mediator = new ConcreteMediator();
            WorkMate wm1 = new ConcreteMate1();
            WorkMate wm2 = new ConcreteMate2();
            mediator.register(wm1);
            mediator.register(wm2);
            wm1.send("今天老板要请大家吃麻辣烫");
            wm2.send("明天老板娘要请大家吃小龙虾");

            Console.Read();
        }
    }

    //中介接口
    //具备注册，转发功能
    interface IMediator
    {
        void register(WorkMate wm);
        void relay(WorkMate wm);
    }
    //具体中介者
    //持有一个所有同事列表
    class ConcreteMediator : IMediator
    {
        List<WorkMate> list = new List<WorkMate>();

        public void register(WorkMate wm)
        {
            if (list.Contains(wm))
                return;
            list.Add(wm);
            wm.setMed(this);
        }

        public void relay(WorkMate wm)
        {
            foreach (var item in list)
            {
                if (item != wm)
                    item.receive(wm.context);
            }
        }
    }

    //抽象同事类
    abstract class WorkMate
    {
        public IMediator mediator;

        public string context {get;set;}

        public void setMed(IMediator med)
        {
            mediator = med;
        }

        public abstract void send(string s);

        public abstract void receive(string s);
    }
    //具体同事类1
    class ConcreteMate1 : WorkMate
    {
        public override void send(string s)
        {
            context=s;
            Console.WriteLine($"同事一号发送:{s}");
            mediator.relay(this);
        }

        public override void receive(string s)
        {
            Console.WriteLine($"同事一号收到:{s}");
        }
    }
    //具体同事类2
    class ConcreteMate2 : WorkMate
    {
     
        public override void send(string s)
        {
            context=s;
            Console.WriteLine($"同事二号发送:{s}");
            mediator.relay(this);
        }

        public override void receive(string s)
        {
            Console.WriteLine($"同事二号收到:{s}");
        }
    }


}
