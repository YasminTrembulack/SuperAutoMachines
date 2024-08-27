
namespace SuperAutoMachine;

class MFresaCNC : Machine
{
    public MFresaCNC(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Fresa CNC";
        Tier = 4;
    }
    public MFresaCNC() : base(4, 5, 1, 1)
    {
        Name =  "Fresa CNC";
        Tier = 4;
    }
}
