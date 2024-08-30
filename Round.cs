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
                if(Game.CurrentGame.round == 3 && Game.CurrentGame.Life < 5) Game.CurrentGame.Life++;
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
        for (int i = 0; i < game.Team.Count; i++)
        {
            SaveTeam.Add(game.Team[i].Clone());
            FTeam.Push(SaveTeam[i]);
        }
        
        foreach (var e in CurrentRound.Enemy)
            FEnemy.Push(e.Clone());
    }

    public static void SellMachine(int index)
    {
        Game.CurrentGame.Team[index].Sell();
        CurrentRound.Coins += Game.CurrentGame.Team[index].Level;
        Game.CurrentGame.Team.RemoveAt(index);
    }

    public static void Merge(int indexA, int indexB)
    {
        List<Machine> team = Game.CurrentGame.Team;

        if(team[indexA].Level == 3 || team[indexA].Level == 3 )
            return;
        Machine newMach = team[indexA].Clone();
        newMach.Attack = team[indexA].Attack > team[indexB].Attack ? team[indexA].Attack + 1: team[indexB].Attack + 1;
        newMach.Life = team[indexA].Life > team[indexB].Life ? team[indexA].Life + 1: team[indexB].Life + 1;
        newMach.Experience = team[indexA].Experience + team[indexB].Experience;
        newMach.Level = newMach.Experience >= 6 ? newMach.Level = 3: newMach.Experience >= 3 ? newMach.Level = 2 : newMach.Level;

        team.Add(newMach);
        team.RemoveAt(indexA);
        team.RemoveAt(indexB);
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
            else{
                mach_e.Death();
                CurrentRound.Enemy.RemoveAt(CurrentRound.Enemy.Count-1);
            }
            
            
            if (mach_t.Life > 0)
                FTeam.Push(mach_t); 
            else{
                mach_t.Death();
                CurrentRound.SaveTeam.RemoveAt(CurrentRound.SaveTeam.Count-1);
            }
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
