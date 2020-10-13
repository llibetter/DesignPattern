using System;
using System.Threading;
namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                new Thread(() => { Singleton1.getInstance(); }).Start();
                new Thread(() => { Singleton2.getInstance(); }).Start();
                new Thread(() => { Singleton3.getInstance(); }).Start();
                new Thread(() => { Singleton4.getInstance(); }).Start();
            }

            Console.Read();
        }
    }

    //懒汉式单例，在调用getInstance函数时再实例化
    public class Singleton1
    {
        private static volatile Singleton1 instance = null;
        private static readonly object obj = new object();
        //private 避免类在外部被实例化
        private Singleton1()
        {
            Console.WriteLine("创建了一个Singleton1");
        }
        public static Singleton1 getInstance()
        {
            //双重if+lock，第一个if是为了避免每次都加锁，提升效率
            //第二个if是为了多线程安全
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                        instance = new Singleton1();
                }
            }
            return instance;
        }
    }


    //饿汉式单例，类加载时就已经初始化实例，静态字段直接new
    public class Singleton2
    {
        private static volatile Singleton2 instance = new Singleton2();
        private Singleton2()
        {
            Console.WriteLine("创建了一个Singleton2");
        }
        public static Singleton2 getInstance()
        {
            return instance;
        }
    }

    //静态构造函数
    public class Singleton3
    {
        private Singleton3()
        {
            Console.WriteLine("创建了一个Singleton3");
        }

        static Singleton3()
        {
            _instance = new Singleton3();

        }
        private static Singleton3 _instance = null;
        public static Singleton3 getInstance()
        {
            return _instance;
        }
    }

    //利用Lazy按需加载
    public sealed class Singleton4
    {
        private Singleton4()
        {
            Console.WriteLine("创建了一个Singleton4");
        }
        private static readonly Lazy<Singleton4> lazy =
            new Lazy<Singleton4>(() =>{ return new Singleton4();});

        //public static Singleton4 Instance { get { return lazy.Value; } }

        public static Singleton4 getInstance()
        {
            return lazy.Value;
        }
    }
}
