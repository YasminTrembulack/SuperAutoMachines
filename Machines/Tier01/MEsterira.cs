namespace SuperAutoMachine;

class MEsteira : Machine
{
    public MEsteira(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Esteira";
        Tier = 1;
    }

    public override void Sell()
    {
        Round round = Round.CurrentRound;
        round.Coins++;
    }
}
