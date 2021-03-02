using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Player
    {
        public Player(String namePlayer)
        {
            NamePlayer = namePlayer;
        }

        public String NamePlayer { get; set; }
        public int Score { get; private set; }

        public bool IsOver
        {
            get
            {
                if (Score > 21)
                    return false;
                return true;
            }
        }

        public bool IsContinue { get; set; } = true;

        public void AddScore(int value)
        {
            Score += value;
        }
        public virtual void Pass()
        {
            IsContinue=false;

        }

        

    }
}
