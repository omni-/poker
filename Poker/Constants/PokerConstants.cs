using Poker.Models;
using Poker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Constants
{
    public class PokerConstants
    {
        public const int HandSize = 5;
        public const int RunSize = 7;
        public const int PocketSize = 2;
        public const string Spade = "\u2660";
        public const string Heart = "\u2665";
        public const string Club = "\u2663";
        public const string Diamond = "\u2666";

        public static readonly ReadOnlyDictionary<Rank, string> RankMapping;
        public static readonly ReadOnlyDictionary<Suit, string> SuitMapping;
        public static readonly IReadOnlyList<Card> Deck;

        static PokerConstants()
        {
            Dictionary<Rank, string> rankDict = new()
            {
                { Rank.Ace, "A" },
                { Rank.Two,  "2" },
                { Rank.Three, "3" },
                { Rank.Four, "4" },
                { Rank.Five, "5" },
                { Rank.Six, "6" },
                { Rank.Seven, "7" },
                { Rank.Eight, "8" },
                { Rank.Nine, "9" },
                { Rank.Ten, "10" },
                { Rank.Jack, "J" },
                { Rank.Queen, "Q" },
                { Rank.King, "K" }
            };
            RankMapping = new(rankDict);

            Dictionary<Suit, string> suitDict = new()
            {
                { Suit.Diamond, Diamond },
                { Suit.Heart, Heart },
                { Suit.Spade, Spade },
                { Suit.Club, Club }
            };
            SuitMapping = new(suitDict);

            List<Card> deck = new()
            {
                new Card(Rank.Two, Suit.Club),
                new Card(Rank.Three, Suit.Club),
                new Card(Rank.Four, Suit.Club),
                new Card(Rank.Five, Suit.Club),
                new Card(Rank.Six, Suit.Club),
                new Card(Rank.Seven, Suit.Club),
                new Card(Rank.Eight, Suit.Club),
                new Card(Rank.Nine, Suit.Club),
                new Card(Rank.Ten, Suit.Club),
                new Card(Rank.Jack, Suit.Club),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Two, Suit.Diamond),
                new Card(Rank.Three, Suit.Diamond),
                new Card(Rank.Four, Suit.Diamond),
                new Card(Rank.Five, Suit.Diamond),
                new Card(Rank.Six, Suit.Diamond),
                new Card(Rank.Seven, Suit.Diamond),
                new Card(Rank.Eight, Suit.Diamond),
                new Card(Rank.Nine, Suit.Diamond),
                new Card(Rank.Ten, Suit.Diamond),
                new Card(Rank.Jack, Suit.Diamond),
                new Card(Rank.Queen, Suit.Diamond),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Two, Suit.Heart),
                new Card(Rank.Three, Suit.Heart),
                new Card(Rank.Four, Suit.Heart),
                new Card(Rank.Five, Suit.Heart),
                new Card(Rank.Six, Suit.Heart),
                new Card(Rank.Seven, Suit.Heart),
                new Card(Rank.Eight, Suit.Heart),
                new Card(Rank.Nine, Suit.Heart),
                new Card(Rank.Ten, Suit.Heart),
                new Card(Rank.Jack, Suit.Heart),
                new Card(Rank.Queen, Suit.Heart),
                new Card(Rank.King, Suit.Heart),
                new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.Two, Suit.Spade),
                new Card(Rank.Three, Suit.Spade),
                new Card(Rank.Four, Suit.Spade),
                new Card(Rank.Five, Suit.Spade),
                new Card(Rank.Six, Suit.Spade),
                new Card(Rank.Seven, Suit.Spade),
                new Card(Rank.Eight, Suit.Spade),
                new Card(Rank.Nine, Suit.Spade),
                new Card(Rank.Ten, Suit.Spade),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Spade),
                new Card(Rank.King, Suit.Spade),
                new Card(Rank.Ace, Suit.Spade)
            };
            Deck = deck;
        }
    }
}
