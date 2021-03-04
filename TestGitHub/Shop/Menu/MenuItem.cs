using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Menu
{
    public class MenuItem
    {
        public MenuItem(string Text, DelegateMenuItem delegateMenuItem)
        {
            FuncMenuItem += delegateMenuItem;
            NextMenuItems = new List<MenuItem>();
            PrevMenuItems = new List<MenuItem>();
            this.Text = Text;
        }

        public string Text { get; }

        public List<MenuItem> NextMenuItems;

        public List<MenuItem> PrevMenuItems;


        public void AddNewReference(List<MenuItem> newMenuItems)
        {
            NextMenuItems = newMenuItems;
            for(var i=0;i<NextMenuItems.Count;i++)
            {
                NextMenuItems[i].PrevMenuItems = NextMenuItems;
            }
            NextMenuItems = newMenuItems;
        }

        public int ExitNumber => NextMenuItems.Count;

        public delegate void DelegateMenuItem(int numCommand);

        public DelegateMenuItem FuncMenuItem;


    }
        
}
