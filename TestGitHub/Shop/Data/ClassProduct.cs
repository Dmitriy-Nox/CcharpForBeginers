using System;
using System.Collections.Generic;
using System.Text;
using Shop.Data.Intarfaces;

namespace Shop.Data
{
    public class ClassProduct:IParams
    {
        public ClassProduct(string name, double vol,decimal price)
        {
            Name = name;
            Vol = vol;
            Id = idProduct++;
        }
        static int idProduct = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public double Vol { get; set; }
        public decimal Price { get; set; }

    }
}
