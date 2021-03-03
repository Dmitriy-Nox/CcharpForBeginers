using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Menu
{
    public class MenuItem
    {
        public MenuItem(string Text)
        {
            this.Text = Text;
        }

        public string Text { get; }

        private List<MenuItem> nextMenuItems;
        public List<MenuItem> NextMenuItems
        {
            get
            {
                return nextMenuItems;
            }
            set
            {
                if (nextMenuItems == null)
                    nextMenuItems = new List<MenuItem>();
                var items = value;

                nextMenuItems.Insert(0, new MenuItem("Выберите действие:"));
                nextMenuItems.AddRange(items);
                nextMenuItems.Add(new MenuItem("\r\nВыбрано:"));
            }
        }      

        public int ExitNumber { get; set; }

        public delegate void DelegateMenuItem(int numCommand);

        public DelegateMenuItem FuncMenuItem;


    }
        
}
