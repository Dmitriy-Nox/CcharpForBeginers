using System.Collections.Generic;
using System.Linq;
using Shop.ModelShop.Interfaces;

namespace Shop.ModelShop
{
    public class ClassShopProducts<T>:IPlace<T> where T : ClassShowCase<ClassProduct>
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
            var itemFromCurrName = ListShowCases.Where(dat => dat.Name == item.Name).ToList();
            if (itemFromCurrName.Count == 0)
                ListShowCases.Add(item);
            return true;
        }

        public bool RemoveProduct(int id)
        {
            var items = ListProducts.Where(dat => dat.Id == id).ToArray();
            if (items.Length == 0)
                return false;
            ListProducts.Remove(items.ToArray()[0]);
            return true;
        }

        public bool AddProduct(ClassProduct item)
        {
            var items = ListProducts.Where(dat => dat.Name == item.Name).ToArray();
            if (items.Length > 0)
                return false;
            ListProducts.Add(new ClassProduct(item.Name, item.Cathegory, item.Vol, item.Price));
            return true;
        }

        public List<ClassProduct> listProducts;

        public List<ClassProduct> ListProducts
        {
            get
            {
                if(listProducts==null)
                {
                    listProducts = ListShowCases.SelectMany(dat => dat.ListClassProducts).ToList();
                }
                return listProducts;
            }
            set
            {
                listProducts = value;
            }
        }
    }
}
