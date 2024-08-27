using System.Security.Cryptography.X509Certificates;

namespace SuperAutoMachine;

class MRetificaPlana : Machine
{
    public MRetificaPlana(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Retífica Plana";
        Tier = 2;
    }
}
