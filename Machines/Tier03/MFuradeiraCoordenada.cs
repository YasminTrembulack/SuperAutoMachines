using System;

namespace SuperAutoMachine;

class MFuradeiraCoordenada : Machine
{
    public MFuradeiraCoordenada(int attack = 3, int life = 5, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Furadeira de Coordenada";
        Tier = 3;
    }

    public override void Hurt()
    {
        if (Life <=0)
            return;
        Round round = Round.CurrentRound;
        Random rand = new Random();
        int index = rand.Next(0, round.Enemy.Count);
        round.Enemy[index].Life--;
    }

       public override MFuradeiraCoordenada Clone()
    {
        return new MFuradeiraCoordenada(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
}
