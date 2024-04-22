﻿using Poker.Models;
using Poker.Models.Enums;

namespace Poker.Service
{
    public class HandCalculator : IHandCalculator
    {
        public (HandRanking, Rank) CalculateHandRanking(List<Card> cards)
        {
            cards.Sort();
            Rank highCard, flushRank, straightRank;

            var suitGrouping = cards.GroupBy(x => x.Suit).OrderBy(x => x.Max(y => y.Rank));
            var numberGrouping = cards.GroupBy(x => x.Rank).OrderByDescending(x => x.Count()).ThenBy(x => x.Key);

            bool isFlush = CheckFlush(suitGrouping, out flushRank);
            bool isStraight = CheckStraight(cards, out straightRank);

            if (isFlush && isStraight) 
            {
                if (cards.Any(x => x.Rank == Rank.Ace) 
                    && cards.Any(x => x.Rank == Rank.Ten))
                {
                    return (HandRanking.RoyalFlush, Rank.Ace);
                }
                return (HandRanking.StraightFlush, flushRank > straightRank ? flushRank : straightRank);
            }
            if (CheckFourOfAKind(numberGrouping, out highCard))
                return (HandRanking.FourOfAKind, highCard);

            if (CheckFullHouse(numberGrouping, out highCard)) 
                return (HandRanking.FullHouse, highCard);

            if (isFlush)
                return (HandRanking.Flush, flushRank);

            if (isStraight)
                return (HandRanking.Straight, straightRank);

            if (CheckThreeOfAKind(numberGrouping, out highCard))
                return (HandRanking.ThreeOfAKind, highCard);

            if (CheckTwoPair(numberGrouping, out highCard))
                return (HandRanking.TwoPair, highCard);

            if (CheckPair(numberGrouping, out highCard))
                return (HandRanking.Pair, highCard);

            return (HandRanking.HighCard, highCard);
        }

        private bool CheckPair(IEnumerable<IGrouping<Rank, Card>> groups, out Rank highCard) 
        {
            return CheckNOfAKind(groups, 2, out highCard);
        }

        private bool CheckTwoPair(IEnumerable<IGrouping<Rank, Card>> groups, out Rank highCard) 
        {
            return CheckNOfAKind(groups, 2, out highCard, 2);
        }
        private bool CheckThreeOfAKind(IEnumerable<IGrouping<Rank, Card>> groups, out Rank highCard) 
        {
            return CheckNOfAKind(groups, 3, out highCard);
        }
        private bool CheckStraight(List<Card> cards, out Rank highCard) 
        {
            highCard = Rank.None;

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

            highCard = last.Rank;
            return true;
        }
        private bool CheckFlush(IEnumerable<IGrouping<Suit, Card>> groups, out Rank highCard) 
        {
            highCard = Rank.None;

            var group = groups.FirstOrDefault(x => x.Count() >= 5);
            if (group == null)
                return false;

            highCard = group.Max(x => x.Rank);
            return true;
        }
        private bool CheckFullHouse(IEnumerable<IGrouping<Rank, Card>> groups, out Rank highCard) 
        {
            highCard = Rank.None;

            bool triple = CheckNOfAKind(groups, 3, out Rank tripleRank);
            if (!triple) return false;

            bool pair = CheckNOfAKind(groups.Where(x => x.Key != tripleRank), 2, out _);
            if (!pair) return false;

            highCard = tripleRank;
            return true;
        }
        private bool CheckFourOfAKind(IEnumerable<IGrouping<Rank, Card>> groups, out Rank highCard) 
        {
            return CheckNOfAKind(groups, 4, out highCard);
        }

        private bool CheckNOfAKind(IEnumerable<IGrouping<Rank, Card>> groups, int n, out Rank highCard, int groupMin = 1)
        {
            highCard = Rank.None;

            var kinds = groups.Where(x => x.Count() >= n);

            if (kinds.Count() >= groupMin)
            {
                highCard = kinds.MaxBy(x => x.Key).Key;
                return true;
            }

            return false;
        }
    }
}
