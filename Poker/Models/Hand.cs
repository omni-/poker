using Poker.Models.Enums;
using Poker.Service;

namespace Poker.Models
{
    public class Hand(IHandCalculator calculator) : IComparable<Hand>
    {
        public List<Card> Cards { get; init; } = new List<Card>();
        public HandRanking Ranking => _ranking ?? Calculate();

        public Rank HighCard {  get; private set; }

        public bool IsInitialized => Cards.Count != 0;

        private HandRanking? _ranking = null;
        private IHandCalculator _calculator = calculator;

        public HandRanking Calculate()
        {
            if (!IsInitialized)
                throw new ApplicationException();

            (HandRanking ranking, Rank highCard) = _calculator.CalculateHandRanking(Cards);
            HighCard = highCard;
            _ranking = ranking;
            return ranking;
        }

        public void Clear()
        {
            _ranking = null;
            HighCard = Rank.None;
            Cards.Clear();
        }

        public int CompareTo(Hand other)
        {
            if (!IsInitialized)
                throw new ApplicationException();

            if (Ranking != other.Ranking)
            {
                return Ranking - other.Ranking;
            }
            else
            {
                if (HighCard != other.HighCard)
                    return HighCard.CompareTo(other.HighCard);

                Cards.Sort();
                other.Cards.Sort();

                for(int i = Cards.Count - 1; i >= 0; i--)
                {
                    if (Cards[i].Rank != other.Cards[i].Rank)
                        return Cards[i].Rank.CompareTo(other.Cards[i].Rank);
                }
            }

            return 0;
        }

        public Hand(IHandCalculator calculator, Card card1, Card card2, Card card3, Card card4, Card card5)
            : this(calculator)
        {
            Cards.AddRange([card1, card2, card3, card4, card5]);
        }
    }
}
