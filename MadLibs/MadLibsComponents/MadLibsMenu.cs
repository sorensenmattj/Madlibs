using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MadLibs.MadLibsComponents
{
    public class MadLibsMenu
    {
        [JsonProperty("madlibs")]
        private List<MadLib> _MadLibs { get; set; }

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
        public MadLib GetMadLib()
        {
            var random = new Random();

            while (true)
            {
                Console.WriteLine("Choose a madlib:");

                for (int i = 0; i < _MadLibs.Count; i++)
                {
                    Console.WriteLine($"\t{i+1}) {_MadLibs[i].MadLibName}");
                }

                Console.WriteLine($"\t{_MadLibs.Count + 1}) Random");

                Console.Write("> ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (choice == _MadLibs.Count + 1)
                    {
                        Console.WriteLine();
                        return _MadLibs[random.Next(0, _MadLibs.Count)];
                    }
                    else if (choice >= 1 && choice <= _MadLibs.Count)
                    {
                        Console.WriteLine();
                        return _MadLibs[choice - 1];
                    }
                }
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
                _MadLibs = root.Madlibs;
            }
        }
    }
}
