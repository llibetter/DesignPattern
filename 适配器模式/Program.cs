using System;

namespace 适配器模式
{
    class Program
    {
        //适配器模式和代理模式都属于结构型模式，二者很相似
        //二者都是在被适配者和被代理者外面，再包装一层,用于客户端调用
        //不同的是，适配器模式倾向于用一个接口统一各个类的调用方式，
        //代理模式的包装通常是为了，在调用被代理类之前或之后做一些预处理和收尾工作
        //应该说，这两个模式的目的是不同的。
        static void Main(string[] args)
        {
            ITatget it;
            it=new Adapter1();
            it.request(); //这里被适配者原先的方法名是request1，被适配之后可以用统一的request调用

            it=new Adapter2();
            it.request(); //这里被适配者原先的方法名是request2，被适配之后可以用统一的request调用

            Console.Read();
        }
    }


 
    class Adaptee1
    {
        public void request1()
        {
            Console.WriteLine("大家好，我是适配者1号");
        }
    }

    class Adaptee2
    {
        public void request2()
        {
            Console.WriteLine("大家好，我是适配者2号");
        }
    }


       //目标接口
    interface ITatget
    {
        public void request();
    }

    class Adapter1:Adaptee1,ITatget
    {
        public void request()
        {
            request1();
        }
    }

    class Adapter2:Adaptee2,ITatget
    {
        public void request()
        {
            request2();
        }
    }

}
