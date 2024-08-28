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
        Coins = 11;
        Store = new List<Machine>(3);
        Enemy = new List<Machine>(5);
    }

    public static Round newRound()
    {
        currentRound = new Round();
        return currentRound;
    }

    public static void Purchase(int indexMachine)
    {
        if (indexMachine < 0 || indexMachine > 2)
            return;
        Game game = Game.CurrentGame;
        
        if(game.Team.Count == 5)
            return;

        game.Team.Add(CurrentRound.Store[indexMachine]); 
        CurrentRound.Coins--;     
        CurrentRound.Store.RemoveRange(indexMachine, 1);
    }

    public static void AddStore(List<Machine> machines)
    {
        CurrentRound.Store.Clear();
        CurrentRound.Store = machines;  
    }




    public static void Fight()
    {
        
    }

    // public static List<Machine> RandomTeam()
    // {

    // }


}

// No round 3 caso tenha perdido vida aumenta 1 de vida
