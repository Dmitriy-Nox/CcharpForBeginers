using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Menu
{
    public class MenuBlock
    {
        public MenuBlock()
        {

        }
        public List<MenuItem> CurrMenuBlock { get; set; }

        public List<MenuItem> NextMenuBlock { get; set; }

        public List<MenuItem> PrevMenuBlock { get; set; }

        public int ExitNumber
        {
            get
            {
                int numberInt = 0; ;
                int numberExit = 0; ;

                foreach (var item in CurrMenuBlock)
                {
                    if (int.TryParse(item.Text.Split(')')[0], out numberInt))
                    {
                        numberExit = numberInt;
                        continue;
                    }
                }
                return numberExit;
            }
        }

        public void  AddMenuBlock(List<MenuItem> menuBlock)
        {
            if (CurrMenuBlock == null)
                CurrMenuBlock = menuBlock;

            PrevMenuBlock = CurrMenuBlock;
            CurrMenuBlock = menuBlock;

        }

    }
}
