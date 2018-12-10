using System;
using System.Collections.Generic;
using System.Text;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// Render mode for the template
    /// </summary>
    public enum TemplateRenderMode
    {
        /// <summary>
        /// If <see cref="TemplateRenderMode.SINGLE"/> is set the Template will be rendered
        /// only with the Result pointed by <see cref="Template.ResultSingleID"/>
        /// </summary>
        SINGLE,
        /// <summary>
        /// If <see cref="TemplateRenderMode.ALL"/> is set the Template will render
        /// all the results
        /// </summary>
        ALL
    }
}
