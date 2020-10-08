using System;
using System.Collections.Generic;
namespace 解释器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Context bus = new Context();
            bus.freeRide("北京的老人");
            bus.freeRide("北京的壮年");
            bus.freeRide("广州的妇女");
            bus.freeRide("广州的儿童");
            bus.freeRide("山东的儿童");
            Console.Read();
        }
    }

    //抽象表达式类
    interface Expression
    {
        public bool interpret(String info);
    }
    //终结符表达式类
    class TerminalExpression : Expression
    {
        private HashSet<String> set = new HashSet<String>();
        public TerminalExpression(String[] data)
        {
            for (int i = 0; i < data.Length; i++) set.Add(data[i]);
        }
        public bool interpret(String info)
        {
            return set.Contains(info);
        }
    }
    //非终结符表达式类
    class NonTerminalExpression : Expression
    {
        private Expression city = null;
        private Expression person = null;
        public NonTerminalExpression(Expression city, Expression person)
        {
            this.city = city;
            this.person = person;
        }
        public bool interpret(String info)
        {
            String[] s = info.Split("的");
            return city.interpret(s[0]) && person.interpret(s[1]);
        }
    }

    //环境类
    /*文法规则
    <expression> ::= <city>的<person>
    <city> ::= 北京|广州
    <person> ::= 老人|妇女|儿童
    */
    class Context
    {
        private String[] citys = { "北京", "广州" };
        private String[] persons = { "老人", "妇女", "儿童" };
        private Expression cityPerson;
        public Context()
        {
            Expression city = new TerminalExpression(citys);
            Expression person = new TerminalExpression(persons);
            cityPerson = new NonTerminalExpression(city, person);
        }
        public void freeRide(String info)
        {
            bool ok = cityPerson.interpret(info);
            if (ok)
                Console.WriteLine($"{info},乘车免费");
            else
                Console.WriteLine($"{info},乘车2元");
        }
    }
}



/*
//抽象表达式类
interface AbstractExpression
{
    public Object interpret(String info);    //解释方法
}
//终结符表达式类
class TerminalExpression implements AbstractExpression
{
    public Object interpret(String info)
    {
        //对终结符表达式的处理
    }
}
//非终结符表达式类
class NonterminalExpression implements AbstractExpression
{
    private AbstractExpression exp1;
    private AbstractExpression exp2;
    public Object interpret(String info)
    {
        //非对终结符表达式的处理
    }
}
//环境类
class Context
{
    private AbstractExpression exp;
    public Context()
    {
        //数据初始化
    }
    public void operation(String info)
    {
        //调用相关表达式类的解释方法
    }
}
*/
