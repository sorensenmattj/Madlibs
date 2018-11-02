using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MadLibs.MadLibsComponents;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void KeepProvidedAnswers()
        {
            var madLibsMenu = new MadLibsMenu();

            var madLib = madLibsMenu.GetMadLib(Console.Out, new StringReader("1"));
        }
    }
}
