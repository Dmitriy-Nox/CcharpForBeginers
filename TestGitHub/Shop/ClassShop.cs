using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Data;
using Shop.Menu;

namespace Shop
{
    public class ClassShop
    {
        private ClassShopProducts<ClassShowCase<ClassProduct>> ClassShopProducts = new ClassShopProducts<ClassShowCase<ClassProduct>>();
        private MenuContol MenuControl;
        private bool StartMenu = true;
        public int  Generation=0;

        public void Start()
        {
            List<ClassProduct> classProductsMeat = new List<ClassProduct>() { new ClassProduct("Говядина", "Мясо", 10, 44.4m), new ClassProduct("Свинина", "Мясо", 16, 35.7m), new ClassProduct("Баранина", "Мясо", 8, 55.9m), new ClassProduct("Курица", "Мясо", 20, 23.1m), new ClassProduct("Суповой набор", "Мясо", 30, 35.4m) };
            List<ClassProduct> classProductsCheese = new List<ClassProduct>() { new ClassProduct("Масдам", "Сыр", 3, 56.7m), new ClassProduct("Российский", "Сыр", 17, 34.2m), new ClassProduct("Пармезан", "Сыр", 23, 98.3m), new ClassProduct("Камамбер", "Сыр", 4, 179.4m) };
            List<ClassProduct> classProductsVegetables = new List<ClassProduct>() { new ClassProduct("Картошка", "Овощи", 36, 12.5m), new ClassProduct("Морковь", "Овощи", 7, 12.1m), new ClassProduct("Помидоры", "Овощи", 13, 43.5m), new ClassProduct("Огурцы", "Овощи", 15, 25.6m), new ClassProduct("Капуста", "Овощи", 14, 5.4m), new ClassProduct("Салат дуболистный", "Овощи", 4, 12.2m) };

            List<ClassShowCase<ClassProduct>> listShowCase = new List<ClassShowCase<ClassProduct>>() { new ClassShowCase<ClassProduct>(100, "Мясная витрина", "Мясо") { ListClassProducts = classProductsMeat }, new ClassShowCase<ClassProduct>(100, "Сырная витрина", "Сыр") { ListClassProducts = classProductsCheese }, new ClassShowCase<ClassProduct>(100, "Овощная витрина", "Овощи") { ListClassProducts = classProductsVegetables } };
            ClassShopProducts.ListShowCases = listShowCase;
            CreateMenu();
            CurrMenu = MainMenu;
            Menu();
        }
        private void Menu()
        {
            Console.Clear();

            for (int i = 0; i < CurrMenu.NextMenuItems.Count; i++)
            {
                Console.WriteLine(CurrMenu.NextMenuItems[i].Text);
            }

            var num = 0;
            ReadStringInt(out num);
            num = CheckNum(num, CurrMenu.ExitNumber);

            //if (num <= MenuControl.CurrMenu.CurrFunctions.Count)

            CurrMenu.NextMenuItems[num].FuncMenuItem?.Invoke(num);

            if (StartMenu != false)
                Menu();

        }
        //private void CreateMenu1()
        //{

        //    //#region Главное меню
        //    //var MunuItems = new List<MenuItem>();

        //    //var menu11 = new MenuItem("1) Создать новую витрину");
        //    //menu11.FuncMenuItem += CreateNewShowCase;
        //    //MunuItems.Add(menu11);

        //    //var menu12 = new MenuItem("2) Открыть витрину");
        //    //menu12.FuncMenuItem += OpenShowCase;
        //    //MunuItems.Add(menu12);

        //    //var menu15 = new MenuItem("3) Редактировать витрину");
        //    //menu15.FuncMenuItem += EditShowCase;
        //    //MunuItems.Add(menu15);

        //    //var menu14 = new MenuItem("4) Редактировать товары");
        //    //menu14.FuncMenuItem += EditProducts;
        //    //MunuItems.Add(menu14);

        //    //var menu16 = new MenuItem("5) Выход");
        //    //menu16.FuncMenuItem += Exit;
        //    //MunuItems.Add(menu16);

        //    //MenuControl = new MenuContol(MunuItems);
        //    //#endregion

        //    //#region Меню создания витрины
        //    //var MunuItems1 = new List<MenuItem>();

