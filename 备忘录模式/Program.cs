using System;

namespace 备忘录模式
{

    /*
    备忘录模式的主要角色如下。
    发起人（Originator）角色：记录当前时刻的内部状态信息，提供创建备忘录和恢复备忘录数据的功能，实现其他业务功能，它可以访问备忘录里的所有信息。
    备忘录（Memento）角色：负责存储发起人的内部状态，在需要的时候提供这些内部状态给发起人。
    管理者（Caretaker）角色：对备忘录进行管理，提供保存与获取备忘录的功能，但其不能对备忘录的内容进行访问与修改。
    */
    class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();
            //设定初始状态
            originator.setState("hello");
            Console.WriteLine($"初始状态：{originator.getState()}");
            //保存状态
            careTaker.setMemento(originator.CreatMemento());
            //修改状态
            originator.setState("world");
            Console.WriteLine($"修改后状态：{originator.getState()}");

            //恢复状态
            originator.restoreMemento(careTaker.GetMemento());
            Console.WriteLine($"恢复后状态：{originator.getState()}");
            
            Console.Read();
        }
    }

    class Memento
    {
        string state;
        public Memento(string s)
        {
            state = s;
        }

        public void setState(string s)
        {
            state = s;
        }

        public string getState()
        {
            return state;
        }
    }

    class Originator
    {
        private string state;

        public void setState(string s)
        {
            state = s;
        }

        public string getState()
        {
            return state;
        }

        public Memento CreatMemento()
        {
            return new Memento(state);
        }

        public void restoreMemento(Memento m)
        {
            state = m.getState();
        }
    }


    class CareTaker
    {
        private Memento memento;

        public void setMemento(Memento mem)
        {
            memento = mem;
        }

        public Memento GetMemento()
        {
            return memento;
        }
    }
}
