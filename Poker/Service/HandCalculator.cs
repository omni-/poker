using Poker.Constants;
using Poker.Models;
using Poker.Models.Enums;

namespace Poker.Service
{
    public class HandCalculator : IHandCalculator
    {
        List<Card> _cards;

        public HandResult CalculateHandRanking(List<Card> cards)
        {
            _cards = cards;

            _cards.Sort();

            var suitGrouping = _cards
                .GroupBy(x => x.Suit)
                .OrderBy(x => x.Max(y => y.Rank));
            var numberGrouping = _cards
                .GroupBy(x => x.Rank)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key);

            bool isFlush = CheckFlush(suitGrouping, out HandResult flushRresult);
            bool isStraight = CheckStraight(_cards, out HandResult straightResult);

            if (isFlush && isStraight) 
            {
                if (_cards.Any(x => x.Rank == Rank.Ace) 
                    && _cards.Any(x => x.Rank == Rank.Ten))
                {
                    return new(HandRanking.RoyalFlush, Rank.Ace, flushRresult.BestHand);
                }
                if (flushRresult.HighCard > straightResult.HighCard)
                    return new HandResult(HandRanking.StraightFlush, flushRresult.HighCard, flushRresult.BestHand);

                return new HandResult(HandRanking.StraightFlush, straightResult.HighCard, straightResult.BestHand);
            }
            if (CheckFourOfAKind(numberGrouping, out HandResult result))
                return result;

            if (CheckFullHouse(numberGrouping, out result))
                return result;

            if (isFlush)
                return flushRresult;

            if (isStraight)
                return straightResult;

            if (CheckThreeOfAKind(numberGrouping, out result))
                return result;

            if (CheckTwoPair(numberGrouping, out result))
                return result;

            if (CheckPair(numberGrouping, out result))
                return result;

            result.BestHand = _cards.TakeLast(PokerConstants.HandSize);
            result.HighCard = cards.Last().Rank;
            result.HandRanking = HandRanking.HighCard;
            return result;
        }

        private bool CheckPair(IEnumerable<IGrouping<Rank, Card>> groups, out HandResult result) 
        {
            return CheckNOfAKind(groups, 2, out result);
        }

        private bool CheckTwoPair(IEnumerable<IGrouping<Rank, Card>> groups, out HandResult result)
        {
            return CheckNOfAKind(groups, 2, out result, 2);
        }
        private bool CheckThreeOfAKind(IEnumerable<IGrouping<Rank, Card>> groups, out HandResult result) 
        {
            return CheckNOfAKind(groups, 3, out result);
        }
        private bool CheckStraight(List<Card> cards, out HandResult result) 
        {
            result = new();

            Card last = cards[0];
            for(int i = 1; i < cards.Count; i++)
            {
                if (last.Rank == cards[i].Rank)
                    return false;

                if ((last.Rank == Rank.Ace && cards[i].Rank == Rank.Two) || cards[i].Rank == last + 1)
                    last = cards[i];
                else
                    return false;
            }

            result.HighCard = last.Rank;
            result.HandRanking = HandRanking.Straight;
            result.BestHand = cards.TakeLast(PokerConstants.HandSize);
            return true;
        }
        private bool CheckFlush(IEnumerable<IGrouping<Suit, Card>> groups, out HandResult result) 
        {
            result = new();

            var group = groups.FirstOrDefault(x => x.Count() >= 5);
            if (group == null)
                return false;

            result.HighCard = group.Max(x => x.Rank);
            result.HandRanking = HandRanking.Flush;
            result.BestHand = group;
            return true;
        }
        private bool CheckFullHouse(IEnumerable<IGrouping<Rank, Card>> groups, out HandResult result) 
        {
            bool triple = CheckNOfAKind(groups, 3, out result);
            Rank tripleRank = result.HighCard;
            if (!triple) return false;

            bool pair = CheckNOfAKind(groups.Where(x => x.Key != tripleRank), 2, out HandResult pairResult);
            Rank pairRank = pairResult.HighCard;
            if (!pair) return false;

            result.HighCard = tripleRank;
            result.HandRanking = HandRanking.FullHouse;
            result.BestHand = groups.Where(x => x.Key == tripleRank || x.Key == pairRank).SelectMany(x => x);
            return true;
        }
        private bool CheckFourOfAKind(IEnumerable<IGrouping<Rank, Card>> groups, out HandResult result) 
        {
            return CheckNOfAKind(groups, 4, out result);
        }

        private bool CheckNOfAKind(IEnumerable<IGrouping<Rank, Card>> groups, int n, out HandResult result, int groupMin = 1)
        {
            result = new();

            var kinds = groups.Where(x => x.Count() >= n);

            if (kinds.Count() >= groupMin)
            {
                var highCard = kinds.MaxBy(x => x.Key).Key;
                result.HighCard = highCard;
                result.HandRanking = groupMin == 1 ? n switch
                {
                    2 => HandRanking.Pair,
                    3 => HandRanking.ThreeOfAKind,
                    4 => HandRanking.FourOfAKind,
                    _ => HandRanking.HighCard
                } : HandRanking.TwoPair;
                var outList = kinds.SelectMany(x => x).ToList();
                outList.AddRange(_cards.Where(x => !outList.Contains(x)).TakeLast(PokerConstants.HandSize - outList.Count));
                result.BestHand = outList;
                return true;
            }

            return false;
        }
    }
}
