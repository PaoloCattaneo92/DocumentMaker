using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PaoloCattaneo.DocumentMaker
{
    /// <summary>
    /// Utility class that reads a Template from a well written YAML file.
    /// Check the official documentation to know how to write a good Template YAML file.
    /// </summary>
    public static class TemplateFromYaml
    {
        /// <summary>
        /// Read a Template from a YAML file.
        /// This use <see cref="CamelCaseNamingConvention"/>, you can personalize it
        /// using the overload <see cref="ReadFromYaml(string, IDeserializer)"/> instead.
        /// </summary>
        /// <param name="yamlFile">The path to the YAML file</param>
        /// <returns>The Template object deserialized</returns>
        public static Template ReadFromYaml(string yamlFile)
        {
            var deserializer = new DeserializerBuilder()
                                    //.WithNamingConvention(new CamelCaseNamingConvention())
                                    .Build();
            return ReadFromYaml(yamlFile, deserializer);
        }

        /// <summary>
        /// Read a Template from a YAML file with a custom <see cref="IDeserializer"/>
        /// </summary>
        /// <param name="yamlFile">The path to the YAML file</param>
        /// <param name="deserializer">Your deserializer</param>
        /// <returns>The Template object deserialized</returns>
        public static Template ReadFromYaml(string yamlFile, IDeserializer deserializer)
        {
            return deserializer.Deserialize<Template>(File.OpenText(yamlFile));
        }
    }
}
