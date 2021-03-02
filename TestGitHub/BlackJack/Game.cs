using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {

        public Game(Player[] players)
        {
            Players = players;
        }
        public void Start()
        {


        }
        private Deck _deck=new Deck();

        public int GetCard()
        {
            return _deck.Pull();
        }

        public bool IsEndGame
        {
            get
            {
                if (_deck.CntDeck == 0)
                    return false;

                for (int i = 0; i < Players.Length; i++)
                {
                    if (Players[i].Score > 21)
                    {
                        return false;
                    }
                }

                return true;
                        
            }
        }

        public Player[] Players { get; set; }

        public Player GetWinner()
        {
            var winner = Players[0];
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Score < 21)
                {
                    winner = Players[i];

                    if (Players[i].Score>winner.Score)
                        winner = Players[i];
                }
            }

            return winner;
        }
    }
}
