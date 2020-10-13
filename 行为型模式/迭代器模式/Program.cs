using System;
using System.Collections.Generic;
namespace 迭代器模式
{
    /*
    迭代器模式主要包含以下角色。
抽象聚合（Aggregate）角色：定义存储、添加、删除聚合对象以及创建迭代器对象的接口。
具体聚合（ConcreteAggregate）角色：实现抽象聚合类，返回一个具体迭代器的实例。
抽象迭代器（Iterator）角色：定义访问和遍历聚合元素的接口，通常包含 hasNext()、first()、next() 等方法。
具体迭代器（Concretelterator）角色：实现抽象迭代器接口中所定义的方法，完成对聚合对象的遍历，记录遍历的当前位置。
    */

    //由于聚合与迭代器的关系非常密切，所以大多数语言在实现聚合类时都提供了迭代器类，因此大数情况下使用语言中已有的聚合类的迭代器就已经够了。
    class Program
    {
        static void Main(string[] args)
        {
            Aggregate aggregate=new ConcreteAggregate();
            aggregate.add("hello");
            aggregate.add("world");
            aggregate.add("你好");
            aggregate.add("世界");

            Iterator iterator=aggregate.GetIterator();
            while(iterator.hasNext())
            {
                Console.WriteLine(iterator.next());
            }

            Console.Read();
        }
    }

    //抽象聚合（被迭代对象）
    interface Aggregate
    {
        void add(object o);
        void remove(object o);
        public Iterator GetIterator();
    }

    //具体聚合（被迭代对象）
    public class ConcreteAggregate:Aggregate
    {
        List<object> list=new List<object>();
        public void add(object o)
        {
            list.Add(o);
        }

        public void remove(object o)
        {
            list.Remove(o);
        }

        public Iterator GetIterator()
        {
            return new ConcreteIterator(list);
        }
    }

    //抽象迭代器
    public interface Iterator
    {
        object first();
        object next();
        bool hasNext();
    }

    //具体迭代器
    class ConcreteIterator:Iterator
    {
        List<object> list;
        int index=-1;
        public ConcreteIterator(List<object> l)
        {
            list=l;
        }

        public object first()
        {
            index=0;
            return list[0];
        }

        public object next()
        {
            object obj=null;
            if(hasNext())
            {
                obj=list[++index];
            }
            return obj;
        }

        public bool hasNext()
        {
            return index<list.Count-1;
        }
    }
}
