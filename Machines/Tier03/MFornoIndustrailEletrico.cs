namespace SuperAutoMachine;

class MFornoIndustrailEletrico : Machine
{
    public MFornoIndustrailEletrico(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name = "Forno Industrial Elétrico";
        Tier = 3;
    }
}
