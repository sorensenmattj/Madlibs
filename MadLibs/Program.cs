using System;

namespace MadLibs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var madLibsGame = new MadLibsGame();
            madLibsGame.Play();

            Console.Read();
        }
    }
}
