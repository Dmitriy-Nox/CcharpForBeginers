using System;
using System.Collections.Generic;
using System.Text;

namespace NewShop.ModelShop.Interfaces
{
    public interface IEdit
    {
        bool EditVol(int newVol);
        bool EditName(string newVol);
        bool EditCathegory(string newVol);
        bool EditPrice(string newVol);
        bool IsEditable { get; }
    }
}
