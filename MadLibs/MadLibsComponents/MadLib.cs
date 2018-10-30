using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MadLibs.MadLibsComponents
{
    public class MadLib
    {
        [JsonProperty("name")]
        public string MadLibName { get; set; }

        [JsonProperty("text")]
        public List<string> MadLibText { get; set; }

        /// <summary>
        /// Ask the user for answers to all of the MadLib options.
        /// </summary>
        public void GetUserAnswers(TextWriter writer, TextReader reader)
        {
            var fullText = string.Join("\n", MadLibText.ToArray());
            var madLibOptionMatches = Regex.Matches(fullText, @"{(.+?)}");

            foreach (Match optionMatch in madLibOptionMatches)
            {
                writer.Write($"{optionMatch.Groups[1]}: ");
                var answer = reader.ReadLine();

                var regex = new Regex(@"{.+?}");
                fullText = regex.Replace(fullText, answer, 1);
            }

            writer.WriteLine();

            MadLibText = fullText.Split('\n').ToList();
        }

        /// <summary>
        /// Print the MadLib to the console window.
        /// </summary>
        public void Print(TextWriter writer)
        {
            MadLibText.ForEach(line => writer.WriteLine(line));
        }
    }
}
