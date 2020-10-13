using System;

namespace 抽象工厂
{
    //昨天我们写了工厂方法模式，对每一个产品子类，都需要创建一个对应的工厂子类
    //如果类型很多，工厂子类就会越来越多
    //如果产品可以从两个维度划分，那么就可以应用抽象工厂模式
    //比如此处的种类（电视机、冰箱）和品牌（美的、海尔）
    //如果应用工厂方法，需要创建四个工厂子类，利用抽象工厂，只需要两个工厂子类
    //如果后续添加格力品牌，继续添加工厂子类即可，满足开闭原则
    //但是如果需要添加洗衣机种类，则对应所有工厂类都需要修改，又不满足开闭原则
    
    //抽象工厂模式最早的应用是用于创建属于不同操作系统的视窗构件。
    //如 Java 的 AWT 中的 Button 和 Text 等构件在 Windows 和 UNIX 中的本地实现是不同的。
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory;
            ITVProduct tv;
            IFridgeProduct fridge;
            factory = new MediaFactory();
            tv = factory.CreatTV();
            fridge = factory.CreatFridge();
            tv.show();
            fridge.show();

            factory = new HaierFactory();
            tv = factory.CreatTV();
            fridge = factory.CreatFridge();
            tv.show();
            fridge.show();

            Console.Read();
        }
    }



    //冰箱接口
    public interface IFridgeProduct
    {
        void show();
    }

    //美的冰箱
    class MediaFridge : IFridgeProduct
    {
        public void show()
        {
            Console.WriteLine("大家好，我是美的冰箱");
        }
    }
    //海尔冰箱
    class HaierFridge : IFridgeProduct
    {
        public void show()
        {
            Console.WriteLine("大家好，我是海尔冰箱");
        }
    }
    //电视机接口
    public interface ITVProduct
    {
        void show();
    }
    //美的电视机
    class MediaTV : ITVProduct
    {
        public void show()
        {
            Console.WriteLine("大家好，我是美的电视机");
        }
    }
    //海尔电视机
    class HaierTV : ITVProduct
    {
        public void show()
        {
            Console.WriteLine("大家好，我是海尔电视机");
        }
    }
    //抽象工厂
    interface IFactory
    {
        IFridgeProduct CreatFridge();

        ITVProduct CreatTV();
    }
    //海尔工厂
    public class HaierFactory : IFactory
    {
        public IFridgeProduct CreatFridge()
        {
            return new HaierFridge();
        }

        public ITVProduct CreatTV()
        {
            return new HaierTV();
        }
    }
    //美的工厂
    public class MediaFactory : IFactory
    {
        public IFridgeProduct CreatFridge()
        {
            return new MediaFridge();
        }

        public ITVProduct CreatTV()
        {
            return new MediaTV();
        }
    }
}
