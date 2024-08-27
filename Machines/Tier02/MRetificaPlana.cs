using System.Security.Cryptography.X509Certificates;

namespace SuperAutoMachine;

class MRetificaPlana : Machine
{
    public MRetificaPlana(int attack = 4, int life = 2, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Retífica Plana";
        Tier = 2;
    }
}
