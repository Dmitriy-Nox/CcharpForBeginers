using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public interface IPlace
    {
        void RemoveItem<T>(T item);
        bool AddItem<T>(T item);
    }
}
