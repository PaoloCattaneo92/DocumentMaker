using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    public class RenderedObj : IRenderable
    {
        public string Render()
        {
            return Render(new StringBuilder()).ToString();
        }

        public virtual StringBuilder Render(StringBuilder sb)
        {
            return sb;
        }
    }
}
