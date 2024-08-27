using System.Collections.Generic;

namespace SuperAutoMachine;
class Round
{
    public int Coins { get; set; }

    public List<Machine> Store { get; set; }
    public List<Machine> Enemy { get; set; }
    public static Round? currentRound = null;
    public static Round CurrentRound
    {
        get
        {
            currentRound ??= new Round();
            return currentRound;
        }
    }

    public Round()
    {
        Coins = 10;
        Store = new List<Machine>(3);
    }

    public static void Purchase(int indexMachine)
    {
        if (indexMachine < 0 || indexMachine > 2)
            return;
        Game game = Game.CurrentGame;

        game.Team.Add(CurrentRound.Store[indexMachine]); 
        CurrentRound.Coins--;     
    }

    public static void Fight()
    {


    }

    // public static List<Machine> RandomTeam()
    // {

    // }


}

// No round 3 caso tenha perdido vida aumenta 1 de vida
