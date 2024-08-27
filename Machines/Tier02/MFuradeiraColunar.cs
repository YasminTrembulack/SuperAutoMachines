namespace SuperAutoMachine;

class MFuradeiraColunar : Machine
{
    public MFuradeiraColunar(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Furadeira de Coluna";
        Tier = 2;
    }
}
