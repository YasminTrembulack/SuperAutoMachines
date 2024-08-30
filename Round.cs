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
                AddStore(RandomMachine.GetMachines(3));
                Game.CurrentGame.round++;
            }
            return currentRound;
        }
    }

    // FIGHT
    public List<Machine> SaveTeam { get; set; }
    private Stack<Machine> FTeam = new();
    private Stack<Machine> FEnemy = new();
    private Game game = Game.CurrentGame;

    public Round()
    {
        Coins = 10;
        Store = new List<Machine>(3);
        Enemy = new List<Machine>(5);
        SaveTeam = new List<Machine>(5);
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
        // foreach (var e in CurrentRound.Enemy)
        //     FEnemy.Push(e);
        // foreach (var e in game.Team)
        //     FTeam.Push(e);

        // Machine[] list = new Machine[Game.CurrentGame.Team.Count];
        // Game.CurrentGame.Team.CopyTo(list);
        // SaveTeam = [.. list];

        Machine[] temp = new Machine[Game.CurrentGame.Team.Count];
        Game.CurrentGame.Team.CopyTo(temp);
        SaveTeam = [.. temp];
        foreach (var m in temp)
            FTeam.Push(m.Clone());

        temp = new Machine[CurrentRound.Enemy.Count];
        CurrentRound.Enemy.CopyTo(temp);
        foreach (var e in temp)
            FEnemy.Push(e.Clone());
    }

    public int FightStep()
    {
        if (FTeam.TryPop(out var mach_t) && FEnemy.TryPop(out var mach_e))
        {
            mach_t.Life -= mach_e.Attack;
            mach_e.Life -= mach_t.Attack;
            
            mach_e.Hurt();
            mach_t.Hurt();
           
            if (mach_e.Life > 0)
                FEnemy.Push(mach_e); 
            else
                CurrentRound.Enemy.RemoveAt(CurrentRound.Enemy.Count-1);
            
            
            if (mach_t.Life > 0)
                FTeam.Push(mach_t); 
            else
                CurrentRound.SaveTeam.RemoveAt(CurrentRound.SaveTeam.Count-1);

        }
        if (FTeam.Count > 0 && FEnemy.Count == 0)
        {
            game.Trophies++;
            return 1; // Team wins
        }
        else if (FTeam.Count == 0 && FEnemy.Count > 0)
        {
            game.Life--;
            return -1; // Enemy wins
        }
        else if (FTeam.Count == 0 && FEnemy.Count == 0)
        {
            return 2; // Draw
        }
        return 0; // Incomplete fight
        
    }


}
