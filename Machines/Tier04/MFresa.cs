
namespace SuperAutoMachine;

class MFresa : Machine
{
    public MFresa(int attack = 4, int life = 5, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Fresa";
        Tier = 4;
    }
    // public MFresa() : base(4, 5, 1, 1)
    // {
    //     Name =  "Fresa";
    //     Tier = 4;
    // }
}
