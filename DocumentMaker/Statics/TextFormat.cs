using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This static class contains methods used to change appearance of
    /// text (make it bold, italic and much more)
    /// </summary>
    public static class TextFormat
    {
        /// <summary>
        /// Make the parameter string bold style
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <returns>The modified string</returns>
        public static string Bold(string original)
        {
            return DocumentMakerConstants.BOLD + original + DocumentMakerConstants.BOLD;
        }
        /// <summary>
        /// Make the parameter string italic style
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <returns>The modified string</returns>
        public static string Ital(string original)
        {
            return DocumentMakerConstants.ITALIC + original + DocumentMakerConstants.ITALIC;
        }
        /// <summary>
        /// Make the parameter string as a code style
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <returns>The modified string</returns>
        public static string Code(string original)
        {
            return DocumentMakerConstants.CODE_ONELINE + original + DocumentMakerConstants.CODE_ONELINE;
        }
        /// <summary>
        /// Make the parameter string deleted (with an horizontal line on it)
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <returns>The modified string</returns>
        public static string Del(string original)
        {
            return DocumentMakerConstants.DELETE + original + DocumentMakerConstants.DELETE;
        }
        /// <summary>
        /// Make the parameter string as apex
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <returns>The modified string</returns>
        public static string Apex(string original)
        {
            return DocumentMakerConstants.APEX + original + DocumentMakerConstants.APEX;
        }
        /// <summary>
        /// Make the parameter string as sub
        /// (opposite of apex)
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <returns>The modified string</returns>
        public static string Sub(string original)
        {
            return DocumentMakerConstants.TILDE + original + DocumentMakerConstants.TILDE;
        }
        /// <summary>
        /// Make the parameter string marked (usually highlighted in yellow, but
        /// it depends on the CSS used)
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <returns>The modified string</returns>
        public static string Mark(string original)
        {
            return DocumentMakerConstants.MARKED + original + DocumentMakerConstants.MARKED;
        }
        /// <summary>
        /// Make the parameter string code multi line, you can specify also the name
        /// of the code contained
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <param name="codeName">The name of the code</param>
        /// <returns>The modified string</returns>
        public static string CodeMultiline(string original, string codeName)
        {
            var sb = new StringBuilder();
            sb.Append(DocumentMakerConstants.CODE_MULTILINE).Append(codeName).Append("\n")
                .Append(original)
                .Append(DocumentMakerConstants.CODE_MULTILINE).Append("\n");
            return sb.ToString();
        }
        /// <summary>
        /// Make the parameter string code multi line
        /// </summary>
        /// <param name="original">The string to modify</param>
        /// <returns>The modified string</returns>
        public static string CodeMultiline(string original)
        {
            return CodeMultiline(original, "");
        }
        /// <summary>
        /// Replace in the original string something that must be set to bold style
        /// </summary>
        /// <param name="original">The original string</param>
        /// <param name="toBold">A contained string that must be modified</param>
        /// <returns>The modified string</returns>
        public static string ReplaceBold(string original, string toBold)
        {
            return original.Replace(toBold, Bold(toBold));
        }
        /// <summary>
        /// Replace in the original string something that must be set to italic style
        /// </summary>
        /// <param name="original">The original string</param>
        /// <param name="toItalic">A contained string that must be modified</param>
        /// <returns>The modified string</returns>
        public static string ReplaceItalic(string original, string toItalic)
        {
            return original.Replace(toItalic, Ital(toItalic));
        }
        /// <summary>
        /// Replace in the original string something that must be set to code style
        /// </summary>
        /// <param name="original">The original string</param>
        /// <param name="toCode">A contained string that must be modified</param>
        /// <returns>The modified string</returns>
        public static string ReplaceCode(string original, string toCode)
        {
            return original.Replace(toCode, Code(toCode));
        }
        /// <summary>
        /// Replace in the original string something that must be set to deleted style
        /// </summary>
        /// <param name="original">The original string</param>
        /// <param name="toDelete">A contained string that must be modified</param>
        /// <returns>The modified string</returns>
        public static string ReplaceDelete(string original, string toDelete)
        {
            return original.Replace(toDelete, Del(toDelete));
        }
        /// <summary>
        /// Replace in the original string something that must be set to apex style
        /// </summary>
        /// <param name="original">The original string</param>
        /// <param name="toApex">A contained string that must be modified</param>
        /// <returns>The modified string</returns>
        public static string ReplaceApex(string original, string toApex)
        {
            return original.Replace(toApex, Apex(toApex));
        }
        /// <summary>
        /// Replace in the original string something that must be set to sub style
        /// </summary>
        /// <param name="original">The original string</param>
        /// <param name="toSub">A contained string that must be modified</param>
        /// <returns>The modified string</returns>
        public static string ReplaceSub(string original, string toSub)
        {
            return original.Replace(toSub, Sub(toSub));
        }
        /// <summary>
        /// Replace in the original string something that must be set to mark style
        /// </summary>
        /// <param name="original">The original string</param>
        /// <param name="toMark">A contained string that must be modified</param>
        /// <returns>The modified string</returns>
        public static string ReplaceMark(string original, string toMark)
        {
            return original.Replace(toMark, Mark(toMark));
        }
    }
}
