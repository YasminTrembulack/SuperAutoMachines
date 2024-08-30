namespace SuperAutoMachine;

class MFornoIndustrailEletrico : Machine
{
    public MFornoIndustrailEletrico(int attack = 4, int life = 3, int experience = 1, int level = 1)
        : base(attack, life, experience, level)
    {
        Name = "Forno Industrial Elétrico";
        Tier = 3;
    }

       public override MFornoIndustrailEletrico Clone()
    {
        return new MFornoIndustrailEletrico(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        };
    }
}
