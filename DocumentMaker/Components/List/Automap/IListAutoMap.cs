using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// Interface for AutoMap lists. They must implement SetItem.
    /// </summary>
    /// <typeparam name="E">The type of the object the list will parse</typeparam>
    public interface IListAutoMap<E>
    {
        void SetItem(E e);
    }
}
