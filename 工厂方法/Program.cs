using System;

namespace 工厂方法
{
    class Program
    {
        //昨天我们写了简单工厂，这里我们发现存在一些问题
        //每当需要增加产品类别时，都需要修改工厂类
        //存在大量if else，代码越加越多
        //违背了开闭原则（对扩展开放对修改封闭）
        //因此我们创建抽象工厂（抽象类或接口），让具体工厂子类担任创建任务，达到高类聚低耦合
        static void Main(string[] args)
        {
            IFactory factory;
            IProduct product;
            factory = new Factory1();
            product = factory.CreateProduct();
            product.show();
            factory = new Factory2();
            product = factory.CreateProduct();
            product.show();

            Console.Read();
        }
    }

    //抽象产品
    interface IProduct
    {
        void show();
    }

    //具体产品1
    class ConcreteProduct1 : IProduct
    {
        public void show()
        {
            Console.WriteLine("大家好，我是具体产品1");
        }
    }
    //具体产品2
    class ConcreteProduct2 : IProduct
    {
        public void show()
        {
            Console.WriteLine("大家好，我是具体产品2");
        }
    }

    //抽象工厂
    interface IFactory
    {
        IProduct CreateProduct();
    }
    //具体工厂1
    class Factory1 : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ConcreteProduct1();
        }
    }
    //具体工厂2
    class Factory2 : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ConcreteProduct2();
        }
    }

}
