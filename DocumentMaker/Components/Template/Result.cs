using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// This class represents a Result of a Template.
    /// A Template in facts can be rendered with different combinations of key/valus of <see cref="TemplateItem"/>,
    /// giving birth to different Results.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// An ID for the Result
        /// </summary>
        /// <remarks>
        /// This is mandatory when parsed from YAML.
        /// </remarks>
        public string IdResult { get; set; }
        /// <summary>
        /// List of the TemplateItems of this particular
        /// Result
        /// </summary>
        public List<TemplateItem> TemplateItems { get; set; }

        public Result(string idResult, List<TemplateItem> templateItems)
        {
            IdResult = idResult;
            TemplateItems = templateItems;
        }

        public Result(string idResult) : this(idResult, new List<TemplateItem>())
        {
        }

        public Result() : this("")
        {
        }
        /// <summary>
        /// Add this TemplateItem to this Result
        /// </summary>
        /// <param name="templateItem">A TempalteItem</param>
        public void AddTemplateItem(TemplateItem templateItem)
        {
            TemplateItems.Add(templateItem);
        }

        public void AddTemplateItem(string key, string val)
        {
            AddTemplateItem(new TemplateItem(key, val));
        }
    }
}
