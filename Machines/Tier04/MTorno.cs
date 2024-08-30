using System.Collections.Generic;
namespace SuperAutoMachine;

class MTorno : Machine
{
    public MTorno(int attack = 5, int life = 3, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Torno";
        Tier = 4;
    }
    public override MTorno Clone()
    {
        return new MTorno(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }

    public override void EndBuy()
    {
        Game game = Game.CurrentGame;
        List<Machine> team = game.Team;

        foreach (var item in team)
        {
            if(item.Level == 3)
            {
                
                Attack += 2;
                Life += 2;
                return;
            }
        }
    }
}
