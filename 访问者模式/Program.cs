using System;
using System.Collections.Generic;
namespace 访问者模式
{

    /*
    访问者模式包含以下主要角色。
抽象访问者（Visitor）角色：定义一个访问具体元素的接口，为每个具体元素类对应一个访问操作 visit() ，该操作中的参数类型标识了被访问的具体元素。
具体访问者（ConcreteVisitor）角色：实现抽象访问者角色中声明的各个访问操作，确定访问者访问一个元素时该做什么。
抽象元素（Element）角色：声明一个包含接受操作 accept() 的接口，被接受的访问者对象作为 accept() 方法的参数。
具体元素（ConcreteElement）角色：实现抽象元素角色提供的 accept() 操作，其方法体通常都是 visitor.visit(this) ，另外具体元素中可能还包含本身业务逻辑的相关操作。
对象结构（Object Structure）角色：是一个包含元素角色的容器，提供让访问者对象遍历容器中的所有元素的方法，通常由 List、Set、Map 等聚合类实现。
    */
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure objectStructure = new ObjectStructure();
            objectStructure.Add(new ConcreteElement1());
            objectStructure.Add(new ConcreteElement2());

            Visitor visitor = new ConcreteVisitor1();
            objectStructure.accept(visitor);

            visitor = new ConcreteVisitor2();
            objectStructure.accept(visitor);

            Console.Read();
        }
    }

    interface Element
    {
        void accept(Visitor visitor);
    }

    class ConcreteElement1 : Element
    {
        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public string OperationA()
        {
            return "具体元素1的操作";
        }
    }

    class ConcreteElement2 : Element
    {
        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public string OperationB()
        {
            return "具体元素2的操作";
        }
    }

    interface Visitor
    {
        void visit(ConcreteElement1 element1);
        void visit(ConcreteElement2 element2);
    }

    class ConcreteVisitor1 : Visitor
    {
        public void visit(ConcreteElement1 element1)
        {
            Console.WriteLine($"具体访问者1访问：{element1.OperationA()}");
        }

        public void visit(ConcreteElement2 element2)
        {
            Console.WriteLine($"具体访问者1访问：{element2.OperationB()}");
        }
    }

    class ConcreteVisitor2 : Visitor
    {
        public void visit(ConcreteElement1 element1)
        {
            Console.WriteLine($"具体访问者2访问：{element1.OperationA()}");
        }

        public void visit(ConcreteElement2 element2)
        {
            Console.WriteLine($"具体访问者2访问：{element2.OperationB()}");
        }
    }

    class ObjectStructure
    {
        List<Element> list = new List<Element>();

        public void Add(Element element)
        {
            list.Add(element);
        }

        public void Remove(Element element)
        {
            list.Remove(element);
        }

        public void accept(Visitor visitor)
        {
            foreach (var item in list)
            {
                item.accept(visitor);
            }
        }
    }
}
