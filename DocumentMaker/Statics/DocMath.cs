using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This static class is used to write mathematical
    /// operations in MD.
    /// </summary>
    public static class DocMath
    {
        /// <summary>
        /// Write the content text as a Mathematical line
        /// </summary>
        /// <param name="text">The text to write in mathematical form</param>
        /// <returns>A mathematical text form</returns>
        public static string OneLine(string text)
        {
            var sb = new StringBuilder();
            sb.Append(" ")
                .Append(DocumentMakerConstants.MATH)
                .Append(text)
                .Append(DocumentMakerConstants.MATH);
            return sb.ToString();
        }

        /// <summary>
        /// Write the content text as a multiline mathematical text
        /// </summary>
        /// <param name="text">The text to write in mathematical form</param>
        /// <returns>A mathematical text form</returns>
        public static string MultiLine(string text)
        {
            var sb = new StringBuilder();
            sb.Append(DocumentMakerConstants.NEW_LINE)
                .Append(DocumentMakerConstants.MATH).Append(DocumentMakerConstants.NEW_LINE)
                .Append(text)
                .Append(DocumentMakerConstants.NEW_LINE).Append(DocumentMakerConstants.MATH);
            return sb.ToString();
        }
    }
}
