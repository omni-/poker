using Poker.Models.Enums;

namespace Poker.Models
{
    public class HandResult
    {
        public HandRanking HandRanking { get; set; }

        public Rank HighCard {  get; set; }

        public IEnumerable<Card> BestHand {  get; set; }

        public HandResult(HandRanking handRanking, Rank highCard, IEnumerable<Card> bestHand)
        {
            HandRanking = handRanking;
            HighCard = highCard;
            BestHand = bestHand;
        }

        public HandResult() { }
    }
}
