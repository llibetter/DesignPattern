using System;

namespace 原型模式
{
    /*
    原型（Prototype）模式的定义如下：用一个已经创建的实例作为原型，通过复制该原型对象来创建一个和原型相同或相似的新对象
    原型模式通常适用于以下场景。
    对象之间相同或相似，即只是个别的几个属性不同的时候。
    创建对象成本较大，例如初始化时间长，占用CPU太多，或者占用网络资源太多等，需要优化资源。
    创建一个对象需要繁琐的数据准备或访问权限等，需要提高性能或者提高安全性。
    系统中大量使用该类对象，且各个调用者都需要给它的属性重新赋值。
    */

    //需要注意深浅拷贝的问题，如果需要深拷贝，对于嵌套的每个引用类型都需要支持深拷贝，代码实现起来比较复杂
    class Program
    {
        static void Main(string[] args)
        {
            Realizetype obj1 = new Realizetype();
            Realizetype obj2 = (Realizetype)obj1.Clone();
            Console.WriteLine("obj1==obj2?" + (obj1 == obj2));
            Console.WriteLine(obj1.GetHashCode());
            Console.WriteLine(obj2.GetHashCode());
            
            Console.Read();
        }
    }

    //具体原型类
    class Realizetype : ICloneable
    {
        public Realizetype()
        {
            Console.WriteLine("具体原型创建成功！");
        }
        public Object Clone()
        {
            Console.WriteLine("具体原型复制成功！");
            return (Realizetype)base.MemberwiseClone();
        }
    }
}
