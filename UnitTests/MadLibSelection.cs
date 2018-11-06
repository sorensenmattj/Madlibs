using MadLibs.MadLibsComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class MadLibSelection
    {
        [TestMethod]
        public void SelectMadlib()
        {
            var madLibsMenu = new MadLibsMenu();

            for (int i = 0; i < madLibsMenu.MadLibs.Count; i++)
            {
                var madLib = madLibsMenu.GetMadLib(Console.Out, new StringReader($"{i+1}"));

                Assert.AreEqual(
                    madLibsMenu.MadLibs[i].MadLibName,
                    madLib.MadLibName,
                    "Selected Madlib name does not match expected name.");
            }
        }

        [TestMethod]
        public void SelectRandomMadlib()
        {
            var madLibsMenu = new MadLibsMenu();
            var madLib = madLibsMenu.GetMadLib(
                            Console.Out,
                            new StringReader($"{madLibsMenu.MadLibs.Count + 1}"));

            Assert.IsNotNull(madLib, "No Madlib returned.");
        }

        [TestMethod]
        public void ProvideLetterForIndex()
        {
            var madLibsMenu = new MadLibsMenu();
            var madLib = madLibsMenu.GetMadLib(Console.Out, new StringReader("a"));

            Assert.IsNull(madLib, "Madlib was selected when none should have been selected.");
        }

        [TestMethod]
        public void ProvideTooLargeIndex()
        {
            var madLibsMenu = new MadLibsMenu();
            var madLib = madLibsMenu.GetMadLib(
                            Console.Out,
                            new StringReader($"{madLibsMenu.MadLibs.Count + 2}"));

            Assert.IsNull(madLib, "Madlib was selected when none should have been selected.");
        }

        [TestMethod]
        public void ProvideNegativeIndex()
        {
            var madLibsMenu = new MadLibsMenu();
            var madLib = madLibsMenu.GetMadLib(Console.Out, new StringReader("-1"));

            Assert.IsNull(madLib, "Madlib was selected when none should have been selected.");
        }
    }
}
