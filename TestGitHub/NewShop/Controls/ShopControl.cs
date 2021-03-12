using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewShop.View;
using Shop.Data;

namespace NewShop.Controls
{
    public class ShopControl
    {
        ClassShopProducts<ClassShowCase<ClassProduct>> ClassShopProducts=new ClassShopProducts<ClassShowCase<ClassProduct>>();
        private IView _view;
        public ShopControl(IView view )
        {
            _view = view;
            CreateDefaultShowCasesAndProducts();
        }
        private ClassShopProducts<ClassShowCase<ClassProduct>> CreateDefaultShowCasesAndProducts()
        {

            var classShopProducts = new ClassShopProducts<ClassShowCase<ClassProduct>>();
            List<ClassProduct> classProductsMeat = new List<ClassProduct>() { new ClassProduct("Говядина", "Мясо", 10, 44.4m) { Count = 1 }, new ClassProduct("Свинина", "Мясо", 16, 35.7m) { Count = 1 }, new ClassProduct("Баранина", "Мясо", 8, 55.9m) { Count = 1 }, new ClassProduct("Курица", "Мясо", 20, 23.1m) { Count = 1 }, new ClassProduct("Суповой набор", "Мясо", 30, 35.4m) { Count = 1 } };
            List<ClassProduct> classProductsCheese = new List<ClassProduct>() { new ClassProduct("Масдам", "Сыр", 3, 56.7m) { Count = 1 }, new ClassProduct("Российский", "Сыр", 17, 34.2m) { Count = 1 }, new ClassProduct("Пармезан", "Сыр", 23, 98.3m) { Count = 1 }, new ClassProduct("Камамбер", "Сыр", 4, 179.4m) { Count = 1 } };
            List<ClassProduct> classProductsVegetables = new List<ClassProduct>() { new ClassProduct("Картошка", "Овощи", 36, 12.5m) { Count = 1 }, new ClassProduct("Морковь", "Овощи", 7, 12.1m) { Count = 1 }, new ClassProduct("Помидоры", "Овощи", 13, 43.5m) { Count = 1 }, new ClassProduct("Огурцы", "Овощи", 15, 25.6m) { Count = 1 }, new ClassProduct("Капуста", "Овощи", 14, 5.4m) { Count = 1 }, new ClassProduct("Салат дуболистный", "Овощи", 4, 12.2m) { Count = 1 } };

            List<ClassShowCase<ClassProduct>> listShowCase = new List<ClassShowCase<ClassProduct>>() { new ClassShowCase<ClassProduct>(100, "Мясная витрина", "Мясо") { ListClassProducts = classProductsMeat }, new ClassShowCase<ClassProduct>(100, "Сырная витрина", "Сыр") { ListClassProducts = classProductsCheese }, new ClassShowCase<ClassProduct>(100, "Овощная витрина", "Овощи") { ListClassProducts = classProductsVegetables } };
            ClassShopProducts.ListShowCases = listShowCase;
            return classShopProducts;
        }

