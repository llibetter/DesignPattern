using System;
using System.Threading;
namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i=0;i<1000;i++)
            {
                new Thread(()=>{LazySingleton.getInstance();}).Start();
                new Thread(()=>{HungrySingleton.getInstance();}).Start();
            }

            Console.Read();
        }
    }

    //懒汉式单例，在调用getInstance函数时再实例化
    public class LazySingleton
    {
        private static volatile LazySingleton instance = null;
        private static object Singleton_Lock = new object();
        //private 避免类在外部被实例化
        private LazySingleton() {
            Console.WriteLine("创建了一个懒汉式单例");
        }    
        public static LazySingleton getInstance()
        {
            //双重if+lock，第一个if是为了避免每次都加锁，提升效率
            //第二个if是为了多线程安全
            if (instance == null)
            {
                lock (Singleton_Lock)
                {
                    if (instance == null)
                        instance = new LazySingleton();
                }
            }
            return instance;
        }
    }
    //饿汉式单例，类加载时就已经初始化实例
    public class HungrySingleton
    {
        private static volatile HungrySingleton instance = new HungrySingleton();
        private HungrySingleton() {
            Console.WriteLine("创建了一个饿汉式单例");
        }
        public static HungrySingleton getInstance()
        {
            return instance;
        }
    }
}
