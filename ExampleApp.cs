using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SuperAutoMachine;

public class ExampleApp : App
{
    bool fundiu = false;
    bool fight = false;
    bool button = false;
    bool refresh = false;
    int X = 0;
    DateTime time;
    RectangleF[] reacts_t = new RectangleF[5];
    RectangleF[] reacts_e = new RectangleF[5];
    RectangleF[] reacts_s = new RectangleF[3];
    Game game = Game.CurrentGame;
    Round round = Round.CurrentRound;

    public ExampleApp()
    {
        for (int i = 0; i < 5; i++)
        {
            reacts_e[i] = RectangleF.Empty;
            reacts_t[i] = RectangleF.Empty;
            if(i < 3)
                reacts_s[i] = RectangleF.Empty;
        }
    }

    public override void OnFrame(bool isDown, PointF cursor)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < round.Store.Count; j++)
            {
                if (reacts_t[i].Contains(cursor) && reacts_s[j].Contains(cursor) && !isDown)
                {
                    fundiu = true;
                    Round.Purchase(i);
                }
            }
        }

        DrawnStatus();
        DrawnGroup(reacts_t, game.Team, 5, new(100, 250));


        if (!fight)
        {
            refresh = DrawButton(new RectangleF(950, 700, 200, 100), "Atualizar Loja");
            if(round.Store.Count == 0 || refresh)
            {
                if(round.Coins <= 0)
                    DrawText("Saldo Insuficiente!", Color.Red, new RectangleF(400, 700, 300, 100), 20f);
                else if((DateTime.Now - time).TotalMilliseconds > 500 )
                {
                    Round.AddStore(RandomMachine.GetMachines(3, [70, 50, 40, 30, 20, 10]));
                    time = DateTime.Now;
                    round.Coins--;
                }
            }
            
            DrawnGroup(reacts_s, round.Store, 3, new(100, 700));

            button = DrawButton(new RectangleF(700, 700, 200, 100), "Lutar!");
        }
        else if (fight)
        {
            if(round.Enemy.Count == 0)
                round.Enemy = RandomMachine.GetMachines(5, [70, 50, 40, 30, 20, 10]);

            DrawnGroup(reacts_e, round.Enemy, 5, new(1000, 250));

        }    
        if(button && game.Team.Count > 0)
            fight = true;
        // Round.Purchase(0);
        // Round.Purchase(1);
        Round.Purchase(2); 
    }


    public void DrawnGroup(RectangleF[] react, List<Machine> group, int size, Tuple<int, int> position)
    {
        X = 0;
        for (int i = size-1; i >= 0 ; i--)
        {
            if (i >= group.Count)
                react[i] = DrawEmpty(new RectangleF(position.Item1 + X, position.Item2, 200, 200), (i+1).ToString());
            else
                react[i] = DrawPiece(new RectangleF(position.Item1 + X, position.Item2, 200, 200), group[i].Attack, group[i].Life, group[i].Experience, group[i].Tier, true, group[i].Name);
            X += 150;
        }
    }
    public void DrawnStatus()
    {
        DrawText("Coins: " + round.Coins.ToString(), Color.Black, new RectangleF(800, 45, 150, 50), 25f);
        for (int i = 0; i <= (game.Life*55); i+=55)
        {
            DrawText("❤️", Color.Red, new RectangleF(50 + i, 50, 50, 50), 30f);
        }
        for (int i = 0; i <= (game.Trophies*35-35); i+=35)
        {
            DrawText("⭐", Color.Magenta, new RectangleF(400 + i, 45, 50, 50), 40f);
        }
    }
    public void DrawnButtons()
    {
        refresh = DrawButton(new RectangleF(650, 700, 200, 100), "Atualizar Loja");
    }
}




// if (rect1.Contains(cursor) && rect2.Contains(cursor) && !isDown)
        //     fundiu = true;

        // if (!fundiu)
        // {
        //     // RectangleF location, int attack, int life, int experience, int tier, bool isGraspable, string name, Bitmap image = null
        //     rect1 = DrawPiece(new RectangleF(50, 50, 200, 200), machine01.Attack, machine01.Life, machine01.Experience, machine01.Tier, true, machine01.Name);
        //     rect2 = DrawPiece(new RectangleF(300, 50, 200, 200), 2, 4, 2, 1, true, "CNC");
        // }
        // else
        // {
        //     DrawPiece(new RectangleF(50, 50, 200, 200), 3, 5, 3, 1, true, "CNC");
        // }