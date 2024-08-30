namespace SuperAutoMachine;

class MFuradeiraColunar : Machine
{
    public MFuradeiraColunar(int attack = 3, int life = 5, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name =  "Furadeira de Coluna";
        Tier = 2;
    }
     public override MFuradeiraColunar Clone()
    {
        return new MFuradeiraColunar(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
}
