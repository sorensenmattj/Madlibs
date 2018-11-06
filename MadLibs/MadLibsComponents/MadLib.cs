using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MadLibs.MadLibsComponents
{
    public class MadLib
    {
        [JsonProperty("name")]
        public string MadLibName { get; private set; }

        [JsonProperty("text")]
        private List<string> MadLibText { get; set; }

        /// <summary>
        /// Ask the user for answers to all of the MadLib options.
        /// </summary>
        public void GetUserAnswers(TextWriter writer, TextReader reader)
        {
            var fullText = string.Join("\n", MadLibText.ToArray());

            var regex = new Regex(@"{(.+?)}");
            var madLibOptionMatches = regex.Matches(fullText);

            using (writer)
            using (reader)
            {
                foreach (Match optionMatch in madLibOptionMatches)
                {
                    writer.Write($"{optionMatch.Groups[1]}: ");
                    var answer = reader.ReadLine();

                    fullText = regex.Replace(fullText, answer, 1);
                }

                writer.WriteLine();
            }

            MadLibText = fullText.Split('\n').ToList();
        }

        /// <summary>
        /// Print the MadLib to the console window.
        /// </summary>
        public void Print(TextWriter writer)
        {
            using (writer)
            {
                MadLibText.ForEach(line => writer.WriteLine(line));
            }
        }
    }
}
