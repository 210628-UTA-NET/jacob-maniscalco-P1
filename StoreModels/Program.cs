using System;

namespace StoreModels
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer me = new Customer();

            me.Address = "test";

            Console.WriteLine(me.Address);
            Console.WriteLine("Hello World!");
        }
    }
}
