
namespace SuperAutoMachine;

class MFresa : Machine
{
    public MFresa(int attack = 4, int life = 5, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Fresa";
        Tier = 4;
    }
       public override MFresa Clone()
    {
        return new MFresa(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
}
