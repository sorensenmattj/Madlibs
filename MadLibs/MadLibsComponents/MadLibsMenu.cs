using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MadLibs.MadLibsComponents
{
    public class MadLibsMenu
    {
        [JsonProperty("madlibs")]
        public List<MadLib> MadLibs { get; set; }

        /// <summary>
        /// Initalise a new instance of the <see cref="MadLibsMenu"/> class with the specified options.
        /// </summary>
        public MadLibsMenu()
        {
            LoadMadLibs();
        }

        /// <summary>
        /// Ask the user to choose a MadLib to play.
        /// </summary>
        /// <returns>The Madlib object for the MadLib the user chose.</returns>
        public MadLib GetMadLib(TextWriter writer, TextReader reader)
        {
            var random = new Random();

            writer.WriteLine("Choose a madlib:");

            for (int i = 0; i < MadLibs.Count; i++)
            {
                writer.WriteLine($"\t{i+1}) {MadLibs[i].MadLibName}");
            }

            writer.WriteLine($"\t{MadLibs.Count + 1}) Random");

            writer.Write("> ");
            var input = reader.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                if (choice == MadLibs.Count + 1)
                {
                    writer.WriteLine();
                    return MadLibs[random.Next(0, MadLibs.Count)];
                }
                else if (choice >= 1 && choice <= MadLibs.Count)
                {
                    writer.WriteLine();
                    return MadLibs[choice - 1];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Load saved madlibs for use later.
        /// </summary>
        private void LoadMadLibs()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\Matt Sorensen\source\repos\MadLibs\MadLibs\MadLibsComponents\madlibs.json"))
            {
                string json = reader.ReadToEnd();
                var root = JsonConvert.DeserializeObject<RootJsonObject>(json);
                MadLibs = root.Madlibs;
            }
        }
    }
}