        //    //var menu21 = new MenuItem("1) Добавить витрину");
        //    //menu21.FuncMenuItem += AddShowCase;
        //    //MunuItems1.Add(menu21);

        //    //var menu22 = new MenuItem("2) Выход");
        //    //menu22.FuncMenuItem += ExitVitrin;
        //    //MunuItems1.Add(menu22);
        //    //MenuControl.MenuItems[1].NextMenuItems = MunuItems1;
        //    //MenuControl.MenuItems[1].PrevMenuItems = MunuItems;
        //    //#endregion

        //    //var MunuItems2 = new List<MenuItem>();
        //    //var menu31 = new MenuItem("1) Добавить товар на витрину");
        //    //menu31.FuncMenuItem += AddProductMain;
        //    //MunuItems2.Add(menu31);

        //    //var menu32 = new MenuItem("2) Изменить колличество товара");
        //    //menu32.FuncMenuItem += EditProductCount;
        //    //MunuItems2.Add(menu32);

        //    //var menu33 = new MenuItem("3) Удалить товар с витрины");
        //    //menu33.FuncMenuItem += DeliteProductShowCase;
        //    //MunuItems2.Add(menu33);

        //    //var menu34 = new MenuItem("4) Удалить витрину");
        //    //menu34.FuncMenuItem += DeliteShowCase;
        //    //MunuItems2.Add(menu34);

        //    //var menu35 = new MenuItem("5) Выход");
        //    //menu35.FuncMenuItem += ExitAddProduct;
        //    //MunuItems2.Add(menu35);
        //    //MenuControl.MenuItems[3].NextMenuItems = MunuItems2;
        //    //MenuControl.MenuItems[3].PrevMenuItems = MunuItems;




        //    //var MunuItems3 = new List<MenuItem>();

        //    //var menu41 = new MenuItem("1) Добавить товар ");
        //    //menu41.FuncMenuItem += AddProductLocal;
        //    //MunuItems3.Add(menu41);

        //    //var menu42 = new MenuItem("2) Открыть все товары");
        //    //menu42.FuncMenuItem += OpenProducts;
        //    //MunuItems3.Add(menu42);

        //    //var menu43 = new MenuItem("3) Удалить товар");
        //    //menu43.FuncMenuItem += DeliteProduct;
        //    //MunuItems3.Add(menu43);

        //    //var menu44 = new MenuItem("4) Выход");
        //    //menu44.FuncMenuItem += ExitAddProductLocal;
        //    //MunuItems3.Add(menu44);
        //    //MenuControl.MenuItems[4].NextMenuItems = MunuItems3;
        //    //MenuControl.MenuItems[4].PrevMenuItems = MunuItems1;

        //    //var MunuItems4 = new List<MenuItem>();

        //    //var menu51 = new MenuItem("1) Добавить новый товар ");
        //    //menu51.FuncMenuItem += AddNewProductOnShowCase;
        //    //MunuItems4.Add(menu51);

        //    //var menu52 = new MenuItem("2) Добавить существующий товар");
        //    //menu52.FuncMenuItem += AddExistsProductOnShowCase;
        //    //MunuItems4.Add(menu52);

        //    //var menu53 = new MenuItem("3) Выход");
        //    //menu53.FuncMenuItem += ExitExistsProductOnShowCase;
        //    //MunuItems4.Add(menu53);
        //    //MenuControl.MenuItems[3].NextMenuItems[1].NextMenuItems = MunuItems4;
        //    //MenuControl.MenuItems[3].NextMenuItems[1].PrevMenuItems = MunuItems3;

        //}

