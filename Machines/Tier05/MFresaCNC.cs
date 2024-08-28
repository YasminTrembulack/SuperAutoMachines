
namespace SuperAutoMachine;

class MFresaCNC : Machine
{
    public MFresaCNC(int attack = 4, int life = 5, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Fresa CNC";
        Tier = 5;
    }
    // public MFresaCNC() : base(4, 5, 1, 1)
    // {
    //     Name =  "Fresa CNC";
    //     Tier = 4;
    // }
}
