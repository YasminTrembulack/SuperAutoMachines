using System;
using System.Collections.Generic;

namespace SuperAutoMachine;

class RandomMachine
{

    private static RandomMachine? currentRandomMachine = null;
    public static RandomMachine Random
    {
        get
        {
            currentRandomMachine ??= new RandomMachine();
            return currentRandomMachine;
        }
    }
    
    public static List<Machine> GetMachines(int size)
    {
        Random rand = new Random();
        List<Machine> team = new(size);

        for (int i = 0; i < size; i++)
        {
            int im = rand.Next(0, 12);
            switch (im)
            {
                case 0:
                    team.Add(GetTier1());
                    break;
                default:
                    break;
            }
            
        }
        return team;
    } 

    public static Machine GetTier1()
    {
        Random rand = new();
        int im = rand.Next(0, 2);

        return im switch
        {
            0 => new MChaveDeFenda(),
            1 => new MEsteira(),
            _ => new MMartelo(),
        };
    }
}