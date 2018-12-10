using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// Static utility class that parse the object
    /// for string values
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public static class ListAutoMapper<E>
    {
        /// <summary>
        /// Parse an object properties
        /// </summary>
        /// <param name="e">An Object</param>
        /// <returns>A string array with the values of its 
        /// properties (ToString() is called for each property)</returns>
        public static string[] Parse(E e)
        {
            var contentProperties = typeof(E).GetProperties();
            var items = new string[contentProperties.Length];
            for (int c = 0; c < contentProperties.Length; c++)
            {
                items[c] = e.GetType().GetProperty(contentProperties[c].Name).GetValue(e).ToString();
            }
            return items;
        }
    }
}
