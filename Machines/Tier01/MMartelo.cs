using System.Drawing;

namespace SuperAutoMachine
{
    class MMartelo : Machine
    {
        public MMartelo(int attack = 2, int life = 3, int experience = 1, int level = 1)
            : base(attack, life, experience, level )
        { 
            Tier = 1;
            Name = "Martelo";
            Image = "./images/martelo.bmp";
        }
        public override MMartelo Clone()
        {
            return new MMartelo(this.Attack, this.Life, this.Experience, this.Level)
            {
                Name = this.Name,
                Tier = this.Tier,
                Image = this.Image
            };
        }
    }
}