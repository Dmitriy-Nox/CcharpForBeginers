using System;
using System.Collections.Generic;
using System.Text;

namespace NewShop.ModelShop.Interfaces
{
    public interface IPlace<T>
    {
        bool RemoveItem(int id);
        bool AddItem(T item);
    }
}
