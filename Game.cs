using System.Collections.Generic;

namespace SuperAutoMachine;

class Game
{
    public int Life { get; set; }
    public int Trophies { get; set; }
    public List<Machine> Team { get; set; }
    private static Game? currentGame = null;
    public static Game CurrentGame
    {
        get
        {
            currentGame ??= new Game();
            return currentGame;
        }
    }

    public Round round = Round.CurrentRound;

    public Game()
    {
        Team = new List<Machine>(5);
        Life = 5;
        Trophies = 0;
    }

    public void nextPlay(Machine machine)
    {
        
    }


}