﻿using System;

namespace 状态模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();       
            context.Handle();    
            context.Handle();
            context.Handle();
            context.Handle();

            Console.Read();
        }
    }

    //环境类
    class Context
    {
        private State state;
        //定义环境类的初始状态
        public Context()
        {
            this.state = new ConcreteStateA();
        }
        //设置新状态
        public void setState(State state)
        {
            this.state = state;
        }
        //读取状态
        public State getState()
        {
            return state;
        }
        //对请求做处理
        public void Handle()
        {
            state.Handle(this);
        }
    }
    //抽象状态类
    abstract class State
    {
        public abstract void Handle(Context context);
    }
    //具体状态A类
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("当前状态是 A.");
            context.setState(new ConcreteStateB());
        }
    }
    //具体状态B类
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            Console.WriteLine("当前状态是 B.");
            context.setState(new ConcreteStateA());
        }
    }
}
