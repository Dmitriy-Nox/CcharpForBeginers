using System;
using System.Collections.Generic;
using System.Text;
using NewShop.Model.Menu;
using NewShop.View;

namespace NewShop
{
    public class MenuControl
    {
        private IView _view;
        public MenuControl(IView view)
        {
            _view = view;
        }
        public MenuItem CurrentMenuItem;
        public bool IsStartMenu = true;
        public void NextLevelMenu(int numCommand)
        {
            CurrentMenuItem = CurrentMenuItem.NextMenuItems[numCommand-1];
        }
        public void PrevLevelMenu(int numCommand)
        {
            if (CurrentMenuItem.PrevMenuItem != null)
                CurrentMenuItem = CurrentMenuItem.PrevMenuItem;
            else
            {
                IsStartMenu = false;
                _view.Clear();
                _view.WriteTextBuffer("Вы вышли из меню магазина");
            }
        }
        public void ResetLevelMenu()
        {
            while(CurrentMenuItem.PrevMenuItem != null)
                CurrentMenuItem = CurrentMenuItem.PrevMenuItem;
        }
    }
}
