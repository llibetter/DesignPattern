using System;
using System.Collections.Generic;
namespace 享元模式
{
    /*
    享元模式是通过减少内存中对象的数量来节省内存空间的，所以以下几种情形适合采用享元模式。
系统中存在大量相同或相似的对象，这些对象耗费大量的内存资源。
大部分的对象可以按照内部状态进行分组，且可将不同部分外部化，这样每一个组只需保存一个内部状态。
由于享元模式需要额外维护一个保存享元的数据结构，所以应当在有足够多的享元实例时才值得使用享元模式。
    */
    class Program
    {
        static void Main(string[] args)
        {
            FlyweightFactory factory = new FlyweightFactory();
            Flyweight f01 = factory.getFlyweight("a");
            Flyweight f02 = factory.getFlyweight("a");
            Flyweight f03 = factory.getFlyweight("a");
            Flyweight f11 = factory.getFlyweight("b");
            Flyweight f12 = factory.getFlyweight("b");
            f01.operation(new UnsharedConcreteFlyweight("第1次调用a。"));
            f02.operation(new UnsharedConcreteFlyweight("第2次调用a。"));
            f03.operation(new UnsharedConcreteFlyweight("第3次调用a。"));
            f11.operation(new UnsharedConcreteFlyweight("第1次调用b。"));
            f12.operation(new UnsharedConcreteFlyweight("第2次调用b。"));

            Console.Read();
        }
    }


    //非享元角色
    class UnsharedConcreteFlyweight
    {
        private String info;
        public UnsharedConcreteFlyweight(String _info)
        {
            info = _info;
        }
        public String getInfo()
        {
            return info;
        }
        public void setInfo(String _info)
        {
            info = _info;
        }
    }
    //抽象享元角色
    interface Flyweight
    {
        public void operation(UnsharedConcreteFlyweight state);
    }
    //具体享元角色
    class ConcreteFlyweight : Flyweight
    {
        private String key;
        public ConcreteFlyweight(String key)
        {
            this.key = key;
            Console.WriteLine("具体享元" + key + "被创建！");
        }
        public void operation(UnsharedConcreteFlyweight outState)
        {
            Console.WriteLine("具体享元" + key + "被调用，");
            Console.WriteLine("非享元信息是:" + outState.getInfo());
        }
    }
    //享元工厂角色
    class FlyweightFactory
    {
        private Dictionary<String, Flyweight> flyweights = new Dictionary<String, Flyweight>();
        public Flyweight getFlyweight(String key)
        {
            Flyweight flyweight;
            if (flyweights.ContainsKey(key))
            {
                flyweight = (Flyweight)flyweights[key];
                Console.WriteLine("具体享元" + key + "已经存在，被成功获取！");
            }
            else
            {
                flyweight = new ConcreteFlyweight(key);
                flyweights.Add(key, flyweight);
            }
            return flyweight;
        }
    }
}
