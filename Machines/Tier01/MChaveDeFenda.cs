namespace SuperAutoMachine;

class MChaveDeFenda : Machine
{
    public MChaveDeFenda(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Chave de Fenda";
        Tier = 1;
    }
}
