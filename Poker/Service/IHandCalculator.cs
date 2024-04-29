using Poker.Models;
using Poker.Models.Enums;

namespace Poker.Service
{
    public interface IHandCalculator
    {
        HandResult CalculateHandRanking(List<Card> cards);
    }
}
