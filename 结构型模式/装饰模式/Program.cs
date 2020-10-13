using System;

namespace 装饰模式
{
    /*
    装饰模式，属于结构型模式，目的是，在不改变现有对象结构的前提下，动态地给对象增加一些功能
    装饰模式主要包含以下角色，构件=被装饰类
抽象构件（Component）角色：定义一个抽象接口以规范准备接收附加责任的对象。
具体构件（ConcreteComponent）角色：实现抽象构件，通过装饰角色为其添加一些职责。
抽象装饰（Decorator）角色：继承抽象构件，并包含具体构件的实例，可以通过其子类扩展具体构件的功能。
具体装饰（ConcreteDecorator）角色：实现抽象装饰的相关方法，并给具体构件对象添加附加的责任。

装饰模式通常在以下几种情况使用。
当需要给一个现有类添加附加职责，而又不能采用生成子类的方法进行扩充时。例如，该类被隐藏或者该类是终极类或者采用继承方式会产生大量的子类。
当需要通过对现有的一组基本功能进行排列组合而产生非常多的功能时，采用继承关系很难实现，而采用装饰模式却很好实现。
当对象的功能要求可以动态地添加，也可以再动态地撤销时。

    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("单独调用被装饰类");
            Component component=new ConcreteComponent();
            component.operation();

            Console.WriteLine("通过调用装饰类调用被装饰类");
            component=new ConcreteDecorator(component);
            component.operation();

            Console.Read();
        }
    }

    interface Component
    {
        public void operation();

    }

    class ConcreteComponent:Component
    {
        public void operation()
        {
            Console.WriteLine("大家好，我来自被装饰类");
        }
    }

    class Decorator :Component
    {
        public Component component;
        public Decorator(Component c)
        {
            component=c;
        }

        public virtual void operation()
        {
            component.operation();
        }
    }

    class ConcreteDecorator:Decorator
    {
        public ConcreteDecorator(Component c):base(c)
        {
            
        }
        public override void operation()
        {
            base.operation();
            AddFunction();
        }

        public void AddFunction()
        {
            Console.WriteLine("大家好，我来自具体装饰类，我可以提供额外的功能");
        }
    }
}
