namespace SuperAutoMachine;

class MTornoCNC : Machine
{
    public MTornoCNC(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Torno";
        Tier = 4;
    }
    public MTornoCNC() : base(5, 3, 1, 1)
    {
        Name =  "Torno";
        Tier = 4;
    }
}
