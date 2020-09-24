using System;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy=new Proxy();
            proxy.Request();
            Console.Read();
        }
    }


    public interface Subject
    {
        void Request();
    }
    public class ConcreteSubject : Subject
    {
        public void Request()
        {
            Console.WriteLine("我是真实主题，我正在提供服务");
        }
    }

    class Proxy : Subject
    {
        private ConcreteSubject realSubject;
        public void Request()
        {
            if (realSubject == null)
            {
                realSubject = new ConcreteSubject();
            }
            preRequest();
            realSubject.Request();
            postRequest();
        }
        public void preRequest()
        {
            Console.WriteLine("访问真实主题之前的预处理。");
        }
        public void postRequest()
        {
            Console.WriteLine("访问真实主题之后的后续处理。");
        }
    }


}
