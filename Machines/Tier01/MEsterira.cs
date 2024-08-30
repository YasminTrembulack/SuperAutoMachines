using System.Drawing;

namespace SuperAutoMachine;

class MEsteira : Machine
{
    public MEsteira(int attack = 3, int life = 1, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    { 
        Tier =  1;
        Name = "Esteira";
        Image = "./images/esteira.bmp";
    }

    public override void Sell()
    {
        Round round = Round.CurrentRound;
        round.Coins++;
    }

    public override MEsteira Clone()
    {
        return new MEsteira(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
}
