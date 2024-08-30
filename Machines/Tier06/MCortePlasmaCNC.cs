namespace SuperAutoMachine;

class MCortePlasmaCNC : Machine
{
    public MCortePlasmaCNC(int attack = 6, int life = 8, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Corte a Plasma CNC";
        Tier = 6;
    }
    public override MCortePlasmaCNC Clone()
    {
        return new MCortePlasmaCNC(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
    
}
