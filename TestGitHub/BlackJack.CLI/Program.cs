using System;
using System.Collections.Generic;

namespace BlackJack.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[] { new Player("Игрок"), new Dealer("Computer") };
            Game game = new Game(players);
           

            while (game.IsEndGame)
            {
                for (int i = 0; i < game.Players.Length; i++)
                {
                    AskPlayer(game.Players[i]);
                    if (game.Players[i].IsContinue)
                    {
                        game.Players[i].AddScore(game.GetCard());
                    }
                }
            }
            Console.WriteLine($"Победа {game.GetWinner().NamePlayer} счет {game.GetWinner().Score}");

            var score = "Общий счет     ";
            for (int i = 0; i < game.Players.Length; i++)
                score += $"{game.Players[i].NamePlayer} счет {game.Players[i].Score}          ";
            Console.WriteLine(score);

        }



        private static void AskPlayer(Player player)
        {
            if (player as Dealer != null)
            {
                Console.WriteLine("Ход компьютера");
                player.Pass();
                if(player.IsContinue==false)
                    Console.WriteLine("Компьютер пасует");
                return;
            }
                Console.WriteLine("Будешь тянуть карту, (y/n)");
            string answ = Console.ReadLine();
            if (answ == "y")
            {
                Console.WriteLine("Вы тяните карту");
                player.IsContinue = true;
            }

            if (answ == "n")
            {
                Console.WriteLine("Вы пасуете");
                player.Pass();
            }

        }

        private static void AskComputer(Player player)
        {
            Console.WriteLine("Компьютер тянет карту");
            player.Pass();
        }
    }
}
