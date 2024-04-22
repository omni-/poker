using Poker.Models;
using Poker.Models.Enums;

namespace Poker.Service
{
    public interface IHandCalculator
    {
        (HandRanking, Rank) CalculateHandRanking(List<Card> cards);
    }
}
