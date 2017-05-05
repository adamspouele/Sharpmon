using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Sharpmon
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();

            // Game Welcoming..
            myGame.Welcome();

            // Game Start..
            myGame.Start();

            // Choose first sharpmon..
            myGame.FirstSharpmon();

            // Game loop RUNNING..
            while (true)
            {
                myGame.Update();
            }

        }

    }
}
