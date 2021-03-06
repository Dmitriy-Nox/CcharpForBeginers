﻿using Shop.ModelShop.Interfaces;

namespace Shop.ModelShop
{
    public class ClassProduct:IParams, IEdit
    {
        public ClassProduct(string name, string cathegory, double vol,decimal price)
        {
            Name = name;
            Vol = vol;
            Id = idProduct++;
            Cathegory = cathegory;
            Price = price;
        }
        static int idProduct = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Vol { get; set; }
        public decimal Price { get; set; }
        public string Cathegory { get; set; }
        public int Count { get; set; } = 0;
        public bool IsEditable => Count == 0;
        public bool EditVol(int newVal)
        {
            if (IsEditable)
                return false;
            Vol = newVal;
            return true;
        }
        public bool EditName(string newVal)
        {
            if (IsEditable && newVal != "")
                return false;
            Name = newVal;
            return true;
        }
        public bool EditCathegory(string newVal)
        {
            if (IsEditable && newVal != "")
                return false;
            Cathegory = newVal;
            return true;
        }
        public bool EditPrice(string newVal)
        {
            if (IsEditable && newVal != "")
                return false;
            Cathegory = newVal;
            return true;
        }
    }
}
