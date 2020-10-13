using System;
using System.Collections.Generic;
namespace 策略模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //普通策略模式
            Context context = new Context();
            context.SetStrategy(new ConcreteStrategyA());
            context.StrategyMethod();

            context.SetStrategy(new ConcreteStrategyB());
            context.StrategyMethod();

            //策略工厂模式，利用哈希表消除过多的判断语句
            ContextFactory contextFactory = new ContextFactory();
            contextFactory.SetStrategy("A", new ConcreteStrategyA());
            contextFactory.SetStrategy("B", new ConcreteStrategyB());
            contextFactory.StrategyMethod("A");
            contextFactory.StrategyMethod("B");

            Console.Read();
        }
    }


    interface Strategy
    {
        void StrategyMethod();
    }

    class ConcreteStrategyA : Strategy
    {
        public void StrategyMethod()
        {
            Console.WriteLine("大家好，我是策略A，我正在提供服务");
        }
    }

    class ConcreteStrategyB : Strategy
    {
        public void StrategyMethod()
        {
            Console.WriteLine("大家好，我是策略B，我正在提供服务");
        }
    }

    //环境类，持有一个策略类，通过Context调用各个具体策略类
    class Context
    {
        private Strategy strategy;
        public Strategy GetStrategy()
        {
            return strategy;
        }

        public void SetStrategy(Strategy s)
        {
            strategy = s;
        }

        public void StrategyMethod()
        {
            strategy.StrategyMethod();
        }
    }

    //一般来说，策略模式经常和工厂模式一起使用，利用哈希表Map，来消除过多的if else
    class ContextFactory
    {
        Dictionary<string, Strategy> dictionary = new Dictionary<string, Strategy>();

        public Strategy GetStrategy(string s)
        {
            if (dictionary.ContainsKey(s))
                return dictionary[s];
            return null;
        }

        public void SetStrategy(string s, Strategy strategy)
        {
            if (!dictionary.ContainsKey(s))
                dictionary.Add(s, strategy);
            else
                dictionary[s] = strategy;
        }

        public void StrategyMethod(string s)
        {
            if (!dictionary.ContainsKey(s))
                return;
            dictionary[s].StrategyMethod();
        }
    }
}
