using System;

namespace SuperAutoMachine
{
    class MFuradeira : Machine
    {
        public MFuradeira(int attack = 2, int life = 1, int experience = 1, int level = 1)
            : base(attack, life, experience, level )
        { 
            Tier = 1;
            Name = "Furadeira";
        }
        public override MFuradeira Clone()
        {
            return new MFuradeira(this.Attack, this.Life, this.Experience, this.Level)
            {
                Name = this.Name,
                Tier = this.Tier,
                Image = this.Image
            };
        }

        public override void Death() 
        {
            Random rand = new();
            Game.CurrentGame.Team[rand.Next(0, Game.CurrentGame.Team.Count-1)].Life++;
            Game.CurrentGame.Team[rand.Next(0, Game.CurrentGame.Team.Count-1)].Attack += 2;

        }
    }
}