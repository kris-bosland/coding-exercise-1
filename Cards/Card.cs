using System;

namespace Cards
{
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        /// <summary>
        /// The cards suit.
        /// </summary>
        public readonly Suit Suit;

        /// <summary>
        /// The cards rank.
        /// </summary>
        public readonly Rank Rank;

        /// <summary>
        /// Constructor that takes a suit and a rank.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="rank"></param>
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Equals comparison to another card.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Card other)
        {
            return (object)other != null && Suit == other.Suit && Rank == other.Rank;
        }

        /// <summary>
        /// Equals comparison to another object, overriden.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            Card other = obj as Card;
            return Equals(other);
        }

        /// <summary>
        /// Calculate hash code for a card.
        /// Not the best performance, replace if this will be used a lot.
        /// From https://msdn.microsoft.com/en-us/library/system.object.gethashcode(v=vs.110).aspx
        /// </summary>
        /// <returns>Calculated hash code.</returns>
        public override int GetHashCode()
        {
            return Tuple.Create(Suit,Rank).GetHashCode();
        }

        /// <summary>
        /// == operator for comparing cards.
        /// </summary>
        /// <param name="card1">Left hand card.</param>
        /// <param name="card2">Right hand card.</param>
        public static bool operator == (Card card1, Card card2)
        {
            return ((object)card1 == null && (object)card2 == null) || (card1?.Equals(card2) ?? false);
        }

        /// <summary>
        /// != operator for comparing cards.
        /// </summary>
        /// <param name="card1">Left hand card.</param>
        /// <param name="card2">Right hand card.</param>
        public static bool operator != (Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        /// <summary>
        /// Compares this card to another for sorting.
        /// </summary>
        /// <param name="other">The other card for comparison.</param>
        /// <returns></returns>
        public int CompareTo(Card other)
        {
            if(other == null)
            {
                return 1;
            }

            var compareSuit = Suit.CompareTo(other.Suit);

            if(compareSuit != 0)
            {
                return compareSuit;
            }

            return Rank.CompareTo(other.Rank);
        }
    }
}