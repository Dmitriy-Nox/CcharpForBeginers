using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Intarfaces
{
    public interface  IParams
    {
       int Id { get; set; }

       string Name { get; set; }

       double Vol { get; set; }

       decimal Price { get; set; }
    }
}
