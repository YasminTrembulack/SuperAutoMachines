
namespace SuperAutoMachine;

class MFresaCNC : Machine
{
    public MFresaCNC(int attack = 4, int life = 5, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Fresa CNC";
        Tier = 5;
    }
    public override MFresaCNC Clone()
    {
        return new MFresaCNC(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
}
