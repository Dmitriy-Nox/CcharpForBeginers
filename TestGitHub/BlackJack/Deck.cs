using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Deck
    {
        private Stack<int> _cards;

        public int CntDeck  => _cards.Count;

        public Deck()
        {
            ShuffleDeck();
            
        }
        private void ShuffleDeck()
        {
            List<int> cards = new List<int>
            {
                2, 3, 4, 5, 6, 7, 8, 9, 10,10,10, 11,
                2, 3, 4, 5, 6, 7, 8, 9, 10,10,10, 11,
                2, 3, 4, 5, 6, 7, 8, 9, 10,10,10, 11,
                2, 3, 4, 5, 6, 7, 8, 9, 10,10,10, 11
            };
            var RndCards = new List<int>();


            while(cards.Count>0)
            { 
                var shufIdx = new Random().Next(0, cards.Count-1);

                RndCards.Add(cards[shufIdx]);
                cards.RemoveAt(shufIdx);
            }
            _cards = new Stack<int>(RndCards);
        }
        public int Pull()
        {
            
return _cards.Pop();
        }
    }
}
