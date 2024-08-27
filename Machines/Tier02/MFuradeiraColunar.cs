namespace SuperAutoMachine;

class MFuradeiraColunar : Machine
{
    public MFuradeiraColunar(int attack = 3, int life = 5, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Furadeira de Coluna";
        Tier = 2;
    }
}
