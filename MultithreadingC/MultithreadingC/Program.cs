using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        var game = new GameLoop();

        Console.WriteLine("Game loop started");
        game.Start();

        Console.ReadKey();
        game.Stop();

        Console.WriteLine("Game loop stopped");
    }
}