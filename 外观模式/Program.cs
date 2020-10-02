using System;

namespace 外观模式
{
    /*外观（Facade）模式的结构比较简单，主要是定义了一个高层接口。它持有各个子系统的引用，客户端可以通过它访问各个子系统的功能
    外部应用程序不用关心内部子系统的具体的细节，这样会大大降低应用程序的复杂度，提高了程序的可维护性。
    
    外观（Facade）模式是“迪米特法则”的典型应用，它有以下主要优点。
    降低了子系统与客户端之间的耦合度，使得子系统的变化不会影响调用它的客户类。
    对客户屏蔽了子系统组件，减少了客户处理的对象数目，并使得子系统使用起来更加容易。
    降低了大型软件系统中的编译依赖性，简化了系统在不同平台之间的移植过程，因为编译一个子系统不会影响其他的子系统，也不会影响外观对象。
    
    外观模式和代理模式、适配器模式的共同点，都是通过定义一个高层接口，其目的不尽相同
    外观模式是为了方便客户端调用，各个子系统对客户端是透明不可见的
    代理模式通常是为了在算法前后增加预处理或收尾工作
    适配器模式是为了使客户端调用方法统一
    */
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade=new Facade();
            facade.Method();

            Console.Read();
        }
    }


    class Facade
    {
        Subsystem1 subsystem1=new Subsystem1();
        Subsystem2 subsystem2=new Subsystem2();
        Subsystem3 subsystem3=new Subsystem3();

        public void Method()
        {
            subsystem1.Method1();
            subsystem2.Method2();
            subsystem3.Method3();
        }
    }

    class Subsystem1
    {
        public void Method1()
        {
            Console.WriteLine("大家好，我是子系统一号的服务");
        }
    }

    class Subsystem2
    {
        public void Method2()
        {
            Console.WriteLine("大家好，我是子系统二号的服务");
        }
    }

    class Subsystem3
    {
        public void Method3()
        {
            Console.WriteLine("大家好，我是子系统三号的服务");
        }
    }


}
