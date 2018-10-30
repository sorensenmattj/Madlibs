using MadLibs.MadLibsComponents;

namespace MadLibs
{
    public class MadLibsGame
    {
        public void Play()
        {
            var madLibsMenu = new MadLibsMenu();
            var madLib = madLibsMenu.GetMadLib();
            madLib.GetUserAnswers();
            madLib.Print();
        }
    }
}
