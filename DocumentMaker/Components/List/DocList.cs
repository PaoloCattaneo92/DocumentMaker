using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// Abstract base class of a MD list.
    /// See extensions for detailed descriptions:
    /// - <see cref="DotList"/>
    /// - <see cref="NumberList"/>
    /// - <see cref="RomanList"/> (requires <see cref="Document.EnableExtraList"/>)
    /// - <see cref="LetterList"/> (requires <see cref="Document.EnableExtraList"/>)
    /// - <see cref="TaskList"/> (requires <see cref="Document.EnableTaskList"/>)
    /// </summary>
    public abstract class DocList : RenderedObj
    {
        /// <summary>
        /// Items of the list
        /// </summary>
        public List<string> Items { get; set; }

        /// <summary>
        /// Constructor. Initialize an empty list
        /// </summary>
        protected DocList()
        {
            Items = new List<string>();
        }
        /// <summary>
        /// Constructor. Initialize the list with the given items
        /// </summary>
        /// <param name="items">The initial items of the list</param>
        protected DocList(params string[] items) : this()
        {
            foreach(string i in items)
            {
                AddItem(i);
            }
        }
        /// <summary>
        /// Add an item (a string) to the list
        /// </summary>
        /// <param name="item">A string element to be added to the list</param>
        public void AddItem(string item)
        {
            Items?.Add(item);
        }
    }
}