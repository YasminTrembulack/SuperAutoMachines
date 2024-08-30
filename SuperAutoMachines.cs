using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualBasic.Devices;
using SuperAutoMachine;

public class SuperAutoMachines : App
{
    int result_fight = 0;
    Tuple<string, Color> msg_fight = new("", Color.White);
    bool fundiu = false;
    bool fight = false;
    bool button = false;
    bool refresh = false;
    int X = 0;
    DateTime time;
    DateTime time_msg;
    DateTime time_fight;
    RectangleF[] reacts_t = new RectangleF[5];
    RectangleF[] reacts_e = new RectangleF[5];
    RectangleF[] reacts_s = new RectangleF[3];
    Game game = Game.CurrentGame;
    Round round = Round.CurrentRound;

    public SuperAutoMachines()
    {
        Round.AddStore(RandomMachine.GetMachines(3));

        // game.Team = RandomMachine.GetMachines(2);
        // round.Enemy = RandomMachine.GetMachines(4);
        // result_fight = round.Fight();

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
        if (game.Life <= 0)
        {
            DrawText("Você perdeu :(", Color.Red, new RectangleF(800, 500, 300, 100), 25f); 
        }
        if (game.Trophies == 10)
        {
            DrawText("Você ganhou! :)", Color.Green, new RectangleF(800, 500, 300, 100), 25f); 
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < round.Store.Count; j++)
            {
                if (reacts_t[i].Contains(cursor) && reacts_s[j].Contains(cursor) && !isDown)
                {
                    Round.Purchase(j);
                    break;
                }
            }
        }

        DrawStatus();

        if (!fight)
        {
            DrawGroup(reacts_t, game.Team, 5, new(100, 250), 1);
            DrawImage(new Bitmap("./images/coin.bmp"), new RectangleF(50, 45, 50, 50));
            DrawText(round.Coins.ToString(), Color.Black, new RectangleF(55, 45, 150, 50), 25f);
            refresh = DrawButton(new RectangleF(950, 700, 200, 100), "Atualizar Loja");
            if(refresh)
            {
                if(round.Coins <= 0)
                    DrawText("Saldo Insuficiente!", Color.Red, new RectangleF(800, 500, 300, 100), 20f);
                
                else if((DateTime.Now - time).TotalMilliseconds > 500 )
                {
                    Round.AddStore(RandomMachine.GetMachines(3));
                    time = DateTime.Now;
                    round.Coins--;
                }
            }
            
            DrawGroup(reacts_s, round.Store, 3, new(100, 700), 1);

            button = DrawButton(new RectangleF(700, 700, 200, 100), "Lutar!");

            if (button && game.Team.Count > 0)
            {
                result_fight = 0;
                int numberOfMachines = game.round == 1 ? 3 : 5;
                if(round.Enemy.Count == 0)
                    round.Enemy = RandomMachine.GetMachines(numberOfMachines);
                fight = true;
                round.StartFight();
                time_fight = DateTime.Now; 
            }
        }
        else if (fight)
        {
            Fight();
        }    

        if ((DateTime.Now - time_msg).TotalMilliseconds < 5000)
            ShowResult();
    
    }

    public void Fight()
    {
        DrawGroup(reacts_e, round.Enemy, 5, new(1000, 250), 2);
        DrawGroup(reacts_t, round.SaveTeam, 5, new(100, 250), 1);
        
        if ((DateTime.Now - time_fight).TotalMilliseconds > 1500)
        {
            if (result_fight == 0){
                result_fight = round.FightStep();
                time_fight = DateTime.Now; 
            }    
            if(result_fight != 0){
                fight = false;
                Round.newRound();
                round = Round.CurrentRound;
                time_msg = DateTime.Now;
            }
        }
        
    }
    public void DrawGroup(RectangleF[] react, List<Machine> group, int size, Tuple<int, int> position, int team)
    {
        X = 0;
        for (int i = 0; i < size ; i++)
        {
            if (i >= group.Count)
                react[i] = DrawEmpty(new RectangleF(position.Item1 + X, position.Item2, 200, 200), (i+1).ToString());
            else{
                if(group[i].Image == "")
                    react[i] = DrawPiece(new RectangleF(position.Item1 + X, position.Item2, 200, 200), group[i].Attack, group[i].Life, group[i].Experience, group[i].Tier, true, group[i].Name, team);
                else
                    react[i] = DrawPiece(new RectangleF(position.Item1 + X, position.Item2, 200, 200), group[i].Attack, group[i].Life, group[i].Experience, group[i].Tier, true, group[i].Name, team, new Bitmap(group[i].Image));
            }
            X += 150;
        }
    }
    public void DrawStatus()
    {
        for (int i = 0; i <= (game.Life*55); i+=55)
        {
            DrawText("❤️", Color.Red, new RectangleF(250 + i, 50, 50, 50), 30f);
        }
        for (int i = 0; i <= (game.Trophies*39-39); i+=39)
        {
            DrawText("⭐", Color.Gold, new RectangleF(600 + i, 40, 60, 60), 50f);
        }
    }
    public void DrawButtons()
    {
        refresh = DrawButton(new RectangleF(650, 700, 200, 100), "Atualizar Loja");
    }

    public void ShowResult()
    {
        if (result_fight == 1)
            msg_fight = new("Você Ganhou!!", Color.Blue);

        else if (result_fight == -1)
            msg_fight = new("Inimigos Venceram", Color.Red);

        else if (result_fight == 2)
            msg_fight = new("Empate.", Color.Green);

        DrawText(msg_fight.Item1, msg_fight.Item2, new RectangleF(800, 500, 300, 100), 25f);
        
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