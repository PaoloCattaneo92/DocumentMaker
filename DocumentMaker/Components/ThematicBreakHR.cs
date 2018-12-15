using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This will be rendered as the HTML "<hr>" tag
    /// </summary>
    public class ThematicBreakHR : RenderedObj
    {
        public override StringBuilder Render(StringBuilder sb)
        {
            return sb.Append(DocumentMakerConstants.DOUBLE_NEW_LINE).Append(DocumentMakerConstants.HR).Append(DocumentMakerConstants.DOUBLE_NEW_LINE);
        }
    }
}
