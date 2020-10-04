using System;

namespace 桥接模式
{
    //当一个类存在多个维度的变化，使用继承就造成数量众多的子类，扩展困难
    //桥接模式使用组合关系替代继承关系，降低了抽象和实现这两个可变维度的耦合度。
    /*
    桥接（Bridge）模式包含以下主要角色。
抽象化（Abstraction）角色：定义抽象类，并持有实现化对象的引用。-----包
扩展抽象化（RefinedAbstraction）角色：是抽象化角色的子类，实现父类中的业务方法，并通过组合关系调用实现化角色中的业务方法。----书包、钱包
实现化（Implementor）角色：定义实现化角色的接口，供扩展抽象化角色调用。-----颜色
具体实现化（ConcreteImplementor）角色：给出实现化角色接口的具体实现。-------红色、黄色


    */
    class Program
    {
        static void Main(string[] args)
        {
            Implementor implementor=new ConcreteImplementA();
            Abstraction abstraction=new RefinedAbstraction(implementor);
            abstraction.Operation();

            Console.Read();
        }
    }

    //实现化角色
    interface Implementor
    {
        public void OperationImp1();
    }
    //具体实现化角色
    public class ConcreteImplementA:Implementor
    {
        public void OperationImp1()
        {
            Console.WriteLine("具体实现化角色被访问");
        }
    }
    //抽象化角色
    abstract class Abstraction
    {
        protected Implementor implementor;

        protected Abstraction(Implementor i)
        {
            implementor=i;
        }

        public abstract void Operation();

    }
    //扩展抽象化角色
    class RefinedAbstraction:Abstraction
    {
        public RefinedAbstraction(Implementor i):base(i)
        {

        }

        public override void Operation()
        {
            implementor.OperationImp1();
            Console.WriteLine("扩展抽象化角色被访问");
        }
    }
}
