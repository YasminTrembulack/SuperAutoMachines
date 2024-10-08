
using System.Drawing;

namespace SuperAutoMachine;
public abstract class Machine(int attack, int life, int experience, int level)
{
    public string Name { get; set; } = "";
    public int Tier { get; set;} = 1;
    public int Experience { get; set; } = experience;
    public int Level { get; set; } = level;
    public string Image { get; set; } = "";
    //  = new Bitmap("../../images/chave_de_fenda.bmp");
    public int Life { get; set; } = life;
    public int Attack { get; set; } = attack;
    public virtual void StartBuy() { }
    public virtual void EndBuy() { }
    public virtual void Hurt() { }
    public virtual void Death() { }
    public virtual void Sell() { }
    public virtual void Atk(int index) { }

    public virtual Machine Clone() { return new MChaveDeFenda(this.Attack, this.Life, this.Experience, this.Level)
        {
            Name = this.Name,
            Tier = this.Tier,
            Image = this.Image
        }; 
    }

}
