
namespace SuperAutoMachine;
abstract class Machine(int attack, int life, int experience, int level)
{
    protected string Name { get; set; } = "";
    protected int Tier { get; set;}
    public int Experience { get; set; } = experience;
    public int Level { get; set; } = level;
    public int Life { get; set; } = life;
    public int Attack { get; set; } = attack;
    public virtual void StartBuy() { }
    public virtual void EndBuy() { }

    public virtual void Hurt() { }
    public virtual void Death() { }
    public virtual void Sell() { }
}
