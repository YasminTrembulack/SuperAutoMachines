using System;

namespace SuperAutoMachine;

class MFuradeiraCordenada : Machine
{
    public MFuradeiraCordenada(int attack, int life, int experience, int level)
        : base(attack, life, experience, level)
    {
        Name =  "Furadeira de Coordenada";
        Tier = 3;
    }

    public override void Hurt()
    {
        Round round = Round.CurrentRound;
        Random rand = new Random();
        int index = rand.Next(0, round.Enemy.Count-1);
        round.Enemy[index].Life--;
    }
}
