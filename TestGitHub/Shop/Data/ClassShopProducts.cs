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
            var items = ListShowCases.Where(dat => dat.Id == id).ToArray();
            if (items.Length == 0)
                return false;
            if (items[0].ListClassProducts.Count != 0)
                return false;

                ListShowCases.Remove(items.ToArray()[0]);
            return true;
        }

        public bool AddItem(T item)
        {
            ListShowCases.Add(item);
            return true;//Пока не было ограничения по витринам
        }

        public List<ClassProduct> ListProducts => ListShowCases.SelectMany(dat => dat.ListClassProducts).ToList();
    }
}
