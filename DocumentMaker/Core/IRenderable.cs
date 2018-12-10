using System;
using System.Collections.Generic;
using System.Text;
using PaoloCattaneo.DocumentMaker;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// A IRenderable object must implement the render method
    /// that render its content into a MD string
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Render this into a valid MD text
        /// </summary>
        /// <returns>A valid MD string with the content rendered</returns>
        string Render();
        /// <summary>
        /// Append the content of this elemnt to the given StringBuilder
        /// </summary>
        /// <param name="sb">The StringBuilder that will receive the appended content</param>
        /// <returns>The StringBuilder with the content of this element appended</returns>
        StringBuilder Render(StringBuilder sb);
    }
}

