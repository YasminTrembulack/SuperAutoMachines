namespace SuperAutoMachine;

class MTornoCNC : Machine
{
    public MTornoCNC(int attack = 5, int life = 3, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Torno";
        Tier = 4;
    }
    // public MTornoCNC() : base(5, 3, 1, 1)
    // {
    //     Name =  "Torno";
    //     Tier = 4;
    // }
}
