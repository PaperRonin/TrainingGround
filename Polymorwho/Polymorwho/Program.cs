using System;
using System.Reflection;

namespace Polymorwho
{
    public static class ColorfulPrinter
    {
        public static void Print(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
    public class BaseClass
    {
        private ConsoleColor color = ConsoleColor.Green;
        public virtual void VirtualMethod1()
        {
            ColorfulPrinter.Print( "VirtualMethod1", color);
        }

        public virtual void VirtualMethod2()
        {
            ColorfulPrinter.Print( "VirtualMethod2", color);
        }

        public void NonVirtualMethod1()
        {
            ColorfulPrinter.Print( "NonVirtualMethod1", color);
        }

        public void NonVirtualMethod2()
        {
            ColorfulPrinter.Print( "NonVirtualMethod2", color);
        }

    }


    public class Derived : BaseClass
    {

        private ConsoleColor color = ConsoleColor.Yellow;
        public override void VirtualMethod1()
        {
            ColorfulPrinter.Print("Derived VirtualMethod1", color);
        }

        public new void VirtualMethod2()
        {
            ColorfulPrinter.Print( "Derived VirtualMethod2", color);
        }

        public new void NonVirtualMethod1()
        {
            ColorfulPrinter.Print( "Derived NonVirtualMethod1", color);
        }


    }

    public class DoubleDerived : Derived
    {
        private ConsoleColor color = ConsoleColor.Red;
        public override void VirtualMethod1()
        {
            base.VirtualMethod1();
            ColorfulPrinter.Print( "DoubleDerived VirtualMethod1", color);
        }

        public new void VirtualMethod2()
        {
            ColorfulPrinter.Print( "DoubleDerived VirtualMethod2", color);
        }

        public new void NonVirtualMethod2()
        {
            base.NonVirtualMethod2();
            ColorfulPrinter.Print( "DoubleDerived NonVirtualMethod2", color);
        }
    }

    public class DoubleDerivedCracked : DoubleDerived
    {
        private ConsoleColor color = ConsoleColor.Cyan;
        public new void VirtualMethod1()
        {
            var type = typeof(BaseClass);
            MethodInfo method = type.GetMethod("VirtualMethod1");
            method?.Invoke((BaseClass)this, new object[] { }); 
            ColorfulPrinter.Print("DoubleDerived VirtualMethod1", color);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            DoubleDerivedCracked instance = new DoubleDerivedCracked();

            BaseClass instance2 = new BaseClass();

            instance.VirtualMethod1();
            instance.VirtualMethod2();
            instance.NonVirtualMethod1();
            instance.NonVirtualMethod2();

            Console.WriteLine(new string('-',50));

            instance2.VirtualMethod1();
            instance2.VirtualMethod2();
            instance2.NonVirtualMethod1();
            instance2.NonVirtualMethod2();

        }
    }
}
