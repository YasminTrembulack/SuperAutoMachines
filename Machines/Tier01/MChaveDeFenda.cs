using System;
using System.Drawing;
namespace SuperAutoMachine;

class MChaveDeFenda : Machine
{
    public MChaveDeFenda(int attack = 2, int life = 3, int experience = 1, int level = 1)
        : base(attack, life, experience, level )
    { 
        Tier = 1;
        Name = "Chave de Fenda";
        Image = "./images/chave_de_fenda.bmp";
    }

    public override MChaveDeFenda Clone()
    {
        return new MChaveDeFenda(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }

    public override void Sell() 
    {
        Random rand = new();
        Game.CurrentGame.Team[rand.Next(0, Game.CurrentGame.Team.Count-1)].Life++;
    }
}
