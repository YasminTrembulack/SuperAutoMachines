using System;
using System.Collections.Generic;

namespace SuperAutoMachine;

public enum Tier
{
    Tier1,
    Tier2,
    Tier3,
    Tier4,
    Tier5,
    Tier6
}

class RandomMachine
{
    private static readonly Random rand = new Random();
    public static List<Machine> GetMachines(int size)
    {
        List<Machine> machines = new List<Machine>();
        Tier maxTier = DetermineMaxTier(Game.CurrentGame.round);

        for (int i = 0; i < size; i++)
        {
            Tier tier = (Tier)rand.Next(0, (int)maxTier + 1);

            machines.Add(tier switch
            {
                // Tier.Tier1 => GetTier1(),
                // Tier.Tier2 => GetTier2(),
                // Tier.Tier3 => GetTier3(),
                // Tier.Tier4 => GetTier4(),
                // Tier.Tier5 => GetTier5(),
                // Tier.Tier6 => GetTier6(),
                // _ => throw new ArgumentException("Invalid tier")
                _ => new MChaveDeFenda()
            });
        }

        return machines;
    } 

    private static Tier DetermineMaxTier(int round)
    {
        if (round < 3) return Tier.Tier1;
        if (round < 6) return Tier.Tier2;
        if (round < 9) return Tier.Tier3;
        if (round < 12) return Tier.Tier4;
        if (round < 15) return Tier.Tier5;
        return Tier.Tier6;
    }

    public static Machine GetTier1()
    {
        int im = rand.Next(0, 2);

        return im switch
        {
            0 => new MChaveDeFenda(),
            1 => new MEsteira(),
            _ => new MMartelo(),
        };
    }
    public static Machine GetTier2()
    {
        int im = rand.Next(0, 2);

        return im switch
        {
            0 => new MFornoIndustrialGas(),
            1 => new MFuradeiraColunar(),
            _ => new MRetificaPlana(),
        };
    }

    public static Machine GetTier3()
    {
        int im = rand.Next(0, 2);

        return im switch
        {
            0 => new MFornoIndustrailEletrico(),
            1 => new MFuradeiraCoordenada(),
            _ => new MRetificaCilindrica(),
        };
    }
    public static Machine GetTier4()
    {
        int im = rand.Next(0, 1);

        return im switch
        {
            0 => new MFresa(),
            _ => new MTorno(),
        };
    }
    public static Machine GetTier5()
    {
        int im = rand.Next(0, 1);

        return im switch
        {
            0 => new MFresaCNC(),
            _ => new MTornoCNC(),
        };
    }
    public static Machine GetTier6()
    {
        return new MCortePlasmaCNC();
    }
}