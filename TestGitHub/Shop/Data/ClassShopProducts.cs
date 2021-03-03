using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Data.Intarfaces;

namespace Shop.Data
{
    public class ClassShopProducts<T>: IPlace<T> where T : ClassShowCase<ClassProduct>
    {
        public ClassShopProducts()
        {

        }

        public List<T> ListShowCases;

        public bool RemoveItem(int id)
        {
            if (ListShowCases.Where(dat => dat.Id == id).ToArray().Length == 0)
                return false;

            ListShowCases.Remove(ListShowCases.Where(dat=> dat.Id== id).ToArray()[0]);
            return true;
        }

        public bool AddItem(T item)
        {
            var ss = (T)item;
               var iParams = item as IParams;
            var showCase = new ClassShowCase<ClassProduct>(iParams.Vol, iParams.Name,iParams.Cathegory);
            ListShowCases.Add(item);

            return true;//Пока не было ограничения по витринам
        }

        public List<ClassProduct> ListProducts => ListShowCases.SelectMany(dat => dat.ListClassProducts).ToList();
    }
}
