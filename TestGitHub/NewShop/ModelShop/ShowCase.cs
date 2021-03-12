using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewShop.ModelShop.Interfaces;

namespace NewShop.ModelShop
{
    public class ClassShowCase<T> : IParams, IEdit, IPlace<T> where T : ClassProduct
    {
        public List<ClassProduct> ListClassProducts = new List<ClassProduct>();
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
                return Vol-ListClassProducts.Select(dat => dat.Vol*dat.Count).Sum();
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
        public bool IsEditable => ListClassProducts.Count != 0;
        public bool RemoveItem(int id)
        {
            var items = ListClassProducts.Where(dat => dat.Id == id).ToArray();
            if (items.Length == 0)
                return false;
            if (items[0].Count > 0)
                items[0].Count--;
            else
                ListClassProducts.Remove(items[0]);
            return true;
        }
        public bool AddItem(T item)
        {
            if (item.Vol > AvalibleVol)
                return false;
            if (item.Cathegory != Cathegory)
                return false;
            var itemFromCurrName = ListClassProducts.Where(dat => dat.Name == item.Name).ToList();
            if (itemFromCurrName.Count == 0)
            {
                item.Count++;
                ListClassProducts.Add(item);
            }
            else
                ListClassProducts[ListClassProducts.IndexOf(itemFromCurrName[0])].Count++;
            return true;
        }
        public bool EditVol(int newVal)
        {
            if (newVal < ListClassProducts.Select(dat => dat.Vol).Sum())
                return false;
            Vol = newVal;
            return true;
        }
        public bool EditName(string newVal)
        {
            if (ListClassProducts.Count!=0)
                return false;
            Name = newVal;
            return true;
        }
        public bool EditCathegory(string newVal)
        {
            if (ListClassProducts.Count != 0)
                return false;
            Cathegory = newVal;
            return true;
        }
        public bool EditPrice(string newVol)
        {
            return true;
        }
    }
}
