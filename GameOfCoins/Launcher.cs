using GameOfCoins.model;
using System;


namespace GameOfCoins
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Game g = new Game(100000,42);
            Console.Write("RESULT "+g.Result());
            Console.ReadKey();
        }
    }
}
