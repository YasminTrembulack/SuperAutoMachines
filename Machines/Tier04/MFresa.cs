
namespace SuperAutoMachine;

class MFresa : Machine
{
    public MFresa(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Fresa";
        Tier = 4;
    }
    public MFresa() : base(4, 5, 1, 1)
    {
        Name =  "Fresa";
        Tier = 4;
    }
}
