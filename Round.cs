using System.Collections.Generic;
using System.Linq;


namespace SuperAutoMachine;
class Round
{
    public int Coins { get; set; }

    public List<Machine> Store { get; set; }
    public List<Machine> Enemy { get; set; }
    public static Round? currentRound = null;

    // FIGHT
    private Stack<Machine> team = new();
    public Machine[] saveTeam;
    private Stack<Machine> enemy = new();
    private Game game = Game.CurrentGame;
    public static Round CurrentRound
    {
        get
        {
            if (currentRound == null)
            {
                currentRound = new Round();
                AddStore(RandomMachine.GetMachines(3));
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




    public void StartFight()
    {
        foreach (var e in CurrentRound.Enemy)
            enemy.Push(e);
        foreach (var e in game.Team)
            team.Push(e);

        game.Team.CopyTo(saveTeam);// AQUI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }

    public int FightStep()
    {
        if (team.TryPop(out var mach_t) && enemy.TryPop(out var mach_e))
        {
            mach_t.Life -= mach_e.Attack;
            mach_e.Life -= mach_t.Attack;
            
            mach_e.Hurt();
            mach_t.Hurt();
           
            if (mach_e.Life > 0)
                enemy.Push(mach_e); 
            else
                CurrentRound.Enemy.RemoveAt(CurrentRound.Enemy.Count-1);
            
            
            if (mach_t.Life > 0)
                team.Push(mach_t); 
            else
                game.Team.RemoveAt(game.Team.Count-1);

        }
        if (team.Count > 0 && enemy.Count == 0)
        {
            game.Trophies++;
            
            saveTeam.ToList().CopyTo(game.Team); // AQUI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return 1; // Team wins
        }
        else if (team.Count == 0 && enemy.Count > 0)
        {
            game.Life--;
            game.Team = saveTeam;// AQUI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return -1; // Enemy wins
        }
        else if (team.Count == 0 && enemy.Count == 0)
        {
            game.Team = saveTeam;// AQUI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            return 2; // Draw
        }
        return 0; // Incomplete fight
        
    }


}
