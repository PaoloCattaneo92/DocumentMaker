using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// A <see cref="DotList"/> that map automatically the values the
    /// properites of an object (set in constructor or calling <see cref="SetItem(E)"/>
    /// This class calls the static <see cref="ListAutoMapper{E}.Parse(E)"/> to parse the object.
    /// </summary>
    /// <typeparam name="E">The type of the object that will be parsed in the list</typeparam>
    public class DotListAutoMap<E> : DotList, IListAutoMap<E>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="item">The item that will be parsed</param>
        public DotListAutoMap(E item)
        {
            SetItem(item);
        }
        /// <summary>
        /// Constrcutor. Will not initialize the parsing item.
        /// </summary>
        public DotListAutoMap()
        {
        }
        /// <summary>
        /// Set the parsed item.
        /// </summary>
        /// <param name="e">The item that will be parsed by <see cref="ListAutoMapper{E}"/></param>
        public void SetItem(E e)
        {
            Items = ListAutoMapper<E>.Parse(e).ToList();
        }
    }
}