        public void OpenAllProducts(int numCommand)
        {
            _view.Clear();
            _view.SendText += ($"Все доступные товары:\r\n");
            _view.SendText += ("\r\n");
            _view.SendText += ($"{"N",-7}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Price",-10}\r\n");
            _view.SendText += ("");
            var products = ClassShopProducts.ListProducts;
            for (var i = 0; i < products.Count; i++)
            {
                _view.SendText += ($"{i + 1,-7}{products[i].Id,-15}{products[i].Cathegory,-18}{products[i].Name,-20}{products[i].Vol,-10}{products[i].Price,-10}\r\n");
            }
            _view.SendText += ("\r\n");
            _view.SendText += ("Для продолжения нажмите любую кнопку...\r\n");
            _view.WriteTextBuffer();
            _view.ReadLine();
        }
        public void OpenShowCase(int numCommand)
        {
            _view.Clear();
            var selectShowCase = SelectShowCase();
            _view.Clear();
            _view.SendText+=($"Товары на витрине: {selectShowCase.Name}\r\n");
            _view.SendText += ("\r\n");
            _view.SendText += ($"{"N",-7}{"IdShowCase",-15}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Count",-10}{"Price",-10}\r\n");
            _view.SendText += ("\r\n");
            for (var i = 0; i < selectShowCase.ListClassProducts.Count; i++)
            {
                _view.SendText += ($"{i + 1,-7}{selectShowCase.Id,-15}{selectShowCase.ListClassProducts[i].Id,-15}{selectShowCase.ListClassProducts[i].Cathegory,-18}{selectShowCase.ListClassProducts[i].Name,-20}{selectShowCase.ListClassProducts[i].Vol,-10}{selectShowCase.ListClassProducts[i].Count,-10}{selectShowCase.ListClassProducts[i].Price,-10}\r\n");
            }
            _view.SendText += ("\r\n");
            _view.SendText += ("Для продолжения нажмите любую кнопку...\r\n");
            _view.WriteTextBuffer();
            _view.ReadLine();
        }
        public void AddExistProductOnShowCase(int numCommand)
        {
            _view.Clear();
            var selSC = SelectShowCase();

            bool isEndAdd = true;
            while (isEndAdd)
            {
                _view.Clear();
                _view.SendText += ($"Все доступные для добавления товары:\r\n");
                _view.SendText += ("\r\n");
                _view.SendText += ($"{"N",-7}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Price",-10}{"IsEditable",-10}\r\n");
                _view.SendText += ("\r\n");

                for (var i = 0; i < ClassShopProducts.ListProducts.Count; i++)
                {
                    _view.SendText += ($"{i + 1,-7}{ClassShopProducts.ListProducts[i].Id,-15}{ClassShopProducts.ListProducts[i].Cathegory,-18}{ClassShopProducts.ListProducts[i].Name,-20}{ClassShopProducts.ListProducts[i].Vol,-10}{ClassShopProducts.ListProducts[i].Price,-10}{(ClassShopProducts.ListProducts[i].IsEditable).ToString(),-10}\r\n");
                }
                _view.SendText += ("Введите номер продукта:\r\n");
                _view.WriteTextBuffer();

                var isSuccessAdd = selSC.AddItem(ClassShopProducts.ListProducts[_view.ReadInt(ClassShopProducts.ListProducts.Count+1)]);
                _view.Clear();
                if (isSuccessAdd)
                    _view.SendText += ("Товар добавлен\r\n");
                else
                    _view.SendText += ("Ошибка добавления Товара.\r\n");

                _view.SendText += ("{Хотите продолжить? (y/n)\r\n");
                _view.WriteTextBuffer();
                isEndAdd = WaitYorN();

            }
        }
        public void AddNewProductOnShowCase(int numCommand)
        {
            _view.Clear();
            var selectShowCase = SelectShowCase();
            var isEndAdd = true;
            while (isEndAdd)
            {
                _view.Clear();
                _view.SendText+=("\r\n");
                _view.SendText += ("Добавление товара\r\n");
                _view.SendText += ("");
                _view.SendText += ("Введите название товара\r\n");
                _view.WriteTextBuffer();
                string nameProduct = _view.ReadLine();
                _view.SendText += ("\r\n");
                _view.SendText += ("Введите объем товара\r\n");
                _view.WriteTextBuffer();
                var volProduct = _view.ReadInt(int.MaxValue);
                _view.SendText += ("\r\n");
                _view.SendText += ("Введите цену товара\r\n");
                _view.WriteTextBuffer();
                var priceProduct = _view.ReadInt(int.MaxValue);
                var isSuccessAdd = selectShowCase.AddItem(new ClassProduct(nameProduct, selectShowCase.Cathegory, volProduct, priceProduct));
                _view.Clear();
                if (isSuccessAdd)
                    _view.SendText += ("Товар добавлен\r\n");
                else
                    _view.SendText += ("Ошибка добавления Товара.\r\n");

                _view.SendText += ("{Хотите продолжить? (y/n)\r\n");
                _view.WriteTextBuffer();
                isEndAdd = WaitYorN();
            }
        }
        public void AddShowCase(int numCommand)
        {
            _view.Clear();
            var isEndAdd = true;
            while (isEndAdd)
            {
                _view.Clear();
                _view.SendText += ("\r\n");
                _view.SendText += ("Добавление витрины\r\n");
                _view.SendText += ("");
                _view.SendText += ("Введите название витрины\r\n");
                _view.WriteTextBuffer();
                string nameShowCase = _view.ReadLine();
                _view.SendText += ("\r\n");
                _view.SendText += ("Введите объем витрины\r\n");
                _view.WriteTextBuffer();
                var volShowCase = _view.ReadInt(int.MaxValue);
                _view.SendText += ("\r\n");
                _view.SendText += ("Введите категорию витрины");
                _view.WriteTextBuffer();
                string cathegoryShowCase = _view.ReadLine();
                var isSuccessAdd = ClassShopProducts.AddItem(new ClassShowCase<ClassProduct>(volShowCase, nameShowCase, cathegoryShowCase));
                _view.Clear();
                if (isSuccessAdd)
                    _view.SendText += ("Витрина добавлена\r\n");
                else
                    _view.SendText += ("Ошибка добавления витрины.\r\n");
                _view.SendText += ("{Хотите продолжить? (y/n)\r\n");
                _view.WriteTextBuffer();
                isEndAdd = WaitYorN();
            }
        }
        public void AddProduct(int numCommand)
        {
            _view.Clear();
            var isEndAdd = true;
            while (isEndAdd)
            {
                _view.Clear();
                _view.SendText+=("\r\n");
                _view.SendText+=("Добавление товара\r\n");
                _view.SendText+=("");
                _view.SendText += ("Введите название товара\r\n");
                _view.WriteTextBuffer();
                string nameShowCase = _view.ReadLine();
                _view.SendText+=("\r\n");
                _view.SendText += ("Введите категорию товара\r\n");
                _view.WriteTextBuffer();
                string nameCategory = _view.ReadLine();

                _view.SendText+=("\r\n");
                _view.SendText += ("Введите объем товара\r\n");
                _view.WriteTextBuffer();
                var volProduct = _view.ReadInt(int.MaxValue);

                _view.SendText+=("\r\n");
                _view.SendText += ("Введите цену товара\r\n");
                _view.WriteTextBuffer();
                var priceProduct = _view.ReadInt(int.MaxValue);
                var isSuccessAdd=ClassShopProducts.AddProduct(new ClassProduct(nameShowCase, nameCategory, volProduct, priceProduct));

                _view.Clear();
                if (isSuccessAdd)
                    _view.SendText += ("Товар добавлен\r\n");
                else
                    _view.SendText += ("Ошибка добавления Товара.\r\n");

                _view.SendText += ("{Хотите продолжить? (y/n)\r\n");
                _view.WriteTextBuffer();
                isEndAdd = WaitYorN();
            }
        }
        public void EditShowCaseParams(int numCommand)
        {
        }//доделаю позже
        public void EditProductParams(int numCommand)
        {
        }//доделаю позже
        public void RemoveShowCase(int numCommand)
        {
            _view.Clear();
            var sSc = SelectShowCase();
            var isEndRemove = true;
            while (isEndRemove)
            {
                _view.Clear();
                _view.SendText += ("Удаление витрины:\r\n");
                _view.SendText += ("\r\n");
                var isSuccessRemove = ClassShopProducts.RemoveItem(sSc.Id);
                _view.Clear();
                if (isSuccessRemove)
                    _view.SendText += ("Витрина удалена\r\n");
                else
                    _view.SendText += ("Ошибка удаления витрины\r\n");

                _view.SendText += ("{Хотите продолжить? (y/n)\r\n");
                _view.WriteTextBuffer();
                isEndRemove = WaitYorN();
            }
        }
        public void RemoveProduct(int numCommand)
        {
            _view.Clear();
            var isEndRemove = true;
            while (isEndRemove)
            {
                _view.Clear();
                _view.SendText += ($"Все доступные продукты:\r\n");
                _view.SendText += ("\r\n");
                _view.SendText += ($"{"N",-7}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}{"Price",-10}\r\n");
                _view.SendText += ("");
                var products = ClassShopProducts.ListProducts;
                for (int i = 0; i < products.Count; i++)
                {
                    _view.SendText += ($"{i + 1,-7}{products[i].Id,-15}{products[i].Cathegory,-18}{products[i].Name,-20}{products[i].Vol,-10}{products[i].Price,-10}\r\n");
                }
                _view.SendText += ("\r\n");
                _view.SendText += ("Выберите продукт\r\n");
                _view.WriteTextBuffer();
                int numProduct = _view.ReadInt(ClassShopProducts.ListProducts.Count+1);



                var isSuccessRemove = ClassShopProducts.RemoveProduct(ClassShopProducts.ListProducts[numProduct - 1].Id);
                _view.Clear();
                if (isSuccessRemove)
                    _view.SendText += ("Продукт удален\r\n");
                else
                    _view.SendText += ("Ошибка удаления продукта\r\n");

                _view.SendText += ("{Хотите продолжить? (y/n)\r\n");
                _view.WriteTextBuffer();
                isEndRemove = WaitYorN();
            }
        }
        public void RemoveProductOnShowCase(int numCommand)
        {
            _view.Clear();
            var sSc = SelectShowCase();
            var isEndRemove = true;
            while (isEndRemove)
            {
                _view.Clear();
                _view.SendText+=("Удаление продукта с витрины:\r\n");
                _view.SendText += ("\r\n");
                var sP = SelectProductOnShowCase(sSc);
                var isSuccessRemove = sSc.RemoveItem(sP.Id);
                _view.Clear();
                if (isSuccessRemove)
                    _view.SendText += ("Продукт удален\r\n");
                else
                    _view.SendText += ("Ошибка удаления продукта\r\n");

                _view.SendText += ("{Хотите продолжить? (y/n)\r\n");
                _view.WriteTextBuffer();
                isEndRemove = WaitYorN();
            }
        }
        private ClassShowCase<ClassProduct> SelectShowCase()
        {
            _view.Clear();
            _view.SendText += "Доступные витрины" + "\r\n";
            _view.SendText += "\r\n";
            _view.SendText += ($"{"Id",-7}{"Name",-18}{"Vol",-10}{"AvalibleVol",-10}" + "\r\n");
            _view.SendText += ("") + "\r\n";
            for (int i = 0; i < ClassShopProducts.ListShowCases.Count; i++)
            {
                _view.SendText += ($"{ClassShopProducts.ListShowCases[i].Id,-7}{ClassShopProducts.ListShowCases[i].Name,-18}{ClassShopProducts.ListShowCases[i].Vol,-10}{ClassShopProducts.ListShowCases[i].AvalibleVol,-10}" + "\r\n");
            }
            _view.SendText += ("\r\n");
            _view.SendText += ("Выберите витрину" + "\r\n");
            _view.WriteTextBuffer();
            var num = _view.ReadInt(ClassShopProducts.ListShowCases.Count+1);
            _view.Clear();
            return ClassShopProducts.ListShowCases.Where(dat => dat.Id == num).ToArray()[0]; ;
        }
        private ClassProduct SelectProductOnShowCase(ClassShowCase<ClassProduct> selectShowCase)
        {
            _view.SendText+=("Доступные продукты\r\n");
            _view.SendText += ("");
            _view.SendText += ($"{"N",-7}{"IdShowCase",-15}{"IdProduct",-15}{"Cathegory",-18}{"Name",-20}{"Vol",-10}\r\n");
            _view.SendText += ("\r\n");
            for (int i = 0; i < selectShowCase.ListClassProducts.Count; i++)
            {
                _view.SendText += ($"{i + 1,-7}{selectShowCase.Id,-15}{selectShowCase.ListClassProducts[i].Id,-15}{selectShowCase.ListClassProducts[i].Cathegory,-18}{selectShowCase.ListClassProducts[i].Name,-20}{selectShowCase.ListClassProducts[i].Vol,-10}\r\n");
            }
            _view.SendText += ("\r\n");
            _view.SendText += ("Выберите продукт\r\n");
            _view.WriteTextBuffer();
            var num = _view.ReadInt(selectShowCase.ListClassProducts.Count+1);
            _view.Clear();
            var selectProduct = selectShowCase.ListClassProducts[num - 1];
            return selectProduct;
        }
        private bool WaitYorN()
        {
            string returnVal;
            while (true)
            {
                var answer = _view.ReadLine();
                if (answer == "y" || answer == "n")
                {
                    returnVal = answer;
                    break;
                }
                _view.WriteTextBuffer(answer);
            }
            if (returnVal == "y")
                return true;
            else
                return false;
        }
    }
}
