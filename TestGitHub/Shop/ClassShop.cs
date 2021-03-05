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
        private bool StartMenu = true;

        public void Start()
        {
            List<ClassProduct> classProductsMeat = new List<ClassProduct>() { new ClassProduct("Говядина", "Мясо", 10, 44.4m) { Count=1 }, new ClassProduct("Свинина", "Мясо", 16, 35.7m) { Count = 1 }, new ClassProduct("Баранина", "Мясо", 8, 55.9m) { Count = 1 }, new ClassProduct("Курица", "Мясо", 20, 23.1m) { Count = 1 }, new ClassProduct("Суповой набор", "Мясо", 30, 35.4m) { Count = 1 } };
            List<ClassProduct> classProductsCheese = new List<ClassProduct>() { new ClassProduct("Масдам", "Сыр", 3, 56.7m) { Count = 1 }, new ClassProduct("Российский", "Сыр", 17, 34.2m) { Count = 1 }, new ClassProduct("Пармезан", "Сыр", 23, 98.3m) { Count = 1 }, new ClassProduct("Камамбер", "Сыр", 4, 179.4m) { Count = 1 } };
            List<ClassProduct> classProductsVegetables = new List<ClassProduct>() { new ClassProduct("Картошка", "Овощи", 36, 12.5m) { Count = 1 }, new ClassProduct("Морковь", "Овощи", 7, 12.1m) { Count = 1 }, new ClassProduct("Помидоры", "Овощи", 13, 43.5m) { Count = 1 }, new ClassProduct("Огурцы", "Овощи", 15, 25.6m) { Count = 1 }, new ClassProduct("Капуста", "Овощи", 14, 5.4m) { Count = 1 }, new ClassProduct("Салат дуболистный", "Овощи", 4, 12.2m) { Count = 1 } };

            List<ClassShowCase<ClassProduct>> listShowCase = new List<ClassShowCase<ClassProduct>>() { new ClassShowCase<ClassProduct>(100, "Мясная витрина", "Мясо") { ListClassProducts = classProductsMeat}, new ClassShowCase<ClassProduct>(100, "Сырная витрина", "Сыр") { ListClassProducts = classProductsCheese}, new ClassShowCase<ClassProduct>(100, "Овощная витрина", "Овощи") { ListClassProducts = classProductsVegetables} };
            ClassShopProducts.ListShowCases = listShowCase;
            CreateMenu();
            CurrMenu = MainMenu;
            Menu();
        }
        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("Выберите действие");
            Console.WriteLine("");
            for (int i = 0; i < CurrMenu.NextMenuItems.Count; i++)
            {
                Console.WriteLine(CurrMenu.NextMenuItems[i].Text);
            }
            Console.WriteLine("");
            Console.WriteLine("Выбрано:");
            var num = 0;
            ReadStringInt(out num);
            num = CheckNum(num, CurrMenu.ExitNumber);

            //if (num <= MenuControl.CurrMenu.CurrFunctions.Count)

            CurrMenu.NextMenuItems[num-1].FuncMenuItem?.Invoke(num-1);

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
            var menuItemAddProductSwitch = new MenuItem("2) Добавить товар на витрину ", AddProductMain);

            menuItemAddProductSwitch.AddNewReference(new List<MenuItem>()
            { new MenuItem("1) Добавить новый товар  ", AddNewProductOnShowCase),
              new MenuItem("2) Добавить существующий товар ", AddExistsProductOnShowCase),
              new MenuItem("3) Выход ", ExitAddProduct)}
            );


            var menuItemMainEditShowCase = new MenuItem("2) Редактировать витрину", EditShowCase);
            menuItemMainEditShowCase.AddNewReference(new List<MenuItem>() { menuItemAddProductSwitch });
            menuItemMainEditShowCase.AddNewReference(new List<MenuItem>()
            {
                new MenuItem("1) Создать новую витрину", AddShowCase),
                menuItemAddProductSwitch,
                new MenuItem("3) Удалить товар с витрины", RemoveProductOnShowCase),
                new MenuItem("4) Изменить витрину", EditShowCaseParams),
                new MenuItem("5) Удалить витрину", RemoveShowCase),
                new MenuItem("6) Выход ", ExitEditOnShowCase)
            });


            var menuItemMainEditProducts = new MenuItem("3) Редактировать товары", EditProducts);
            menuItemMainEditProducts.AddNewReference(new List<MenuItem>()
            {
                new MenuItem("1) Добавить товар", AddProduct),
                new MenuItem("2) Открыть все товары", OpenAllProducts),
                new MenuItem("3) Удалить товар", RemoveProduct),
                new MenuItem("4) Редактировать товар", EditProductParams),
                new MenuItem("5) Выход ", ExitEditProducts)
            });

            //var menuItemAddShowCase = );
            //menuItemAddShowCase.AddNewReference(new List<MenuItem>()
            //{
            //    new MenuItem("1) Добавить Витрину", AddShowCase),
            //    new MenuItem("2) Выход ", ExitAddShowCase)
            //});


            MainMenu = new MenuItem("Главное меню", null);
            MainMenu.AddNewReference(new List<MenuItem>()
            {
                
                new MenuItem("1) Открыть витрину", OpenShowCase),
                menuItemMainEditShowCase,
                menuItemMainEditProducts,
                new MenuItem("4) Выход", Exit),
            }
                );
        }



        private void OpenAllProducts(int numCommand)
        {
            Console.Clear();
            Console.WriteLine($"Все доступные товары:");
            Console.WriteLine("");
            Console.WriteLine($"{"N",-7}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Price",-10}");
            Console.WriteLine("");
            var products = ClassShopProducts.ListProducts;
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1,-7}{products[i].Id,-15}{products[i].Cathegory,-18}{products[i].Name,-20}{products[i].Vol,-10}{products[i].Price,-10}");
            }
            Console.WriteLine("");
            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadLine();
        }

        private void OpenShowCase(int numCmd)
        {
            Console.Clear();
            var selectShowCase = SelectShowCase();
            Console.WriteLine($"Товары на витрине: {selectShowCase.Name}");
            Console.WriteLine("");
            Console.WriteLine($"{"N",-7}{"IdShowCase",-15}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Count",-10}{"Price",-10}");
            Console.WriteLine("");
            for (int i = 0; i < selectShowCase.ListClassProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1,-7}{selectShowCase.Id,-15}{selectShowCase.ListClassProducts[i].Id,-15}{selectShowCase.ListClassProducts[i].Cathegory,-18}{selectShowCase.ListClassProducts[i].Name,-20}{selectShowCase.ListClassProducts[i].Vol,-10}{selectShowCase.ListClassProducts[i].Count,-10}{selectShowCase.ListClassProducts[i].Price,-10}");
            }
            Console.WriteLine("");
            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadLine();
        }


        private void PrevNextMenu(int numCmd)
        {
            if (numCmd == CurrMenu.ExitNumber - 1)
            {
                CurrMenu = CurrMenu.PrevMenuItems;
                if (CurrMenu == null)
                {
                    StartMenu = false;
                    return;
                }
                return;
            }

            CurrMenu = CurrMenu.NextMenuItems[numCmd];
        }


        private void AddNewShowCase(int numCmd)
        {
            PrevNextMenu(numCmd);
        }

        private void AddExistsProductOnShowCase(int numCommand)
        {
            Console.Clear();
            var selSC = SelectShowCase();

            bool isEndAdd = true;
            while(isEndAdd)
            {

                Console.Clear();
                Console.WriteLine($"Все доступные для изменения товары:");
                Console.WriteLine("");
                Console.WriteLine($"{"N",-7}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Price",-10}{"IsEditable",-10}");
                Console.WriteLine("");

                for (int i = 0; i < ClassShopProducts.ListProducts.Count; i++)
                {
                    Console.WriteLine($"{i + 1,-7}{ClassShopProducts.ListProducts[i].Id,-15}{ClassShopProducts.ListProducts[i].Cathegory,-18}{ClassShopProducts.ListProducts[i].Name,-20}{ClassShopProducts.ListProducts[i].Vol,-10}{ClassShopProducts.ListProducts[i].Price,-10}{(ClassShopProducts.ListProducts[i].IsEditable).ToString(),-10}");
                }
                int numProduct = 0;
                Console.WriteLine("Введите номер продукта:");
                ReadStringInt(out numProduct);
                numProduct = CheckNum(numProduct-1, ClassShopProducts.ListProducts.Count);
                var selPr = ClassShopProducts.ListProducts[numProduct];//SelectProductOnShowCase(selSC);
                var isSucsessAdd = selSC.AddItem(selPr);
                if (isSucsessAdd)
                    Console.WriteLine("Товар добавлен");
                else
                    Console.WriteLine("Ошибка добавления Товара.");

                Console.WriteLine("{Хотите продолжить? (y/n)");

                var sss = WaitYorN();

                switch (sss.ToString())
                {
                    case "y":
                        break;
                    case "n":
                        isEndAdd = false;
                        break;
                }
            }
        }

        private void AddNewProductOnShowCase(int numCommand)
        {
            Console.Clear();
            var selectShowCase = SelectShowCase();
            var isEndAdd = true;
            while (isEndAdd)
            {
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

                Console.WriteLine("{Хотите продолжить? (y/n)");

                var sss = WaitYorN();

                switch (sss.ToString())
                {
                    case "y":
                        break;
                    case "n":
                        isEndAdd = false;
                        break;
                }
            }
        }

        private void AddProductMain(int numCmd)
        {
            PrevNextMenu(numCmd);
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
            Console.WriteLine("");
            Console.WriteLine("Добавление товара");
            Console.WriteLine("");
            Console.WriteLine("Введите название товара");
            string nameShowCase = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Введите категорию товара");
            string nameCategory = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Введите объем товара");
            var volProduct = 0;
            ReadStringInt(out volProduct);


            Console.WriteLine("");
            Console.WriteLine("Введите цену товара");
            var priceProduct = 0;
            ReadStringInt(out priceProduct);

            ClassShopProducts.AddProduct(new ClassProduct(nameShowCase, nameCategory, volProduct, priceProduct));


            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadLine();
        }




        private void EditShowCaseParams(int numCmd)
        {
            Console.Clear();

            int? vol = null;
            string cathegory = null;

            
            var isEndEdit = true;
            while (isEndEdit)
            {
                var selectShowCase = SelectShowCase();
                Console.WriteLine("{Хотите изменить объем витрины? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":
                        Console.WriteLine("Введите желаемый объем витрины");
                        int newVol = 0;
                        ReadStringInt(out newVol);
                        var isSucsessEdit = selectShowCase.EditVol(newVol);

                        if (isSucsessEdit)
                        {
                            Console.WriteLine("Объем витрины изменен");
                        }
                        else
                            Console.WriteLine("Ошибка изменения объема витрины.");
                        break;
                    case "n":
                        break;
                }


                Console.WriteLine("{Хотите изменить название витрины? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":
                        Console.WriteLine("Введите новое название витрины");
                        var newName = Console.ReadLine();
                        var isSucsessEdit = selectShowCase.EditName(newName);

                        if (isSucsessEdit)
                            Console.WriteLine("Название витрины изменено");
                        else
                            Console.WriteLine("Ошибка изменения названия витрины.");
                        break;
                    case "n":
                        break;
                }


                Console.WriteLine("{Хотите изменить категорию витрины? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":
                        Console.WriteLine("Введите новую категорию");
                        var newName = Console.ReadLine();
                        var isSucsessEdit = selectShowCase.EditCathegory(newName);

                        if (isSucsessEdit)
                            Console.WriteLine("Категория витрины изменена");
                        else
                            Console.WriteLine("Ошибка изменения категории витрины.");
                        break;
                    case "n":
                        break;
                }


                Console.WriteLine("Хотите повторить операцию изменения? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":

                        break;
                    case "n":
                        isEndEdit = false;
                        break;
                }

            }



        }


        private void EditProductParams(int numCmd)
        {
            Console.Clear();

            var products = ClassShopProducts.ListProducts.Where(dat => dat.IsEditable).ToList();

            if (products.Count == 0)
            {
                Console.WriteLine("Нет продуктов, доступных для редактирования");
                Console.WriteLine("Для продолжения нажмите любую кнопку...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Изменение товара:");


            Console.WriteLine($"Все доступные для изменения товары:");
            Console.WriteLine("");
            Console.WriteLine($"{"N",-7}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Price",-10}{"IsEditable",-10}");
            Console.WriteLine("");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1,-7}{products[i].Id,-15}{products[i].Cathegory,-18}{products[i].Name,-20}{products[i].Vol,-10}{products[i].Price,-10}{(products[i].IsEditable).ToString(),-10}");
            }

            Console.WriteLine("");
            Console.WriteLine("Выберите товар");
            int numProduct = 0;
            ReadStringInt(out numProduct);


            var idx = ClassShopProducts.ListProducts.IndexOf(products[numProduct-1]);

            var isEndEdit = true;
            while (isEndEdit)
            {
                Console.WriteLine("Хотите изменить объем товара? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":
                        Console.WriteLine("Введите желаемый объем товара");
                        int newVol = 0;
                        ReadStringInt(out newVol);
                        var isSucsessEdit = ClassShopProducts.ListProducts[idx].EditVol(newVol);

                        if (isSucsessEdit)
                        {
                            Console.WriteLine("Объем товара изменен");
                        }
                        else
                            Console.WriteLine("Ошибка изменения объема товара.");
                        break;
                    case "n":
                        break;
                }


                Console.WriteLine("{Хотите изменить название товара? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":
                        Console.WriteLine("Введите новое название товара");
                        var newName = Console.ReadLine();
                        var isSucsessEdit = ClassShopProducts.ListProducts[idx].EditName(newName);

                        if (isSucsessEdit)
                            Console.WriteLine("Название товара изменено");
                        else
                            Console.WriteLine("Ошибка изменения названия товара.");
                        break;
                    case "n":
                        break;
                }


                Console.WriteLine("Хотите изменить категорию товара? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":
                        Console.WriteLine("Введите новую категорию");
                        var newName = Console.ReadLine();
                        var isSucsessEdit = ClassShopProducts.ListProducts[idx].EditCathegory(newName);

                        if (isSucsessEdit)
                            Console.WriteLine("Категория товара изменена");
                        else
                            Console.WriteLine("Ошибка изменения категории товара.");
                        break;
                    case "n":
                        break;
                }

                Console.WriteLine("Хотите изменить цену товара? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":
                        Console.WriteLine("Введите желаемый объем товара");
                        int newVol = 0;
                        ReadStringInt(out newVol);
                        var isSucsessEdit = ClassShopProducts.ListProducts[idx].EditVol(newVol);

                        if (isSucsessEdit)
                        {
                            Console.WriteLine("Объем товара изменен");
                        }
                        else
                            Console.WriteLine("Ошибка изменения объема товара.");
                        break;
                    case "n":
                        break;
                }


                Console.WriteLine("Хотите повторить операцию изменения? (y/n)");
                switch (WaitYorN().ToString())
                {
                    case "y":

                        break;
                    case "n":
                        isEndEdit = false;
                        break;
                }

            }



        }

        private void EditShowCase(int numCmd)
        {
            PrevNextMenu(numCmd);
        }

        private void EditProducts(int numCmd)
        {
            PrevNextMenu(numCmd);
        }



        private void RemoveShowCase(int numCmd)
        {
            var isEndDelite = true;
            while (isEndDelite)
            {
                Console.Clear();
                Console.WriteLine("Удаление витрины: ");
                Console.WriteLine("");
                var sSc = SelectShowCase();
                var isSucsessDelite= ClassShopProducts.RemoveItem(sSc.Id);
                if (isSucsessDelite)
                    Console.WriteLine("Витрина удалена");
                else
                    Console.WriteLine("Ошибка удаления витрины.");

                Console.WriteLine("{Хотите продолжить? (y/n)");

                switch (WaitYorN().ToString())
                {
                    case "y":
                        if(ClassShopProducts.ListShowCases.Count==0)
                            isEndDelite = false;
                        break;
                    case "n":
                        isEndDelite = false;
                        break;
                }
                
            }
        }

        private void RemoveProduct(int numCommand)
        {

            var isEndDelite = true;
            while (isEndDelite)
            {
                Console.Clear();
                Console.WriteLine($"Все доступные товары:");
                Console.WriteLine("");
                Console.WriteLine($"{"N",-7}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Price",-10}");
                Console.WriteLine("");
                var products = ClassShopProducts.ListProducts;
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1,-7}{products[i].Id,-15}{products[i].Cathegory,-18}{products[i].Name,-20}{products[i].Vol,-10}{products[i].Price,-10}");
                }

                Console.WriteLine("");
                Console.WriteLine("Выберите товар");
                int numProduct = 0;
                ReadStringInt(out numProduct);
                var isSucsessDelite = ClassShopProducts.RemoveProduct(ClassShopProducts.ListProducts[numProduct-1].Id);

                if (isSucsessDelite)
                    Console.WriteLine("Товар удален");
                else
                    Console.WriteLine("Ошибка удаления товара.");
                Console.WriteLine("{Хотите продолжить? (y/n)");
                var sss = WaitYorN();

                switch (sss.ToString())
                {
                    case "y":
                        if (ClassShopProducts.ListShowCases.Count == 0)
                            isEndDelite = false;
                        break;
                    case "n":
                        isEndDelite = false;
                        break;
                }

            }












           

        }

        private void RemoveProductOnShowCase(int numCommand)
        {
            Console.Clear();
            var sSc = SelectShowCase();
            var isEndDelite = true;
            while (isEndDelite)
            {
                Console.Clear();
                Console.WriteLine("Удаление продукта с витрины: ");
                Console.WriteLine("");

                var sP = SelectProductOnShowCase(sSc);
                var isSucsess = sSc.RemoveItem(sP.Id);

                if (isSucsess)
                    Console.WriteLine("Продукт удален");
                else
                    Console.WriteLine("Ошибка удаления");

                Console.WriteLine("{Хотите продолжить? (y/n)");

                var sss = WaitYorN();

                switch (sss.ToString())
                {
                    case "y":
                        if (ClassShopProducts.ListShowCases.Count == 0)
                            isEndDelite = false;
                        break;
                    case "n":
                        isEndDelite = false;
                        break;
                }

            }
        }




        private void ExitEditOnShowCase(int numCommand)
        {
            PrevNextMenu(numCommand);
        }

        private void ExitAddProduct(int num)
        {
            PrevNextMenu(num);
        }

        private void ExitEditProducts(int numCommand)
        {
            PrevNextMenu(numCommand);
        }

        private void ExitAddShowCase(int numCommand)
        {
            PrevNextMenu(numCommand);
        }

        private void Exit(int num)
        {

            StartMenu = false;
           
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

        private ClassProduct SelectProductOnShowCase(ClassShowCase<ClassProduct> selectShowCase)
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

