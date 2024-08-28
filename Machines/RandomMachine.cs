using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperAutoMachine;

class RandomMachine
{
    
    public static List<Machine> GetMachines(int size, int[] sort)
    {
        Random rand = new();
        List<Machine> team = new(size);

        if(sort.Length != 6)
            return team;

        for (int i = 0; i < size; i++)
        {
            int im = rand.Next(0, 100);

            if ( im <= sort[5])
            {
                team.Add(GetTier6());
                continue;
            }
            else if ( im <= sort[4])
            {
                team.Add(GetTier5());
                continue;
            }
            else if ( im <= sort[3])
            {
                team.Add(GetTier4());
                continue;
            }
            else if ( im <= sort[2])
            {
                team.Add(GetTier3());
                continue;
            }
            else if ( im <= sort[1])
            {
                team.Add(GetTier2());
                continue;
            }
            else
                team.Add(GetTier1());
            
            
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
    public static Machine GetTier2()
    {
        Random rand = new();
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
        Random rand = new();
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
        Random rand = new();
        int im = rand.Next(0, 1);

        return im switch
        {
            0 => new MFresa(),
            _ => new MTorno(),
        };
    }
    public static Machine GetTier5()
    {
        Random rand = new();
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