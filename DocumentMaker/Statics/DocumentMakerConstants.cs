using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This static class contains readonly constants called in
    /// different sections of the code.
    /// </summary>
    public static class DocumentMakerConstants
    {
        public static readonly string NEW_LINE = "\n";
        public static readonly string DOUBLE_NEW_LINE = NEW_LINE + NEW_LINE;
        public static readonly string MD_EXTENSION_FILE = ".md";
        public static readonly string HEADING_CHAR = "#";
        public static readonly string BOLD = "**";
        public static readonly string ITALIC = "_";
        public static readonly string CODE_ONELINE = "`";
        public static readonly string CODE_MULTILINE = "```";
        public static readonly string HR = "---";
        public static readonly string QUOTE = ">";
        public static readonly string LINKTEXT_OPEN = "[";
        public static readonly string LINKTEXT_CLOSE = "]";
        public static readonly string LINK_OPEN = "(";
        public static readonly string LINK_CLOSE = ")";
        public static readonly string LINK_MAILTO = "<a href=\"mailto:{0}\">{1}</a> ";
        public static readonly string COMMAS = "\"";
        public static readonly string DELETE = "~~";
        public static readonly string TILDE = "~";
        public static readonly string APEX = "^";
        public static readonly string MARKED = "==";
        public static readonly string MATH = "$$";
        public static readonly string IMG_FORMAT_NORESIZE = " ![{2}]({0} \"{1}\") ";
        public static readonly string IMG_FORMAT_WIDTH_HEIGHT = " <img src=\"{0}\" alt=\"{1}\" width=\"{3}\" height=\"{4}\"/> ";
        public static readonly string IMG_FORMAT_HEIGHT = " <img src=\"{0}\" alt=\"{1}\" height=\"{3}\"/> ";
        public static readonly string SET_CSS_NOT_EMBEDDED = " <style> @import url({0}); </style> ";
        public static readonly string SET_CSS_EMBEDDED = " <style type='text/css'>\n{0}\n</style>";
    }
}
