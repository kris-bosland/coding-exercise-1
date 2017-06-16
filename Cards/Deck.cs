using System;
using System.Collections.Generic;

namespace Cards
{
    public class Deck
    {
        /// <summary>
        /// Cards in the deck.
        /// </summary>
        public readonly List<Card> Cards = new List<Card>();

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Deck() : this(new RandomNext() as IRandomNext)
        {            
        }

        /// <summary>
        /// Constructor with random number generator dependency.
        /// Since no cards are specified, it creates a default list of cards for the deck.
        /// </summary>
        /// <param name="random">Random number generator.</param>
        public Deck(IRandomNext random)
        {
            Random = random;

            foreach(var suit in new Suit[] {Suit.Club, Suit.Diamond, Suit.Heart, Suit.Spade})
            {
                foreach(var rank in new Rank[] {
                    Rank.Two,
                    Rank.Three,
                    Rank.Four,
                    Rank.Five,
                    Rank.Six,
                    Rank.Seven,
                    Rank.Eight,
                    Rank.Nine,
                    Rank.Ten,
                    Rank.Jack,
                    Rank.Queen,
                    Rank.King,
                    Rank.Ace})
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }

        /// <summary>
        /// Constructor that takes some cards.
        /// </summary>
        /// <param name="cards">Cards that will form the deck.</param>
        public Deck(IEnumerable<Card> cards) : this(cards, new Random() as IRandomNext)
        {
        }

        /// <summary>
        /// Constructor that takes some cards and a random number generator.
        /// </summary>
        /// <param name="cards">Cards that will form the deck.</param>
        /// <param name="random">Random number generator.</param>
        public Deck(IEnumerable<Card> cards, IRandomNext random)
        {
            Random = random;
            Cards.AddRange(cards);
        }

        /// <summary>
        /// Shuffle the cards in the deck.
        /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        public void Shuffle()
        {
            //for i from n−1 downto 1 do
            for(int i = Cards.Count - 1; i > 0; i--)
            {
                //j ← random integer such that 0 ≤ j ≤ i
                var j = Random.Next(0, i);

                //exchange a[j] and a[i]
                var tmp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = tmp;
            }
        }

        /// <summary>
        /// Sort the cards in the deck.
        /// </summary>
        public void Sort()
        {
            Cards.Sort();
        }

        private readonly IRandomNext Random;
    }
}