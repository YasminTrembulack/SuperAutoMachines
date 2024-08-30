
namespace SuperAutoMachine
{
    class MJetCutting : Machine
    {
        public MJetCutting(int attack = 6, int life = 3, int experience = 1, int level = 1)
            : base(attack, life, experience, level )
        { 
            Tier = 3;
            Name = "Jet-Cutting";
        }
        public override MJetCutting Clone()
        {
            return new MJetCutting(this.Attack, this.Life, this.Experience, this.Level)
            {
                Name = this.Name,
                Tier = this.Tier,
                Image = this.Image
            };
        }
    }
}