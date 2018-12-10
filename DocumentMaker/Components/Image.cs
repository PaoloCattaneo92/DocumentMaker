using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    public class Image : RenderedObj
    {
        public static readonly int NO_RESIZE_VALUE = -1;
        /// <summary>
        /// Source link for the image
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        ///  Text that will be shown on over
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Alternative text (while the image is loading)
        /// </summary>
        public string AlternativeText { get; set; }
        /// <summary>
        /// Width of the pic
        /// </summary>
        /// <remarks>-1 is default value to ignore this parameter</remarks>
        public int Width { get; set; } = -1;
        /// <summary>
        /// Height of the pic
        /// </summary>
        /// <remarks>-1 is default value to ignore this parameter</remarks>
        public int Height { get; set; } = -1;

        /// <summary>
        /// Constructor for the Image MarkDown link
        /// </summary>
        /// <param name="src">Source link for the image</param>
        /// <param name="title">Text that will be shown on over</param>
        /// <param name="alternativeText">Alternative text (while the image is loading)</param>
        public Image(string src, string title, string alternativeText) : this(src, title, alternativeText, NO_RESIZE_VALUE, NO_RESIZE_VALUE)
        {
        }

        public Image(string src, string title, string alternativeText, int height) : this(src, title, alternativeText, NO_RESIZE_VALUE, height)
        {
        }

        public Image (string src, string title, string alternativeText, int width, int height)
        {
            Src = src;
            Title = title;
            AlternativeText = alternativeText;
            Width = width;
            Height = height;
        }

        

        /// <summary>
        /// Constructor for the Image MarkDown link.
        /// <see cref="AlternativeText"/> is set as empty string.
        /// </summary>
        /// <param name="src">Source link for the image</param>
        /// <param name="hoverDescription">Text that will be shown on over</param>
        public Image(string src, string hoverDescription) : this(src, hoverDescription, "")
        {
        }
        /// <summary>
        /// Constructor for the Image MarkDown link.
        /// <see cref="AlternativeText"/> is set as empty string.
        /// <see cref="Title"/> is set as empty string.
        /// </summary>
        /// <param name="src">Source link for the image</param>
        public Image(string src) : this(src, "", "")
        {
        }

        public override StringBuilder Render(StringBuilder sb)
        {
            string img;
            if (Height != NO_RESIZE_VALUE)
            {
                if (Width != NO_RESIZE_VALUE)
                {
                    img = string.Format(DocumentMakerConstants.IMG_FORMAT_WIDTH_HEIGHT, Src, Title, AlternativeText, Width, Height);
                }
                else
                {
                    img = string.Format(DocumentMakerConstants.IMG_FORMAT_WIDTH_HEIGHT, Src, Title, AlternativeText, Height);
                }
            }
            else
            {
                img = string.Format(DocumentMakerConstants.IMG_FORMAT_NORESIZE, Src, Title, AlternativeText);
            }
            sb.Append(img);
            return sb;
        }
    }
}
