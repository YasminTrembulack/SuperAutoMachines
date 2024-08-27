
namespace SuperAutoMachine;

class MRetificaCilindrica : Machine
{
    public MRetificaCilindrica(int attack = 2, int life = 6, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Retífica Cilíndrica";
        Tier = 3;
    }
}
