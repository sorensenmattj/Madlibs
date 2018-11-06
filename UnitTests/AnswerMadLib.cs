using MadLibs.MadLibsComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class AnswerMadLib
    {
        [TestMethod]
        public void GiveAnswersToMadLib()
        {
            var madLibsMenu = new MadLibsMenu();
            var madLib = madLibsMenu.GetMadLib(Console.Out, new StringReader("1"));

            var answersBuilder = new StringBuilder();

            for (int i = 1; i < 50; i++)
            {
                answersBuilder.Append($"{i}\n");
            }

            var answers = answersBuilder.ToString();
            madLib.GetUserAnswers(Console.Out, new StringReader(answers));
            madLib.Print(Console.Out);
        }
    }
}
