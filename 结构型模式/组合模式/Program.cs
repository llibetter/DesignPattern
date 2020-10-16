using System;
using System.Collections.Generic;
namespace 组合模式
{
    /*
    组合（Composite）模式的定义：有时又叫作部分-整体模式，它是一种将对象组合成树状的层次结构的模式，
    用来表示“部分-整体”的关系，使用户对单个对象和组合对象具有一致的访问性。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            Component c0 = new Composite();
            Component c1 = new Composite();
            Component leaf1 = new Leaf("1");
            Component leaf2 = new Leaf("2");
            Component leaf3 = new Leaf("3");
            
            c0.add(leaf1);
            c0.add(c1);
            c1.add(leaf2);
            c1.add(leaf3);
            
            c0.operation();

            Console.Read();
        }
    }

    //抽象构件
    interface Component
    {
        public void add(Component c);
        public void remove(Component c);
        public Component getChild(int i);
        public void operation();
    }
    //树叶构件
    class Leaf : Component
    {
        private String name;
        public Leaf(String name)
        {
            this.name = name;
        }
        public void add(Component c) { }
        public void remove(Component c) { }
        public Component getChild(int i)
        {
            return null;
        }
        public void operation()
        {
            Console.WriteLine("树叶" + name + "：被访问！");
        }
    }
    //树枝构件
    class Composite : Component
    {
        private List<Component> children = new List<Component>();
        public void add(Component c)
        {
            children.Add(c);
        }
        public void remove(Component c)
        {
            children.Remove(c);
        }
        public Component getChild(int i)
        {
            return children[i];
        }
        public void operation()
        {
            foreach (Object obj in children)
            {
                ((Component)obj).operation();
            }
        }
    }
}
