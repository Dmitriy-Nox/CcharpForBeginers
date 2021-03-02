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
            bool showMenu = true;
            List<ClassProduct> classProductsMeat = new List<ClassProduct>() { new ClassProduct("Говядина", 10, 44.4m), new ClassProduct("Свинина", 16, 35.7m), new ClassProduct("Баранина", 8, 55.9m), new ClassProduct("Курица", 20, 23.1m), new ClassProduct("Суповой набор", 30, 35.4m) };
            List<ClassProduct> classProductsCheese = new List<ClassProduct>() { new ClassProduct("Масдам", 3, 56.7m), new ClassProduct("Российский", 17, 34.2m), new ClassProduct("Пармезан", 23, 98.3m), new ClassProduct("Камамбер", 4, 179.4m) };
            List<ClassProduct> classProductsVegetables = new List<ClassProduct>() { new ClassProduct("Картошка", 36, 12.5m), new ClassProduct("Морковь", 7, 12.1m), new ClassProduct("Помидоры", 13, 43.5m), new ClassProduct("Огурцы", 15, 25.6m), new ClassProduct("Капуста", 14, 5.4m), new ClassProduct("Салат дуболистный", 4, 12.2m) };

            List<ClassShowCase> listShowCase = new List<ClassShowCase>() { new ClassShowCase(100, "Мясная витрина") { ListClassProducts = classProductsMeat }, new ClassShowCase(100, "Сырная витрина") { ListClassProducts = classProductsCheese }, new ClassShowCase(100, "Овощная витрина") { ListClassProducts = classProductsVegetables } };
            ClassShopProducts.ListShowCases = listShowCase;
            CreateMenu();
            Menu();
        }

        static ClassShopProducts ClassShopProducts = new ClassShopProducts();
        static MenuContol MenuControl;
        static bool StartMenu = true;
        static void Menu()
        {
            Console.Clear();
            
                for (int i = 0; i < MenuControl.MenuBlock.CurrMenuBlock.Count; i++)
                {
                    Console.WriteLine(MenuControl.MenuBlock.CurrMenuBlock[i].Text);
                }

                int num = 0;
            if(int.TryParse(Console.ReadLine(),out num)&&num<= MenuControl.MenuBlock.CurrMenuBlock.Count)
                MenuControl.MenuBlock.CurrMenuBlock[Convert.ToInt32(num)].FuncMenuItem(Convert.ToInt32(num));

            if (StartMenu!=false)
                Menu();
            
        }
        

        static void CreateMenu()
        {

            #region Главное меню
            var MunuItems = new List<MenuItem>();

            var menu11 = new MenuItem("1) Создать новую витрину");
            menu11.FuncMenuItem+= CreateNewShowCase;
            MunuItems.Add(menu11);

            var menu12 = new MenuItem("2) Открыть витрину");
            menu12.FuncMenuItem += OpenShowCase;
            MunuItems.Add(menu12);

            var menu14 = new MenuItem("3) Удалить витрину");
            menu14.FuncMenuItem += DeliteShowCase;
            MunuItems.Add(menu14);

            var menu15 = new MenuItem("4) Выход");
            menu15.FuncMenuItem += Exit;
            MunuItems.Add(menu15);
            MenuControl = new MenuContol(MunuItems);
            #endregion

            #region Меню создания витрины
            var MunuItems1 = new List<MenuItem>();

            var menu21 = new MenuItem("1) Добавить витрину");
            menu21.FuncMenuItem += AddShowCase;
            MunuItems1.Add(menu21);

            var menu22 = new MenuItem("2) Выход");
            menu22.FuncMenuItem += ExitVitrin;
            MunuItems1.Add(menu22);
            MenuControl.MenuItems[1].NextMenuItems = MunuItems1;
            #endregion
            

            



            var MunuItems2 = new List<MenuItem>();
            MunuItems2.Add(new MenuItem("1) Добавить товар"));
            MunuItems2.Add(new MenuItem("2) Изменить колличество товара"));
            MunuItems2.Add(new MenuItem("3) Удалить товар"));
            MenuControl.MenuItems[2].NextMenuItems = MunuItems2;

        }

        static void PrevNextMenu(int numCmd)
        {

            var num = numCmd;
            if (num > MenuControl.MenuBlock.CurrMenuBlock.Count)
                return;

            if (MenuControl.MenuBlock.ExitNumber != num)
            {
                MenuControl.MenuBlock.PrevMenuBlock = MenuControl.MenuBlock.CurrMenuBlock;
                MenuControl.MenuBlock.CurrMenuBlock = MenuControl.MenuBlock.CurrMenuBlock[num].NextMenuItems;
                return;
            }
            MenuControl.MenuBlock.CurrMenuBlock = MenuControl.MenuBlock.PrevMenuBlock;
        }

        static void OpenShowCase(int numCmd)
        {
            for(int i=0;i< ClassShopProducts.ListShowCases.Count;i++)
            {
                Console.WriteLine($"{ClassShopProducts.ListShowCases[i].Id}     {ClassShopProducts.ListShowCases[i].Name}       {ClassShopProducts.ListShowCases[i].Vol}        {ClassShopProducts.ListShowCases[i].AvalibleVol}");
            }
            Console.WriteLine("Выберите витрину");
            var numVitrin = Convert.ToInt32(Console.ReadLine());
            var selectShowCase = ClassShopProducts.ListShowCases.Where(dat => dat.Id == numVitrin).ToArray()[0];
            for (int i = 0; i < selectShowCase.ListClassProducts.Count; i++)
            {
                Console.WriteLine($"{selectShowCase.ListClassProducts[i].Id}     {selectShowCase.ListClassProducts[i].Name}       {selectShowCase.ListClassProducts[i].Vol}");
            }
            Console.WriteLine("Вернуться?");
            Console.ReadLine();
        }
        static void AddShowCase(int numCmd)
        {
            Console.WriteLine("Введите название витрины");
            string nameShowCase= Console.ReadLine();

            Console.WriteLine("Введите объем витрины");
            int volShowCase = Convert.ToInt32(Console.ReadLine());

            ClassShopProducts.ListShowCases.Add(new ClassShowCase(volShowCase, nameShowCase));

        }

        static void CreateNewShowCase(int numCmd)
        {
            PrevNextMenu(numCmd);
        }

        static void EditShowCase(int numCmd)
        {

        }

        static void DeliteShowCase(int numCmd)
        {
            Console.WriteLine("Удаление витрины: ");
            for (int i = 0; i < ClassShopProducts.ListShowCases.Count; i++)
            {
                Console.WriteLine($"{ClassShopProducts.ListShowCases[i].Id}     {ClassShopProducts.ListShowCases[i].Name}       {ClassShopProducts.ListShowCases[i].Vol}        {ClassShopProducts.ListShowCases[i].AvalibleVol}");
            }
            Console.WriteLine("Выберите витрину");
            var numVitrin = Convert.ToInt32(Console.ReadLine());


            var selectShowCase = ClassShopProducts.ListShowCases.Remove(ClassShopProducts.ListShowCases.Where(dat => dat.Id == numVitrin).ToArray()[0]);
            
            Console.WriteLine("Для возврата нажмите любую кнопку?");
            Console.ReadLine();
        }

        static void Exit(int num)
        {

            if (MenuControl.MenuBlock.ExitNumber != num)
            {
                MenuControl.MenuBlock.PrevMenuBlock = MenuControl.MenuBlock.CurrMenuBlock;
                MenuControl.MenuBlock.CurrMenuBlock = MenuControl.MenuBlock.CurrMenuBlock[num].NextMenuItems;
                return;
            }
            MenuControl.MenuBlock.CurrMenuBlock = MenuControl.MenuBlock.PrevMenuBlock;

            if (MenuControl.MenuBlock.PrevMenuBlock == MenuControl.MenuBlock.CurrMenuBlock)
                StartMenu = false;
        }

        static void ExitVitrin(int num)
        {
            PrevNextMenu(num);
        }


    }
}
