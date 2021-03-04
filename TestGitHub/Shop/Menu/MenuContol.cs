using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Menu
{
    public class MenuContol
    {
        //public MenuContol(List<MenuItem> lstMenuItems)
        //{
        //    MenuItems = lstMenuItems;
        //    //MenuBlock.CurrFunctions = MenuItems;
        //    //MenuBlock.PrevMenuBlock = null;
        //}

        ////public MenuBlock MenuBlock { get; set; } = new MenuBlock();

        //private List<MenuItem> menuItems;
        //public List<MenuItem> MenuItems
        //{
        //    get
        //    {
        //        return menuItems;
        //    }
        //    set
        //    {
        //        if (menuItems == null)
        //            menuItems = new List<MenuItem>();
        //        var items = value;

        //        menuItems.Insert(0, new MenuItem("Выберите действие:",null));
        //        menuItems.AddRange(items);
        //        menuItems.Add(new MenuItem("\r\nВыбрано:",null));
        //    }
        //}



        ////private MenuBlock currMenu;
        ////public MenuBlock CurrMenu
        ////{
        ////    get
        ////    {
        ////        if (currMenu == null)
        ////        {
        ////            currMenu = FirstMenu;
        ////            return currMenu;
        ////        }


        ////        currMenu = currMenu.Next;
        ////        return currMenu;
        ////    }
        ////}

        ////public void Add(List<MenuItem> listItems)
        ////{
        ////    MenuBlock box = new MenuBlock(listItems);

        ////    if (FirstMenu == null && LastMenu == null)
        ////    {
        ////        FirstMenu = box;
        ////        LastMenu = box;

        ////    }
        ////    else
        ////    {
        ////        //if(First.Next==null)
        ////        //    First.Next = box;

        ////        LastMenu.Next = box;
        ////        LastMenu = box;
        ////    }
        ////    //_count++;
        ////}

        ////public MenuBlock FirstMenu;
        ////public MenuBlock LastMenu;

    }
}
