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

    RectangleF[] reacts = new RectangleF[5];

    RectangleF[] reacts_s = new RectangleF[3];
    RectangleF rect1 = RectangleF.Empty;
    RectangleF rect2 = RectangleF.Empty;
    RectangleF rect3 = RectangleF.Empty;
    RectangleF rect4 = RectangleF.Empty;
    RectangleF rect5 = RectangleF.Empty;
    RectangleF rect6 = RectangleF.Empty;
    RectangleF rect7 = RectangleF.Empty;
    RectangleF rect8 = RectangleF.Empty;


    Game game = Game.CurrentGame;
    Round round = Round.CurrentRound;

    public ExampleApp()
    {
        reacts[0] = rect1;
        reacts[1] = rect2;
        reacts[2] = rect3;
        reacts[3] = rect4;
        reacts[4] = rect5;

        reacts_s[0] = rect6;
        reacts_s[1] = rect7;
        reacts_s[2] = rect8;
    }

    public override void OnFrame(bool isDown, PointF cursor)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < round.Store.Count; j++)
            {
                if (reacts[i].Contains(cursor) && reacts_s[j].Contains(cursor) && !isDown)
                {
                    fundiu = true;
                    Round.Purchase(i);
                }
            }
        }
        


        

        DrawText("Coins: " + round.Coins.ToString(), Color.Black, new RectangleF(800, 45, 150, 50), 25f);
        for (int i = 0; i <= (game.Life*55); i+=55)
        {
            DrawText("❤️", Color.Red, new RectangleF(50 + i, 50, 50, 50), 30f);
        }
        for (int i = 0; i <= (game.Trophies*35-35); i+=35)
        {
            DrawText("⭐", Color.Magenta, new RectangleF(400 + i, 45, 50, 50), 40f);
        }

         X = 0;
        for (int i = 0; i < 5; i++)
        {
            if (game.Team.Count == 0 || i >= game.Team.Count)
                reacts[i] = DrawEmpty(new RectangleF(100 + X, 250, 200, 200));
            else
                reacts[i] = DrawPiece(new RectangleF(100 + X, 250, 200, 200), game.Team[i].Attack, game.Team[i].Life, game.Team[i].Experience, game.Team[i].Tier, true, game.Team[i].Name);
            X += 150;
        }


        if (!fight)
        {
            refresh = DrawButton(new RectangleF(650, 700, 200, 100), "Atualizar Loja");
            if(round.Store.Count == 0 || refresh)
            {
                if(round.Coins <= 0)
                    DrawText("Saldo Insuficiente!", Color.Red, new RectangleF(800, 300, 300, 100), 15f);
                else if((DateTime.Now - time).TotalMilliseconds > 500 )
                {
                    Round.AddStore(RandomMachine.GetMachines(3, [70, 50, 40, 30, 20, 10]));
                    round.Coins--;
                    time = DateTime.Now;
                }
            }
            X = 0;
            
            for (int i = 0; i < 3; i++)
            {
                if (i >= round.Store.Count)
                    reacts_s[i] = DrawEmpty(new RectangleF(1100 + X, 700, 200, 200));
                else
                    reacts_s[i] = DrawPiece(new RectangleF(1100 + X, 700, 200, 200), round.Store[i].Attack, round.Store[i].Life, round.Store[i].Experience, round.Store[i].Tier, true, round.Store[i].Name);
                X += 150;
            }

            
            button = DrawButton(new RectangleF(400, 700, 200, 100), "LUTAR!");
        }
        else if (fight)
        {
            if(round.Enemy.Count == 0)
                round.Enemy = RandomMachine.GetMachines(5, [70, 50, 40, 30, 20, 10]);

            X = 0;
            foreach (var mach in round.Enemy)
            {
                rect1 = DrawPiece(new RectangleF(1000 + X, 250, 200, 200), mach.Attack, mach.Life, mach.Experience, mach.Tier, true, mach.Name);
                X += 150;
            }
        }    
        if(button && game.Team.Count > 0)
            fight = true;
        // Round.Purchase(0);
        // Round.Purchase(1);
        // Round.Purchase(2); 
    }

    // public void drawGroup(List<Machine> group, int size)
    // {
    //     for (int i = 0; i < 3; i++)
    //     {
    //         if (i >= round.Store.Count)
    //             reacts_s[i] = DrawEmpty(new RectangleF(1100 + X, 700, 200, 200));
    //         else
    //             reacts_s[i] = DrawPiece(new RectangleF(1100 + X, 700, 200, 200), round.Store[i].Attack, round.Store[i].Life, round.Store[i].Experience, round.Store[i].Tier, true, round.Store[i].Name);
    //         X += 150;
    //     }
    // }
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