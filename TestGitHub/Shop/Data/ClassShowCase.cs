using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Data.Intarfaces;

namespace Shop.Data
{
    public class ClassShowCase : IParams, IPlace
    {
        public ClassShowCase(double vol,string name)
        {
            DateTimeCreate = DateTime.Now;
            Id= idShowCase++;
            Name = name;
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
        public void RemoveItem<ClassProduct>(ClassProduct item)
        {
            var itemParams = item as IParams;

            var selectShowCase = ListClassProducts.Remove(ListClassProducts.Where(dat => dat.Id == itemParams.Id).ToArray()[0]);
        }

        public bool AddItem<ClassProduct>(ClassProduct item)
        {
            var itemParams = item as IParams;
            if (ListClassProducts.Select(dat => dat.Vol).Sum() + itemParams.Vol > AvalibleVol)
                return false;

            ListClassProducts.Add(new Data.ClassProduct(itemParams.Name, itemParams.Vol, itemParams.Price));
            return true;
        }

        public List<ClassProduct> ListClassProducts=new List<ClassProduct>();
    }
}
