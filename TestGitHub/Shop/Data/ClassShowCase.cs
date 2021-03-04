using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Data.Intarfaces;

namespace Shop.Data
{
    public class ClassShowCase<T> : IParams, IPlace<T> where T : ClassProduct
    {
        public ClassShowCase(double vol,string name,string cathegory)
        {
            DateTimeCreate = DateTime.Now;
            Id= idShowCase++;
            Name = name;
            Cathegory = cathegory;
            Vol = vol;

        }
        static int idShowCase = 1;
        public int Id { get; set; }

        public String Name { get; set; }

        public double Vol { get; set; }

        public double AvalibleVol
        {
            get
            {
                return Vol-ListClassProducts.Select(dat => dat.Vol).Sum();
            }
            set { }
        }

        

        public DateTime DateTimeCreate { get; set; }
        public decimal Price
        {
            get
            {
                if(ListClassProducts!=null)
                    return ListClassProducts.Select(dat=>dat.Price).Sum();
                return 0;
            }

            set { }
        }

        public string Cathegory { get; set; }

        public bool RemoveItem(int id)
        {
            var items = ListClassProducts.Where(dat => dat.Id == id).ToArray();
            if (items.Length == 0)
                return false;

            ListClassProducts.Remove(items.ToArray()[0]);
            return true;
        }

        public bool AddItem(T item)
        {
            if (item.Vol > AvalibleVol)
                return false;

            if (item.Cathegory != Cathegory)
                return false;

            ListClassProducts.Add(new ClassProduct(item.Name, item.Cathegory, item.Vol, item.Price));
            return true;
        }

        public List<ClassProduct> ListClassProducts=new List<ClassProduct>();
    }
}
