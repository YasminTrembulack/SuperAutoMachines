namespace SuperAutoMachine;

class MTornoCNC : Machine
{
    public MTornoCNC(int attack = 5, int life = 3, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Torno";
        Tier = 5;
    }

    public override MTornoCNC Clone()
    {
        return new MTornoCNC(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
}