        MenuItem MainMenu;
        MenuItem CurrMenu;
        private void CreateMenu()
        {
            var menuItemAddProductSwitch = new MenuItem("1) Добавить товар) ", AddProductMain);

            menuItemAddProductSwitch.AddNewReference(new List<MenuItem>()
            { new MenuItem("1) Добавить новый товар  ", AddNewProductOnShowCase),
              new MenuItem("2) Добавить существующий товар ", AddExistsProductOnShowCase),
              new MenuItem("3) Выход ", ExitAddProduct)}
            );


            var menuItemAddProduct = new MenuItem("1) Добавить товар на витрину", AddProductMain);
            menuItemAddProduct.AddNewReference(new List<MenuItem>() {
                menuItemAddProductSwitch });

            var menuItemMainEditShowCase = new MenuItem("3) Редактировать витрину", AddProductMain);
            menuItemMainEditShowCase.AddNewReference(new List<MenuItem>() { menuItemAddProductSwitch });
            menuItemMainEditShowCase.AddNewReference(new List<MenuItem>()
            {
                menuItemAddProductSwitch,
                new MenuItem("2) Открыть все товары на витрине", AddExistsProductOnShowCase),
                new MenuItem("3) Удалить товар с витрины", AddExistsProductOnShowCase),
                new MenuItem("4) Выход ", ExitAddProduct)
            });


            var menuItemMainEditProducts = new MenuItem("4) Редактировать товары", null);
            menuItemMainEditProducts.AddNewReference(new List<MenuItem>()
            {
                new MenuItem("1) Добавить товар", AddExistsProductOnShowCase),
                new MenuItem("2) Открыть все товары", AddExistsProductOnShowCase),
                new MenuItem("3) Удалить товар", AddExistsProductOnShowCase),
                new MenuItem("4) Выход ", ExitAddProduct)
            });


            MainMenu = new MenuItem("Главное меню", null);
            MainMenu.AddNewReference(new List<MenuItem>()
            {
                new MenuItem("1) Создать новую витрину", AddProductMain),
                new MenuItem("2) Открыть витрину", AddProductMain),
                menuItemMainEditShowCase,
                menuItemMainEditProducts,
                new MenuItem("5) Выход", AddProductMain),
            }
                );

            var ss = 0;



            //var menu41 = new MenuItem("1) Добавить товар ");
            //menu41.FuncMenuItem += AddProductLocal;
            //MunuItems3.Add(menu41);

            //var menu42 = new MenuItem("2) Открыть все товары");
            //menu42.FuncMenuItem += OpenProducts;
            //MunuItems3.Add(menu42);

            //var menu43 = new MenuItem("3) Удалить товар");
            //menu43.FuncMenuItem += DeliteProduct;
            //MunuItems3.Add(menu43);

            //var menu44 = new MenuItem("4) Выход");
            //menu44.FuncMenuItem += ExitAddProductLocal;






            MenuItem menuItem2 = new MenuItem("2) ", AddProductMain);
            menuItem2.AddNewReference(new List<MenuItem>()
            { new MenuItem("5) Добавить новый товар ", AddNewProductOnShowCase),
              new MenuItem("6) Добавить существующий товар ", AddExistsProductOnShowCase) }

            
);
            //MenuItem menuItem3 = new MenuItem("2) ", AddProductMain);
            //menuItem3.AddNewReference(new List<MenuItem>(){ menuItem,menuItem1,menuItem2});
            //var ss = menuItem;


            //#region Главное меню
            //var MunuItems = new List<MenuItem>();

            //var menu11 = new MenuItem("1) Создать новую витрину");
            //menu11.FuncMenuItem += CreateNewShowCase;
            //MunuItems.Add(menu11);

            //var menu12 = new MenuItem("2) Открыть витрину");
            //menu12.FuncMenuItem += OpenShowCase;
            //MunuItems.Add(menu12);

            //var menu15 = new MenuItem("3) Редактировать витрину");
            //menu15.FuncMenuItem += EditShowCase;
            //MunuItems.Add(menu15);

            //var menu14 = new MenuItem("4) Редактировать товары");
            //menu14.FuncMenuItem += EditProducts;
            //MunuItems.Add(menu14);

            //var menu16 = new MenuItem("5) Выход");
            //menu16.FuncMenuItem += Exit;
            //MunuItems.Add(menu16);

            //MenuControl = new MenuContol(MunuItems);
            //#endregion

            //#region Меню создания витрины
            //var MunuItems1 = new List<MenuItem>();

            //var menu21 = new MenuItem("1) Добавить витрину");
            //menu21.FuncMenuItem += AddShowCase;
            //MunuItems1.Add(menu21);

            //var menu22 = new MenuItem("2) Выход");
            //menu22.FuncMenuItem += ExitVitrin;
            //MunuItems1.Add(menu22);
            //MenuControl.MenuItems[1].NextMenuItems = MunuItems1;
            //MenuControl.MenuItems[1].PrevMenuItems = MunuItems;
            //#endregion

            //var MunuItems2 = new List<MenuItem>();
            //var menu31 = new MenuItem("1) Добавить товар на витрину");
            //menu31.FuncMenuItem += AddProductMain;
            //MunuItems2.Add(menu31);

            //var menu32 = new MenuItem("2) Изменить колличество товара");
            //menu32.FuncMenuItem += EditProductCount;
            //MunuItems2.Add(menu32);

            //var menu33 = new MenuItem("3) Удалить товар с витрины");
            //menu33.FuncMenuItem += DeliteProductShowCase;
            //MunuItems2.Add(menu33);

            //var menu34 = new MenuItem("4) Удалить витрину");
            //menu34.FuncMenuItem += DeliteShowCase;
            //MunuItems2.Add(menu34);

            //var menu35 = new MenuItem("5) Выход");
            //menu35.FuncMenuItem += ExitAddProduct;
            //MunuItems2.Add(menu35);
            //MenuControl.MenuItems[3].NextMenuItems = MunuItems2;
            //MenuControl.MenuItems[3].PrevMenuItems = MunuItems;




            //var MunuItems3 = new List<MenuItem>();

            //var menu41 = new MenuItem("1) Добавить товар ");
            //menu41.FuncMenuItem += AddProductLocal;
            //MunuItems3.Add(menu41);

            //var menu42 = new MenuItem("2) Открыть все товары");
            //menu42.FuncMenuItem += OpenProducts;
            //MunuItems3.Add(menu42);

            //var menu43 = new MenuItem("3) Удалить товар");
            //menu43.FuncMenuItem += DeliteProduct;
            //MunuItems3.Add(menu43);

            //var menu44 = new MenuItem("4) Выход");
            //menu44.FuncMenuItem += ExitAddProductLocal;
            //MunuItems3.Add(menu44);
            //MenuControl.MenuItems[4].NextMenuItems = MunuItems3;
            //MenuControl.MenuItems[4].PrevMenuItems = MunuItems1;

            //var MunuItems4 = new List<MenuItem>();

            //var menu51 = new MenuItem("1) Добавить новый товар ");
            //menu51.FuncMenuItem += AddNewProductOnShowCase;
            //MunuItems4.Add(menu51);

            //var menu52 = new MenuItem("2) Добавить существующий товар");
            //menu52.FuncMenuItem += AddExistsProductOnShowCase;
            //MunuItems4.Add(menu52);

            //var menu53 = new MenuItem("3) Выход");
            //menu53.FuncMenuItem += ExitExistsProductOnShowCase;
            //MunuItems4.Add(menu53);
            //MenuControl.MenuItems[3].NextMenuItems[1].NextMenuItems = MunuItems4;
            //MenuControl.MenuItems[3].NextMenuItems[1].PrevMenuItems = MunuItems3;

        }

