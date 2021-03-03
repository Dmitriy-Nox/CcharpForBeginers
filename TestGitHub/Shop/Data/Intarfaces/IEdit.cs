using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Intarfaces
{
    public interface IEdit
    {
        bool Editable<T>(T oldItem, T newItem);
    }
}
