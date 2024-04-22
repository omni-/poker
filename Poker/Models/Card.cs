using Poker.Models.Enums;

namespace Poker.Models
{
    public class Card(Rank number, Suit suit) : IComparable<Card>
    {
        public Rank Rank { get; init; } = number;
        public Suit Suit { get; init; } = suit;

        public int CompareTo(Card other)
        {
            return Rank.CompareTo(other.Rank);
        }
        public static Rank operator +(Card card, int i)
        {
            int num = (int)card.Rank + i;

            if (!Enum.IsDefined((Rank)num))
                return Rank.Ace;

            return (Rank)num;
        }

    }
}
