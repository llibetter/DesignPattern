using System;

namespace 模板方法模式
{
    class Program
    {
        /*
        模板方法模式的应用场景
        算法的整体步骤很固定，但其中个别部分易变时，这时候可以使用模板方法模式，将容易变的部分抽象出来，供子类实现。
        当多个子类存在公共的行为时，可以将其提取出来并集中到一个公共父类中以避免代码重复。
        首先，要识别现有代码中的不同之处，并且将不同之处分离为新的操作。最后，用一个调用这些新的操作的模板方法来替换这些不同的代码。
        当需要控制子类的扩展时，模板方法只在特定点调用钩子操作，这样就只允许在这些点进行扩展。

        总结吸收一下，模板方法就是把相同的部分提取出来到父类，不同的部分用抽象函数给子类自己实现，最终客户端调用一个模板方法，实现多态
        */
        static void Main(string[] args)
        {
            AbstractClass abstractClass;
            
            abstractClass=new ConcreteClassA();
            abstractClass.TemplateMethod();

            abstractClass=new ConcreteClassB();
            abstractClass.TemplateMethod();

            Console.Read();
        }
    }


    abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            CommonMethod();
            SpecialMethod();
        }

        public void CommonMethod()
        {
            Console.WriteLine("我是算法的公共部分");
        }

        public abstract void SpecialMethod();
    }

    class ConcreteClassA:AbstractClass
    {
        public override void SpecialMethod()
        {
            Console.WriteLine("我是子类算法A中的不同部分");
        }
    }

    class ConcreteClassB:AbstractClass
    {
        public override void SpecialMethod()
        {
            Console.WriteLine("我是子类算法B中的不同部分");
        }
    }
}
