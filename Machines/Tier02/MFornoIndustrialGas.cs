using System.Security.Cryptography.X509Certificates;

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
}
