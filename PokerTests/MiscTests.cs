using Poker.Models.Enums;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Service;

namespace PokerTests
{
    [TestFixture]
    public class MiscTests
    {
        static IHandCalculator _calculator = new HandCalculator();

        private static Card C2 = new Card(Rank.Two, Suit.Club);
        private static Card C3 = new Card(Rank.Three, Suit.Club);
        private static Card C4 = new Card(Rank.Four, Suit.Club);
        private static Card C5 = new Card(Rank.Five, Suit.Club);
        private static Card C6 = new Card(Rank.Six, Suit.Club);
        private static Card C7 = new Card(Rank.Seven, Suit.Club);
        private static Card C8 = new Card(Rank.Eight, Suit.Club);
        private static Card C9 = new Card(Rank.Nine, Suit.Club);
        private static Card C10 = new Card(Rank.Ten, Suit.Club);
        private static Card CJ = new Card(Rank.Jack, Suit.Club);
        private static Card CQ = new Card(Rank.Queen, Suit.Club);
        private static Card CK = new Card(Rank.King, Suit.Club);
        private static Card CA = new Card(Rank.Ace, Suit.Club);

        private static Card D2 = new Card(Rank.Two, Suit.Diamond);
        private static Card D3 = new Card(Rank.Three, Suit.Diamond);
        private static Card D4 = new Card(Rank.Four, Suit.Diamond);
        private static Card D5 = new Card(Rank.Five, Suit.Diamond);
        private static Card D6 = new Card(Rank.Six, Suit.Diamond);
        private static Card D7 = new Card(Rank.Seven, Suit.Diamond);
        private static Card D8 = new Card(Rank.Eight, Suit.Diamond);
        private static Card D9 = new Card(Rank.Nine, Suit.Diamond);
        private static Card D10 = new Card(Rank.Ten, Suit.Diamond);
        private static Card DJ = new Card(Rank.Jack, Suit.Diamond);
        private static Card DQ = new Card(Rank.Queen, Suit.Diamond);
        private static Card DK = new Card(Rank.King, Suit.Diamond);
        private static Card DA = new Card(Rank.Ace, Suit.Diamond);

        private static Card H2 = new Card(Rank.Two, Suit.Heart);
        private static Card H3 = new Card(Rank.Three, Suit.Heart);
        private static Card H4 = new Card(Rank.Four, Suit.Heart);
        private static Card H5 = new Card(Rank.Five, Suit.Heart);
        private static Card H6 = new Card(Rank.Six, Suit.Heart);
        private static Card H7 = new Card(Rank.Seven, Suit.Heart);
        private static Card H8 = new Card(Rank.Eight, Suit.Heart);
        private static Card H9 = new Card(Rank.Nine, Suit.Heart);
        private static Card H10 = new Card(Rank.Ten, Suit.Heart);
        private static Card HJ = new Card(Rank.Jack, Suit.Heart);
        private static Card HQ = new Card(Rank.Queen, Suit.Heart);
        private static Card HK = new Card(Rank.King, Suit.Heart);
        private static Card HA = new Card(Rank.Ace, Suit.Heart);

        private static Card S2 = new Card(Rank.Two, Suit.Spade);
        private static Card S3 = new Card(Rank.Three, Suit.Spade);
        private static Card S4 = new Card(Rank.Four, Suit.Spade);
        private static Card S5 = new Card(Rank.Five, Suit.Spade);
        private static Card S6 = new Card(Rank.Six, Suit.Spade);
        private static Card S7 = new Card(Rank.Seven, Suit.Spade);
        private static Card S8 = new Card(Rank.Eight, Suit.Spade);
        private static Card S9 = new Card(Rank.Nine, Suit.Spade);
        private static Card S10 = new Card(Rank.Ten, Suit.Spade);
        private static Card SJ = new Card(Rank.Jack, Suit.Spade);
        private static Card SQ = new Card(Rank.Queen, Suit.Spade);
        private static Card SK = new Card(Rank.King, Suit.Spade);
        private static Card SA = new Card(Rank.Ace, Suit.Spade);

        [Test]
        public void BigHandWorks()
        {
            Hand a = new(_calculator, D4, C4, H4, H9, H8, S7, S2);
            Assert.That(a.BestHand, Does.Not.Contain(S7));
        }

        [Test]
        public void CanPickTheBestFullHouse()
        {
            Hand a = new(_calculator, SK, HK, CK, CA, HA, S10, H10);
            Assert.That(a.BestHand, Does.Not.Contain(S10));
        }
    }
}
