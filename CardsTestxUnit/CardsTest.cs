using System;
using Xunit;
using Cards;
using System.Collections.Generic;

namespace CardsTest
{
    public class CardsTest
    {
        [Fact]
        public void DefaultDeck_52CardsTest()
        {
            var deck = new Deck();

            Assert.Equal(52, deck.Cards.Count);
        }

        [Fact]
        public void DeckWithCards_HasCardsTest()
        {
            var deck = new Deck(new Card[]{new Card(Suit.Diamond, Rank.Three), new Card(Suit.Heart, Rank.Queen)});

            Assert.Equal(2, deck.Cards.Count);
        }

        [Fact]
        public void DeckSortTest()
        {
            var deck = new Deck(new List<Card>
            {
                new Card(Suit.Heart, Rank.Queen),
                new Card(Suit.Diamond, Rank.Jack),
                new Card(Suit.Club, Rank.Ten)
            });

            deck.Sort();

            Assert.Equal(new Card(Suit.Club, Rank.Ten), deck.Cards[0]);
            Assert.Equal(new Card(Suit.Diamond, Rank.Jack), deck.Cards[1]);
            Assert.Equal(new Card(Suit.Heart, Rank.Queen), deck.Cards[2]);
        }

        [Fact]
        public void DeckShuffleTest()
        {
            var deck = new Deck(new List<Card>
            {
                new Card(Suit.Heart, Rank.Queen),
                new Card(Suit.Diamond, Rank.Jack),
                new Card(Suit.Club, Rank.Ten)
            }, new NotRandomNext(new int[] {0, 0}));

            //With Fisher-Yates bottom up shuffle, with zeros,
            //step one swaps QH to bottom, step two swaps 10C to middle, JD left at top

            deck.Shuffle();

            Assert.Equal(new Card(Suit.Diamond, Rank.Jack), deck.Cards[0]);
            Assert.Equal(new Card(Suit.Club, Rank.Ten), deck.Cards[1]);
            Assert.Equal(new Card(Suit.Heart, Rank.Queen), deck.Cards[2]);            
        }
    }
}
