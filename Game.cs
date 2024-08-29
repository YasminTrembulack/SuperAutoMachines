using System.Collections.Generic;

namespace SuperAutoMachine;

class Game
{
    public int Life { get; set; }
    public int Trophies { get; set; }
    public List<Machine> Team { get; set; }

    public int round { get; set; } = 0;

    private static Game? currentGame = null;
    public static Game CurrentGame
    {
        get
        {
            currentGame ??= new Game();
            return currentGame;
        }
    }

    public Game()
    {
        Team = new List<Machine>(5);
        Life = 5;
        Trophies = 0;
    }
}