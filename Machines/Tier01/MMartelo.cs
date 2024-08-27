namespace SuperAutoMachine
{
    class MMartelo : Machine
    {
        public MMartelo(int attack, int life, int experience, int level)
            : base(attack, life, experience, level)
        {
            Name =  "Martelo";
            Tier = 1;
        }
    }
}