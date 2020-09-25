using System;

namespace 简单工厂
{
    class Program
    {
        static void Main(string[] args)
        {
            IProduct ipro = null;
            ipro = SimpleFactory.CreatProduct("1");
            ipro.show();
            ipro = SimpleFactory.CreatProduct("2");
            ipro.show();
            Console.Read();
        }
    }

    public interface IProduct
    {
        void show();
    }

    public class ConcreteProduct1 : IProduct
    {
        public void show()
        {
            Console.WriteLine("大家好，我是具体产品1号");
        }
    }

    public class ConcreteProduct2 : IProduct
    {
        public void show()
        {
            Console.WriteLine("大家好，我是具体产品2号");
        }
    }


    public class SimpleFactory
    {
        public static IProduct CreatProduct(string str)
        {
            if (str == "1")
            {
                return new ConcreteProduct1();
            }
            else if (str == "2")
            {
                return new ConcreteProduct2();
            }
            return null;
        }
    }


}
