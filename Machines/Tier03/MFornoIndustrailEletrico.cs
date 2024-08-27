namespace SuperAutoMachine;

class MFornoIndustrailEletrico : Machine
{
    public MFornoIndustrailEletrico(int attack = 4, int life = 3, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name = "Forno Industrial Elétrico";
        Tier = 3;
    }
}
