using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class represent an element of a <see cref="TaskList"/>
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Text to show for the element
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Flag that indicates if the box must be checked or not
        /// </summary>
        public bool Done { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text"><see cref="Text"/></param>
        /// <param name="done"><see cref="Done"/></param>
        public Task(string text, bool done)
        {
            Text = text;
            Done = done;
        }
        /// <summary>
        /// Constructor. Set <see cref="Done"/> to false.
        /// </summary>
        /// <param name="text"></param>
        public Task(string text) : this(text, false)
        {
        }
        /// <summary>
        /// Constructor. Set <see cref="Done"/> to false and <see cref="Text"/>
        /// as an empty string ("")
        /// </summary>
        public Task() : this("", false)
        {
        }
    }
}
