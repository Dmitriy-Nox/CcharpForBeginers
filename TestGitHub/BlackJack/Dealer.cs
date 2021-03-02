using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Dealer : Player
    {
        public Dealer(string namePlayer) : base(namePlayer)
        {
        }

        public override void Pass()
        {
            if(Score>15)
                IsContinue = false;

            IsContinue = Convert.ToBoolean(new Random().Next(0, 2));
        }
    }
}
