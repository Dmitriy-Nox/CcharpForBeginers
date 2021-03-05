using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Data;
using Shop.Menu;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassShop classShop = new ClassShop();
            Console.SetWindowSize(100, 50);
            classShop.Start();
        }

        


    }
}
