using System;

namespace 建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            Product product = director.construct();
            product.show();

            Console.Read();
        }
    }
    /*
    建造者（Builder）模式的定义：指将一个复杂对象的构造与它的表示分离，使同样的构建过程可以创建不同的表示，这样的设计模式被称为建造者模式。
    它是将一个复杂的对象分解为多个简单的对象，然后一步一步构建而成。它将变与不变相分离，即产品的组成部分是不变的，但每一部分是可以灵活选择的。

    建造者（Builder）模式的主要角色如下。
    产品角色（Product）：它是包含多个组成部件的复杂对象，由具体建造者来创建其各个零部件。
    抽象建造者（Builder）：它是一个包含创建产品各个子部件的抽象方法的接口，通常还包含一个返回复杂产品的方法 getResult()。
    具体建造者(ConcreteBuilder）：实现 Builder 接口，完成复杂产品的各个部件的具体创建方法。
    指挥者（Director）：它调用建造者对象中的部件构造与装配方法完成复杂对象的创建，在指挥者中不涉及具体产品的信息。
    */
    public class Product
    {
        string partA;
        string partB;
        string partC;

        public void setA(string s)
        {
            partA = s;
        }

        public void setB(string s)
        {
            partB = s;
        }

        public void setC(string s)
        {
            partC = s;
        }

        public void show()
        {
            //显示产品的特性
        }
    }

    public abstract class Builder
    {
        protected Product product = new Product();
        public abstract void buildA();

        public abstract void buildB();

        public abstract void buildC();

        public Product getResult()
        {
            return product;
        }
    }

    public class ConcreteBuilder : Builder
    {
        public override void buildA()
        {
            Console.WriteLine("建造A部分");
            product.setA("建造 PartA");
        }
        public override void buildB()
        {
            Console.WriteLine("建造B部分");
            product.setB("建造 PartB");
        }
        public override void buildC()
        {
            Console.WriteLine("建造C部分");
            product.setC("建造 PartC");
        }
    }

    class Director
    {
        private Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        //产品构建与组装方法
        public Product construct()
        {
            builder.buildA();
            builder.buildB();
            builder.buildC();
            return builder.getResult();
        }
    }
}
