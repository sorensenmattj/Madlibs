using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MadLibs.MadLibsComponents
{
    public class MadLib
    {
        [JsonProperty("name")]
        public string MadLibName { get; set; }

        [JsonProperty("text")]
        private List<string> _MadLibText { get; set; }

        /// <summary>
        /// Ask the user for answers to all of the MadLib options.
        /// </summary>
        public void GetUserAnswers()
        {
            var fullText = string.Join("\n", _MadLibText.ToArray());
            var madLibOptionMatches = Regex.Matches(fullText, @"{(.+?)}");

            foreach (Match optionMatch in madLibOptionMatches)
            {
                Console.Write($"{optionMatch.Groups[1]}: ");
                var answer = Console.ReadLine();

                var regex = new Regex(@"{.+?}");
                fullText = regex.Replace(fullText, answer, 1);
            }

            Console.WriteLine();

            _MadLibText = fullText.Split('\n').ToList();
        }

        /// <summary>
        /// Print the MadLib to the console window.
        /// </summary>
        public void Print()
        {
            foreach (var line in _MadLibText)
            {
                Console.WriteLine(line);
            }
        }
    }
}
