using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Menu
{
    public class MenuContol
    {
        public MenuContol(List<MenuItem> lstMenuItems)
        {
            MenuItems = lstMenuItems;
            MenuBlock.CurrMenuBlock = MenuItems;
            MenuBlock.PrevMenuBlock = null;
        }

        public MenuBlock MenuBlock { get; set; } = new MenuBlock();

        private List<MenuItem> menuItems;
        public List<MenuItem> MenuItems
        {
            get
            {
                return menuItems;
            }
            set
            {
                if (menuItems == null)
                    menuItems = new List<MenuItem>();
                var items = value;

                menuItems.Insert(0, new MenuItem("Выберите действие:"));
                menuItems.AddRange(items);
                menuItems.Add(new MenuItem("\r\nВыбрано:"));
            }
        }

    }
}
