using System.Collections.Generic;
using System.Linq;


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
            if (currentRound == null)
            {
                currentRound = new Round();
                Game.CurrentGame.round++;
            }
            return currentRound;
        }
    }

    public Round()
    {
        Coins = 10;
        Store = new List<Machine>(3);
        Enemy = new List<Machine>(5);
    }

    public static void newRound()
    {
        currentRound = null;
    }

    public static void Purchase(int indexMachine)
    {
        Game game = Game.CurrentGame;

        if (indexMachine < 0 || indexMachine > 2 || game.Team.Count == 5 || CurrentRound.Coins < 3)
            return;

        game.Team.Add(CurrentRound.Store[indexMachine]); 
        CurrentRound.Store.RemoveRange(indexMachine, 1);
        CurrentRound.Coins -= 3;     
    }

    public static void AddStore(List<Machine> machines)
    {
        CurrentRound.Store.Clear();
        CurrentRound.Store = machines;  
    }




    public static void Fight()
    {
        // Machine[] copyTeam = new Machine[5];
        // Game.CurrentGame.Team.CopyTo(copyTeam);

        // int team_player = 0;
        // int enemy_player = 0;
        // while (true)
        // {
        //     var mach_t = copyTeam[team_player];
        //     var mach_e = copyTeam[enemy_player];
            
        //     if (true)
        //     {
                
        //     }


            
        // }



        
    }

    // public static List<Machine> RandomTeam()
    // {

    // }


}

// No round 3 caso tenha perdido vida aumenta 1 de vida
