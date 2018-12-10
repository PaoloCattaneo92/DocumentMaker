using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class represents a Template text.
    /// A template is a text with some parts with "[" and "]"  that can be
    /// filled leading to different Results.
    /// Every Result is made of <see cref="TemplateItem"/>s.
    /// </summary>
    public class Template : RenderedObj
    {
        /// <summary>
        /// Main text of the template
        /// </summary>
        /// <example>
        /// This is the template of [name], a [job]
        /// </example>
        public string BaseText { get; set; }
        /// <summary>
        /// This string indicates the start of a template value.
        /// You can change it from "[" if you need this symbol for some reasons.
        /// </summary>
        public string OpenTemplateSign { get; set; } = "$_";
        /// <summary>
        /// This string indicates the end of a template value.
        /// You can change it from "]" if you need this symbol for some reasons.
        /// </summary>
        public string CloseTemplateSign { get; set; } = "_$";
        /// <summary>
        /// List of <see cref="Result"/>
        /// </summary>
        public List<Result> Results { get; set; }

        /// <summary>
        /// The current <see cref="TemplateRenderMode"/> set.
        /// If <see cref="TemplateRenderMode.SINGLE"/> is set only the <see cref="ResultSingleID"/> result will be rendered.
        /// If <see cref="TemplateRenderMode.ALL"/> is set all the results will be rendered.
        /// </summary>
        public TemplateRenderMode RenderMode { get; set; } =  TemplateRenderMode.SINGLE;

        /// <summary>
        /// The current RenderIndex set. If <see cref="RenderMode"/> is set on <see cref="TemplateRenderMode.SINGLE"/>
        /// only this result will be rendered.
        /// </summary>
        public string ResultSingleID { get; set; } = null;

        /// <summary>
        /// Add a new result to the list.
        /// If a result with the same <see cref="Result.IdResult"/>
        /// already exists, nothing will happen.
        /// </summary>
        public void AddResult(Result result)
        {
            if(!Results.Where(x => x.IdResult == result.IdResult).Any())
            {
                Results.Add(result);
            }
        }

        public void AddResult(string idResult)
        {
            AddResult(new Result(idResult));
        }

        /// <summary>
        /// Add a TemplateItem to the Result of index.
        /// </summary>
        /// <param name="index">Index of the result</param>
        /// <param name="ti">The templateitem that will be added</param>
        public void AddTemplateItem(string idResult, TemplateItem ti)
        {
            Results.First(x => x.IdResult == idResult).AddTemplateItem(ti);
        }
        /// <summary>
        /// Add a TemplateItem to the Result of index.
        /// </summary>
        /// <param name="idResult">Index of the result</param>
        /// <param name="key">Key of the templateitem that will be added</param>
        /// <param name="val">Value of the templateitem that will be added</param>
        public void AddTemplateItem(string idResult, string key, string val)
        {
            AddTemplateItem(idResult, new TemplateItem(key, val));
        }
        /// <summary>
        /// Add a TemplateItem to the LAST Result of the list.
        /// This will not add a new Result.
        /// </summary>
        /// <param name="ti">A new TemplateItem</param>
        public void AddTemplateItem(TemplateItem ti)
        {
            Results[Results.Count - 1].AddTemplateItem(ti);
        }
        /// <summary>
        /// Add a TemplateItem to the LAST Result of the list.
        /// This will not add a new Result.
        /// </summary>
        /// <param name="ti">A new TemplateItem</param>
        public void AddTemplateItem(string key, string val)
        {
            Results[Results.Count - 1].AddTemplateItem(new TemplateItem(key, val));
        }

        /// <summary>
        /// Initialize the base text of the Template with the given string
        /// </summary>
        /// <param name="baseText">Text of the template</param>
        public Template(string baseText) : this()
        {
            BaseText = baseText;
        }
        /// <summary>
        /// Initialize the base text of the template
        /// with the text read froma  file
        /// </summary>
        /// <param name="file">Name of the file containing the base
        /// text for this template</param>
        public Template(FileInfo file) : this()
        {
            BaseText = File.ReadAllText(file.FullName);
        }
        /// <summary>
        /// Initialize the Template without text
        /// </summary>
        /// <remarks>Assign a <see cref="BaseText"/> before render this</remarks>
        public Template()
        {
            Results = new List<Result>();
        }
        /// <summary>
        /// Initialize the Template copying the base text from another Template
        /// </summary>
        /// <param name="template">Another template</param>
        public Template(Template template) : this(template.BaseText)
        {
        }
        /// <summary>
        /// Append the rendered content of this <see cref="RenderedObj"/>
        /// to the given StringBuilder.
        /// </summary>
        /// <param name="sb">The StringBuilder where the rendered content will be appended</param>
        /// <returns>The same StringBuilder but with this content appendend</returns>
        public override StringBuilder Render(StringBuilder sb)
        {
            string tempText = BaseText;
            if (RenderMode == TemplateRenderMode.ALL)
            {
                foreach (Result result in Results)
                {
                    string buff = tempText;
                    foreach (TemplateItem item in result.TemplateItems)
                    {
                        buff = buff.Replace(OpenTemplateSign + item.Key + CloseTemplateSign, item.Val);
                    }
                    sb.Append(buff).Append("\n\n");
                }
            }
            else
            {
                if (Results?.Count == 0 || ResultSingleID == null) return sb;
                sb.Append("\n");
                string buff = tempText;
                foreach (TemplateItem item in
                            Results.First(x => x.IdResult == ResultSingleID).TemplateItems)
                {
                    buff = buff.Replace(OpenTemplateSign + item.Key + CloseTemplateSign, item.Val);
                }
                sb.Append(buff);
            }
            return sb;
        }
    }
}
