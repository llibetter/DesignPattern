using System;
using System.Collections.Generic;
namespace 观察者
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject cs = new ConcreteSubject("小王");
            cs.add(new ConcreteObserver("小明"));
            cs.add(new ConcreteObserver("小李"));
            cs.add(new ConcreteObserver("小红"));
            cs.add(new ConcreteObserver("小张"));
            //小王通知大家，今天挣了一百块，请大伙来吃饭
            cs.notify($"今天挣了一百块，大家来吃饭");
            Console.Read();
        }
    }
    //抽象主题，被观察者
    public abstract class Subject
    {
        protected List<IObserver> observers = new List<IObserver>();

        public void add(IObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void remove(IObserver observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }
        public abstract void notify(string str);

    }


    //具体主题
    public class ConcreteSubject : Subject
    {
        public string Name { get; set; }
        public ConcreteSubject(string _name)
        {
            Name = _name;
        }

        public override void notify(string str)
        {
            foreach (var item in observers)
            {
                item.Update($"{Name}{str}");
            }
        }
    }
    //抽象观察者，接口
    public interface IObserver
    {
        public void Update(string str);
    }

    //具体观察者
    public class ConcreteObserver : IObserver
    {
        public string Name{get;set;}
        public ConcreteObserver(string _name)
        {
            Name = _name;
        }

        public void Update(string str)
        {
            Console.WriteLine($"{Name}收到通知：{str}");
        }
    }
}
