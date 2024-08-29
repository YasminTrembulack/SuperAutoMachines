using System.Drawing;
namespace SuperAutoMachine;

class MChaveDeFenda : Machine
{
    public MChaveDeFenda(int attack = 2, int life = 3, int experience = 1, int level = 1)
        : base(attack, life, experience, level )
    { 
        Tier = 1;
        Name = "Chave de Fenda";
    }
}
