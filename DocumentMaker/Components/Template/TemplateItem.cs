using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// An item of the template, with a key-val syntax
    /// </summary>
    public class TemplateItem
    {
        /// <summary>
        /// Key of the template item
        /// </summary>
        /// <example>"name"</example>
        public string Key { get; set; }
        /// <summary>
        /// Value of the template item
        /// </summary>
        /// <example>"Paolo"</example>
        public string Val { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="key"><see cref="Key"/></param>
        /// <param name="val"><see cref="Val"/></param>
        public TemplateItem(string key, string val)
        {
            Key = key;
            Val = val;
        }
        /// <summary>
        /// Constructor. Set the value as an empty string
        /// </summary>
        /// <param name="key"><see cref="Key"/></param>
        public TemplateItem(string key) : this(key, "")
        {
        }
        /// <summary>
        /// Empty constructor. This does not instantiate
        /// anything, but it is used when Template is rendered from YAML.
        /// </summary>
        public TemplateItem()
        {
        }
    }
}
