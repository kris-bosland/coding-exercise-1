using System;
using Cards;
using CardsTest;
using System.Collections.Generic;

namespace CardsRun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var card1 = new Card(Suit.Heart, Rank.Queen);
            var card2 = new Card(Suit.Diamond, Rank.Jack);
            var card3 = new Card(Suit.Club, Rank.Ten);

            var deck = new Deck(new List<Card>{card1, card2, card3}, new NotRandomNext(new int[]{0, 0}));

            deck.Sort();

            deck.Shuffle();

            Console.WriteLine("Goodbye World!");
        }
    }
}
