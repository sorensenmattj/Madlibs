using MadLibs.MadLibsComponents;
using System;

namespace MadLibs
{
    public class MadLibsGame
    {
        public void Play()
        {
            var madLibsMenu = new MadLibsMenu();
            MadLib madLib = null;

            while (madLib == null)
            {
                madLib = madLibsMenu.GetMadLib(Console.Out, Console.In);
            }

            madLib.GetUserAnswers(Console.Out, Console.In);
            madLib.Print(Console.Out);
        }
    }
}
