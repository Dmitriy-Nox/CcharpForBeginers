using System;
using System.Collections.Generic;
using NewShop.ServerControl;
using NewShop.View;

namespace NewShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);
            Console.WriteLine("1) Запуск сервера магазина");
            Console.WriteLine("2) Запуск локального магазина ");
            var num = 0;
            while (true)
            {
                var isConvert = int.TryParse(Console.ReadLine(), out num);
                if (isConvert && num > 0 && num <= 2)
                    break;
                else

                    Console.WriteLine("Некорректное значение. Повторите ввод");
            }
            switch (num)
            {
                case 1:
                    Console.Clear();
                    var ServerShop = new ServerShop(new ViewServer());
                    ServerShop.Start();
                    break;
                    
                case 2:
                    Console.Clear();
                    var LocalShop = new Shop(new ViewLocal());
                    LocalShop.Start();
                    break;
            }
        }
    }
}
