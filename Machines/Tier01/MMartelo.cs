using System.IO;

namespace SuperAutoMachine
{
    class MMartelo : Machine
    {
        public MMartelo(int attack = 2, int life = 3, int experience = 1, int level = 1)
            : base(attack, life, experience, level)
        { 
            Tier = 1;
            Name = "Martelo";
            // FileStream fs = new("C:/Users/disrct/Desktop/Yasmin/SuperAutoMachine/images/martelo.png", FileMode.Open, FileAccess.Read);
            // Image = new Bitmap(fs);
        }
    }
}