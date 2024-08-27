using System.Security.Cryptography.X509Certificates;

namespace SuperAutoMachine;

class MFornoIndustrialGas : Machine
{
    public MFornoIndustrialGas(int attack, int life, int experience, int level)
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
}