        private void ExitExistsProductOnShowCase(int numCommand)
        {
            PrevNextMenu(numCommand);
        }

        private void AddExistsProductOnShowCase(int numCommand)
        {
            Console.Clear();
            var selSC = SelectShowCase();
            var selPr= SelectProduct(selSC);

            selSC.AddItem(selPr);

        }

        private void AddNewProductOnShowCase(int numCommand)
        {
             //SelectProduct();
        }

        private void AddProductMain(int numCmd)
        {
            PrevNextMenu(numCmd);
        }

        private void DeliteProductShowCase(int numCmd)
        {
            Console.Clear();
            var sSC = SelectShowCase();
            var sP = SelectProduct(sSC);
            sSC.RemoveItem(sP.Id);
            Console.ReadLine();
        }

        private void EditProductCount(int numCmd)
        {
            Console.Clear();
            var selectShowCase = SelectShowCase();


        }

        private void ExitAddProductLocal(int numCmd)
        {
            PrevNextMenu(numCmd);
        }

        private void AddProductLocal(int numCmd)
        {
            throw new NotImplementedException();
        }

        private void OpenProducts(int numCmd)
        {
            Console.Clear();

            Console.WriteLine($"Товары:");
            Console.WriteLine("");
            for (int i = 0; i < ClassShopProducts.ListProducts.Count; i++)
            {

                Console.WriteLine($"{ClassShopProducts.ListProducts[i].Id}    {ClassShopProducts.ListProducts[i].Cathegory}     {ClassShopProducts.ListProducts[i].Name}       {ClassShopProducts.ListProducts[i].Vol}      {ClassShopProducts.ListProducts[i].Price}");
            }
            Console.WriteLine("");
            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadLine();
        }

