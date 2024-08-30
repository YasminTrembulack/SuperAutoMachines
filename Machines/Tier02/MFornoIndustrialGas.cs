
namespace SuperAutoMachine;

class MFornoIndustrialGas : Machine
{
    public MFornoIndustrialGas(int attack = 1, int life = 3, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Forno Industrial a Gás";
        Tier = 2;
    }
    public override void StartBuy()
    {
        Round round = Round.CurrentRound;
        round.Coins++;
    }

    public override MFornoIndustrialGas Clone()
    {
        return new MFornoIndustrialGas(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
}
