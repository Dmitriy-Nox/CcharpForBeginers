using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewShop.Model.Menu
{
    public class MenuItem
    {
        public MenuItem(string Text, DelegateMenuItem delegateMenuItem = null,List < MenuItem> nextMenuItems=null)
        {
            this.Text = Text;
            this.FuncMenuItem = delegateMenuItem;
            if (nextMenuItems != null)
            {
                NextMenuItems = nextMenuItems;

                for (var i = 0; i < nextMenuItems.Count; i++)
                    nextMenuItems[i].PrevMenuItem = this;
            }
        }
        public string Text { get; }
        public delegate void DelegateMenuItem(int numCommand);
        public DelegateMenuItem FuncMenuItem;
        public List<MenuItem> NextMenuItems;
        public string NextMenuItemsText => String.Join("\n\r", NextMenuItems.Select(dat => dat.Text));
        public MenuItem PrevMenuItem;
    }
}
