using Poker.Models.Enums;
using Poker.Service;

namespace Poker.Models
{
    public class Hand(IHandCalculator calculator) : IComparable<Hand>
    {
        public List<Card> Cards { get; init; } = new List<Card>();

        public List<Card> BestHand => _ranking?.BestHand.ToList() ?? Calculate().BestHand.ToList();

        public HandRanking Ranking => _ranking?.HandRanking ?? Calculate().HandRanking;

        public Rank RankValue => _ranking?.HighCard ?? Calculate().HighCard;

        public bool IsInitialized => Cards.Count != 0;

        private HandResult _ranking = null;
        private readonly IHandCalculator _calculator = calculator;

        public HandResult Calculate()
        {
            if (!IsInitialized)
                throw new ApplicationException();

            var result = _calculator.CalculateHandRanking(Cards);
            _ranking = result;
            return result;
        }

        public void Clear()
        {
            _ranking = null;
            Cards.Clear();
        }

        public void AddCards(params Card[] cards)
        {
            foreach(Card c in cards)
            {
                Cards.Add(c);
            }
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (Card c in cards)
            {
                Cards.Add(c);
            }
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
                if (RankValue != other.RankValue)
                    return RankValue.CompareTo(other.RankValue);

                BestHand.Sort();
                other.BestHand.Sort();

                for(int i = BestHand.Count - 1; i >= 0; i--)
                {
                    if (BestHand[i].Rank != other.BestHand[i].Rank)
                        return BestHand[i].Rank.CompareTo(other.BestHand[i].Rank);
                }
            }

            return 0;
        }

        public Hand(IHandCalculator calculator, params Card[] cards)
            : this(calculator)
        {
            Cards.AddRange(cards);
        }
    }
}
