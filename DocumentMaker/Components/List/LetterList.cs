using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    public class LetterList : DocList
    {
        /// <summary>
        /// Type of the letter that must be rendered
        /// (uppercase or lowercase)
        /// </summary>
        public LetterType Type { get; set; }

        protected static readonly char[] ALPHABET_LOWER = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        protected static readonly char[] ALPHABET_UPPER = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        protected static readonly Dictionary<LetterType, char[]> ALPHABET = new Dictionary<LetterType, char[]>
        {
            {LetterType.LOWERCASE,  ALPHABET_LOWER},
            {LetterType.UPPERCASE,  ALPHABET_UPPER}
        };

        /// <summary>
        /// Constructor. Initialize an empty list.
        /// </summary>
        public LetterList() : base()
        {
        }
        /// <summary>
        /// Constructor. Initialize the list with the given parameter
        /// </summary>
        /// <param name="items">First elements of the list</param>
        public LetterList(params string[] items) : base(items)
        { }

        /// <summary>
        /// Constructor. Initialize an empty list and set <see cref="Type"/>
        /// with the parameter
        /// </summary>
        /// <param name="type">Set <see cref="Type"/></param>
        public LetterList(LetterType type) : base()
        {
            Type = type;
        }
        /// <summary>
        /// Constructor. Initialize the list with the given parameter
        /// and set <see cref="Type"/>
        /// </summary>
        /// <param name="type">Set <see cref="Type"/></param>
        /// <param name="items">First elements of the list</param>
        public LetterList(LetterType type, params string[] items) : base(items)
            {
            Type = type;
        }
        /// <summary>
        /// Append the rendered content of this <see cref="RenderedObj"/>
        /// to the given StringBuilder.
        /// </summary>
        /// <param name="sb">The StringBuilder where the rendered content will be appended</param>
        /// <returns>The same StringBuilder but with this content appendend</returns>
        public override StringBuilder Render(StringBuilder sb)
        {
            int index = 0;
            foreach (string item in Items)
            {
                sb.Append(ALPHABET[Type][index]).Append(". ").Append(item).Append("\n");
                index = (index + 1) % ALPHABET[Type].Length;
            }
            return sb;
        }
    }
}
