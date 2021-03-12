using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Shop.Controls;
using Shop.Model.Menu;
using Shop.View;

namespace Shop
{
    public class Shop
    {
        public ShopControl ShopController;
        public MenuControl MainMenu;
        private IView _view;
        public Shop(IView view)
        {
            _view = view;
            ShopController = new ShopControl(_view);
            MainMenu = CreateMenu();
        }
        private MenuControl CreateMenu()
        {
            MenuControl menuControl = new MenuControl(_view);
            var menuItem = new MenuItem("Shop", null, new List<MenuItem>()
            {
                new MenuItem("1) Открыть витрину",ShopController.OpenShowCase),
                new MenuItem("2) Редактировать витрину",menuControl.NextLevelMenu,new List<MenuItem>()
                {
                    new MenuItem("1) Создать новую витрину", ShopController.AddShowCase),
                    new MenuItem("2) Добавить товар на витрину",menuControl.NextLevelMenu,new List<MenuItem>()
                    {
                        new MenuItem("1) Добавить новый товар  ", ShopController.AddNewProductOnShowCase),
                        new MenuItem("2) Добавить существующий товар ", ShopController.AddExistProductOnShowCase),
                        new MenuItem("3) Выход ", menuControl.PrevLevelMenu)
                    }),
                    new MenuItem("3) Удалить товар с витрины", ShopController.RemoveProductOnShowCase),
                    new MenuItem("4) Изменить витрину", ShopController.EditShowCaseParams),
                    new MenuItem("5) Удалить витрину", ShopController.RemoveShowCase),
                    new MenuItem("6) Выход ", menuControl.PrevLevelMenu)
                 }),
                new MenuItem("3) Редактировать товары",menuControl.NextLevelMenu, new List<MenuItem>()
                {
                    new MenuItem("1) Добавить товар", ShopController.AddProduct),
                    new MenuItem("2) Открыть все товары", ShopController.OpenAllProducts),
                    new MenuItem("3) Удалить товар", ShopController.RemoveProduct),
                    new MenuItem("4) Редактировать товар", ShopController.EditProductParams),
                    new MenuItem("5) Выход ", menuControl.PrevLevelMenu)
                }),
                new MenuItem("4) Выход", menuControl.PrevLevelMenu)
            });
            menuControl.CurrentMenuItem = menuItem;
            return menuControl;
        }
        private void ThreadShop()
        {
            while (MainMenu.IsStartMenu)
            {
                _view.Clear();
                for (int i = 0; i < MainMenu.CurrentMenuItem.NextMenuItems.Count; i++)
                {
                    _view.SendText += MainMenu.CurrentMenuItem.NextMenuItems[i].Text + "\r\n";
                }
                _view.WriteTextBuffer();

                var num = _view.ReadInt(MainMenu.CurrentMenuItem.NextMenuItems.Count + 1);
                if (MainMenu.CurrentMenuItem.NextMenuItems[Convert.ToInt32(num) - 1].FuncMenuItem != null)
                    MainMenu.CurrentMenuItem.NextMenuItems[Convert.ToInt32(num) - 1].FuncMenuItem?.Invoke(Convert.ToInt32(num));
            }
        }
        public void Start()
        {
            new Thread(() => ThreadShop()).Start();
        }
    }
}

