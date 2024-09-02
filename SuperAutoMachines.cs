using System;
using System.Collections.Generic;
using System.Drawing;
using SuperAutoMachine;

public class SuperAutoMachines : App
{
    int result_fight = 0;
    Tuple<string, Color> msg_fight = new("", Color.White);
    // bool fundiu = false;
    bool fight = false;
    bool button = false;
    bool refresh = false;
    DateTime time;
    DateTime time_msg;
    DateTime time_fight;
    RectangleF[] reacts_t = new RectangleF[5];
    RectangleF[] reacts_e = new RectangleF[5];
    RectangleF[] reacts_s = new RectangleF[3];
    RectangleF react_sell = RectangleF.Empty;
    Game game = Game.CurrentGame;
    Round round = Round.CurrentRound;
    bool winorlose = true;

    public SuperAutoMachines()
    {
        Round.AddStore(RandomMachine.GetMachines(3));

        // game.Team = RandomMachine.GetMachines(2);
        // game.Team.Add(new MMartelo());
        // game.Team.Add(new MEsteira());
        // game.Team.Add(new MMartelo());

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
        WinOrLose();
            
        DrawStatus();
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
            if (reacts_t[i].Contains(cursor) && react_sell.Contains(cursor) && !isDown)
            {
                Round.SellMachine(i);
                break;
            }
            if (i >= game.Team.Count)
                continue; // Pule iterações com índices inválidos

            for (int j = 0; j < game.Team.Count; j++)
            {
                if (i != j && game.Team.Count > 1 && reacts_t[i].Contains(cursor) && reacts_t[j].Contains(cursor) && !isDown)
                {
                    Round.Merge(i, j);
                    break;
                }
            }
        }


        if (!fight)
        {
            DrawGroup(reacts_t, game.Team, 5, new(100, 250), 1);
            // DrawImage(new Bitmap("./images/coin.bmp"), new RectangleF(50, 45, 50, 50));
            DrawText(round.Coins.ToString(), Color.Black, new RectangleF(55, 45, 150, 50), 25f);

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

            

            react_sell = DrawEmpty(new RectangleF(100, 700, 200, 200), "Vender Maquina", 0);

            DrawGroup(reacts_t, game.Team, 5, new(100, 250), 1);
            DrawGroup(reacts_s, round.Store, 3, new(330, 700), 1);
            DrawButtons();
            

            if (button && game.Team.Count > 0)
            {
                result_fight = 0;
                foreach (var mach in game.Team)
                    mach.EndBuy();
                
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

    public void WinOrLose()
    {
        if (game.Life <= 0)
        {
            DrawText("Você perdeu :(", Color.Red, new RectangleF(800, 500, 300, 100), 25f); 
        }
        if (game.Trophies == 10)
        {
            DrawText("Você ganhou! :)", Color.Green, new RectangleF(800, 500, 300, 100), 25f); 
        }
        winorlose = true;
    }
    public void Fight()
    {
        DrawGroup(reacts_e, round.Enemy, 5, new(1000, 250), 2);
        DrawGroup(reacts_t, round.SaveTeam, 5, new(100, 250), 1);
        
        if ((DateTime.Now - time_fight).TotalMilliseconds > 2500)
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
                foreach (var mach in game.Team)
                    mach.StartBuy();
            }
        }
        
    }
    public void DrawGroup(RectangleF[] react, List<Machine> group, int size, Tuple<int, int> position, int team)
    {
        int X = 0;
        // int startIndex = (team == 2) ? size - 1 : 0;
        // int endIndex = (team == 2) ? -1 : size;
        // int increment = (team == 2) ? -1 : 1;

        for (int i = 0; i != size ; i+= 1)
        {
            if (i >= group.Count || team == 0)
            {
                react[i] = DrawEmpty(new RectangleF(position.Item1 + X, position.Item2, 200, 200), (i+1).ToString(), 1);
            }
            else
            {
                // if(group[i].Image == "")
                    react[i] = DrawPiece(new RectangleF(position.Item1 + X, position.Item2, 200, 200), group[i].Attack, group[i].Life, group[i].Experience, group[i].Tier, true, group[i].Name, team);
                // else
                    // react[i] = DrawPiece(new RectangleF(position.Item1 + X, position.Item2, 200, 200), group[i].Attack, group[i].Life, group[i].Experience, group[i].Tier, true, group[i].Name, team, new Bitmap(group[i].Image));
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
        DrawText($"Round: {game.round}", Color.Gold, new RectangleF(750 , 40, 200, 200), 20f);
    }
    public void DrawButtons()
    {
        button = DrawButton(new RectangleF(1100, 700, 200, 100), "Lutar!");
        refresh = DrawButton(new RectangleF(850, 700, 200, 100), "Atualizar Loja");
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