        private void DeliteProduct(int numCommand)
        {
            
        }

        private void PrevNextMenu(int numCmd)
        {
            CurrMenu = CurrMenu.NextMenuItems[numCmd];
        }

        private void OpenShowCase(int numCmd)
        {
            Console.Clear();
            var selectShowCase= SelectShowCase();
            Console.WriteLine($"Товары на витрине: {selectShowCase.Name}");
            Console.WriteLine("");
            Console.WriteLine($"{"N",-7}{"IdShowCase",-15}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}");
            Console.WriteLine("");
            for (int i = 0; i < selectShowCase.ListClassProducts.Count; i++)
            {
                Console.WriteLine($"{i+1,-7}{selectShowCase.Id,-15}{selectShowCase.ListClassProducts[i].Id,-15}{selectShowCase.ListClassProducts[i].Cathegory,-18}{selectShowCase.ListClassProducts[i].Name,-20}{selectShowCase.ListClassProducts[i].Vol,-10}");
            }
            Console.WriteLine("");
            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadLine();
        }


        private void AddShowCase(int numCmd)
        {
            Console.Clear();
            Console.WriteLine("Добавление витрины");
            Console.WriteLine("");
            Console.WriteLine("Введите название витрины");
            string nameShowCase = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Введите объем витрины");
            var volShowCase = 0;
            ReadStringInt(out volShowCase);

            Console.WriteLine("");
            Console.WriteLine("Введите категорию товаров на витрине");
            string cathegoryShowCase = Console.ReadLine();

            var isSucsessAdd = ClassShopProducts.AddItem(new ClassShowCase<ClassProduct>(volShowCase, nameShowCase, cathegoryShowCase));
            if (isSucsessAdd)
                Console.WriteLine("Витрина добавлена");
            else
                Console.WriteLine("Ошибка добавления витрины.");

            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadLine();
        }

        private void AddProduct(int numCmd)
        {
            Console.Clear();
            var selectShowCase = SelectShowCase();
            Console.WriteLine("");
            Console.WriteLine("Добавление товара");
            Console.WriteLine("");
            Console.WriteLine("Введите название товара");
            string nameShowCase = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Введите объем товара");
            var volProduct = 0;
            ReadStringInt(out volProduct);


            Console.WriteLine("");
            Console.WriteLine("Введите цену товара");
            var priceProduct = 0;
            ReadStringInt(out priceProduct);

            var isSucsessAdd = selectShowCase.AddItem(new ClassProduct(nameShowCase, selectShowCase.Cathegory, volProduct, priceProduct));
            if (isSucsessAdd)
                Console.WriteLine("Товар добавлен");
            else
                Console.WriteLine("Ошибка добавления Товара.");

            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadLine();
        }

        private void CreateNewShowCase(int numCmd)
        {
            PrevNextMenu(numCmd);
        }

        private void EditShowCase(int numCmd)
        {
            PrevNextMenu(numCmd);
        }

        private void EditProducts(int numCmd)
        {
            PrevNextMenu(numCmd);
        }

        private void DeliteShowCase(int numCmd)
        {
            var isEndDelite = true;
            while (isEndDelite)
            {
                Console.Clear();
                Console.WriteLine("Удаление витрины: ");
                Console.WriteLine("");
                for (int i = 0; i < ClassShopProducts.ListShowCases.Count; i++)
                {
                    Console.WriteLine($"{ClassShopProducts.ListShowCases[i].Id,0}     {ClassShopProducts.ListShowCases[i].Cathegory,-8}     {ClassShopProducts.ListShowCases[i].Name,-8}       {ClassShopProducts.ListShowCases[i].Vol,-15}        {ClassShopProducts.ListShowCases[i].AvalibleVol}");
                }
                Console.WriteLine("");
                Console.WriteLine("Выберите витрину");
                var numVitrin = 0;
                ReadStringInt(out numVitrin);

                numVitrin = CheckNum(numVitrin, ClassShopProducts.ListShowCases.Count);
                var selectShowCase = ClassShopProducts.RemoveItem(numVitrin);
                Console.Clear();
                Console.WriteLine("Витрина удалена");
                Console.WriteLine("{Хотите продолжить? (y/n)");

                var sss=WaitYorN();

                switch (sss.ToString())
                {
                    case "y":
                        break;
                    case "n":
                        isEndDelite = false;
                        break;
                }
                
            }
        }

