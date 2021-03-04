using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Menu
{
    public class MenuBlock
    {
        public MenuBlock(List<MenuItem> currFunctions)
        {
            //CurrFunctions = currFunctions;
        }


        public int ExitNumber
        {
            get
            {
                int numberInt = 0; ;
                int numberExit = 0; ;

                //foreach (var item in CurrFunctions)
                //{
                //    if (int.TryParse(item.Text.Split(')')[0], out numberInt))
                //    {
                //        numberExit = numberInt;
                //        continue;
                //    }
                //}
                return numberExit;
            }
        }


    }
}
