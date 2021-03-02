using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Data.Intarfaces;

namespace Shop.Data
{
    public class ClassShopProducts:IPlace
    {
        public ClassShopProducts()
        {

        }

        public List<ClassShowCase> ListShowCases;

        public void RemoveItem<T>(T item)
        {
            var iParams = item as IParams;
            ListShowCases.Remove(ListShowCases.Where(dat=>dat.Id==iParams.Id).ToArray()[0]);
        }

        public bool AddItem<T>(T item)
        {
            var iParams = item as IParams;
            var showCase = new ClassShowCase(iParams.Vol, iParams.Name);
            ListShowCases.Add(showCase);

            return true;//Пока не было ограничения по витринам
        }
    }
}