        private void Exit(int num)
        {

            //if (MenuControl.MenuBlock.ExitNumber != num)
            //{
            //    MenuControl.MenuBlock.PrevMenu.CurrMenuBlock = MenuControl.MenuBlock.CurrMenuBlock;
            //    MenuControl.MenuBlock.CurrMenuBlock = MenuControl.MenuBlock.CurrMenuBlock[num].NextMenuItems;
            //    return;
            //}
            //MenuControl.MenuBlock.CurrMenuBlock = MenuControl.MenuBlock.PrevMenu.CurrMenuBlock;

            //if (MenuControl.MenuBlock.PrevMenu.CurrMenuBlock == MenuControl.MenuBlock.CurrMenuBlock)
            //    StartMenu = false;
        }

        private void ExitVitrin(int num)
        {
            PrevNextMenu(num);
        }

        private void ExitAddProduct(int num)
        {
            PrevNextMenu(num);
        }

        private void ReadStringInt(out int result)
        {
            var readConsole = Console.ReadLine();
            while (!int.TryParse(readConsole, out result))
            {
                Console.WriteLine("Некорректное значение. Повторите ввод");
                readConsole = Console.ReadLine();

            }
        }

        private int CheckNum(int num, int countCollection)
        {
            var number = num;
            while (number > countCollection || number <= 0)
            {
                Console.WriteLine("Такого значения не существует. Повторите ввод");
                ReadStringInt(out number);
            }
            return number;
        }

        private char WaitYorN()
        {
            char returnVal;
            while (true)
            {
                var answer = Console.ReadKey(true);
                if (answer.KeyChar == 'y' || answer.KeyChar == 'n')
                {
                    Console.Write(answer.KeyChar);
                    Console.ReadLine();
                    returnVal = answer.KeyChar;
                    break;
                }
            }
            return returnVal;
        }

        private ClassShowCase<ClassProduct> SelectShowCase()
        {
            Console.WriteLine("Доступные витрины");
            Console.WriteLine("");
            Console.WriteLine($"{"Id",-7}{"Name",-18}{"Vol",-10}{"AvalibleVol",-10}");
            Console.WriteLine("");
            for (int i = 0; i < ClassShopProducts.ListShowCases.Count; i++)
            {
                Console.WriteLine($"{ClassShopProducts.ListShowCases[i].Id,-7}{ClassShopProducts.ListShowCases[i].Name,-18}{ClassShopProducts.ListShowCases[i].Vol,-10}{ClassShopProducts.ListShowCases[i].AvalibleVol,-10}");
            }
            Console.WriteLine("");
            Console.WriteLine("Выберите витрину");


            var num = 0;

            ReadStringInt(out num);


            num = CheckNum(num, ClassShopProducts.ListShowCases.Count);
            Console.Clear();
            var selectShowCase = ClassShopProducts.ListShowCases.Where(dat => dat.Id == num).ToArray()[0];


            return selectShowCase;
        }

        private ClassProduct SelectProduct(ClassShowCase<ClassProduct> selectShowCase)
        {
           
            Console.WriteLine("Доступные продукты");
            Console.WriteLine("");
            Console.WriteLine($"{"N",-7}{"IdShowCase",-15}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}");
            Console.WriteLine("");
            for (int i = 0; i < selectShowCase.ListClassProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1,-7}{selectShowCase.Id,-15}{selectShowCase.ListClassProducts[i].Id,-15}{selectShowCase.ListClassProducts[i].Cathegory,-18}{selectShowCase.ListClassProducts[i].Name,-20}{selectShowCase.ListClassProducts[i].Vol,-10}");
            }
            Console.WriteLine("");
            Console.WriteLine("Выберите продукт");


            var num = 0;

            ReadStringInt(out num);


            num = CheckNum(num, selectShowCase.ListClassProducts.Count);
            Console.Clear();
            var selectProduct = selectShowCase.ListClassProducts[num-1];


            return selectProduct;
        }


    }
}

