
namespace SuperAutoMachine;

class MRetificaCilindrica : Machine
{
    public MRetificaCilindrica(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Retífica Cilíndrica";
        Tier = 3;
    }
}
