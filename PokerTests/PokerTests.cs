using Poker.Models;
using Poker.Service;
using Poker.Models.Enums;

namespace PokerTests
{
    public class Tests
    {
        static IHandCalculator _calculator = new HandCalculator();

        [SetUp]
        public void Setup()
        {
        }

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
        public void testThreeOfKindWhenEqual()
        {
            Hand a = new(_calculator, D5, C5, H5, H9, H8);
            Hand b = new(_calculator, D5, C5, H5, H9, H8);
            Assert.That(b.CompareTo(a) == 0);
        }

        [Test]
        public void testThreeOfKind()
        {
            Hand a = new(_calculator, D5, C5, H5, H9, H8);
            Hand b = new(_calculator, D4, C4, H4, HA, HK);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
            Assert.That(b.CompareTo(a) != 0);
        }

        [Test]
        public void testThreeOfKind2()
        {
            Hand a = new(_calculator, D4, C4, H4, H9, H8);
            Hand b = new(_calculator, D4, C4, H4, H7, HA);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testThreeOfKind3()
        {
            Hand a = new(_calculator, D4, C4, H4, H9, H8);
            Hand b = new(_calculator, D4, C4, H4, H9, H6);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testThreeOfKind4()
        {
            Hand a = new(_calculator, D4, C4, H4, H9, H8);
            Hand b = new(_calculator, D4, C4, H4, H9, HA);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testFullHouseHands()
        {
            Hand a = new(_calculator, S6, D6, DA, CA, HA);
            Hand b = new(_calculator, S3, D3, DA, CA, HA);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testFullHouseHands2()
        {
            Hand a = new(_calculator, S6, D6, DA, CA, HA);
            Hand b = new(_calculator, C6, H6, DA, CA, HA);
            Assert.That(a.CompareTo(b) == 0);
            Assert.That(b.CompareTo(a) == 0);
        }

        [Test]
        public void testFullHouseHands3()
        {
            Hand a = new(_calculator, S6, D6, DA, CA, HA);
            Hand b = new(_calculator, C7, H7, DA, CA, HA);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testThreeOfAKind()
        {
            Hand a = new(_calculator, S6, D7, DA, CA, HA);
            Hand b = new(_calculator, C5, H6, DA, CA, HA);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testThreeOfAKind3()
        {
            Hand a = new(_calculator, S7, D6, DA, CA, HA);
            Hand b = new(_calculator, C7, H6, DA, CA, HA);
            Assert.That(a.CompareTo(b) == 0);
            Assert.That(b.CompareTo(a) == 0);
        }

        [Test]
        public void testFourOfAKind()
        {
            Hand a = new(_calculator, S7, CA, DA, HA, SA);
            Hand b = new(_calculator, D7, CA, DA, HA, SA);
            Assert.That(a.CompareTo(b) == 0);
            Assert.That(b.CompareTo(a) == 0);
        }

        [Test]
        public void testFourOfAKind4()
        {
            Hand a = new(_calculator, S8, CA, DA, HA, SA);
            Hand b = new(_calculator, D7, CA, DA, HA, SA);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }


        [Test]
        public void testTwoStraightsFlushes()
        {
            Hand straight1 = new(_calculator, C3, C4, C5, C6, C7);
            Hand straight2 = new(_calculator, CJ, C10, C9, C8, CQ);
            Assert.That(straight1.CompareTo(straight2) < 0);
            Assert.That(straight2.CompareTo(straight1) > 0);
        }

        [Test]
        public void testTwoStraights()
        {
            Hand straight1 = new(_calculator, C3, D4, H5, S6, C7);
            Hand straight2 = new(_calculator, CJ, H10, D9, C8, SQ);
            Assert.That(straight1.CompareTo(straight2) < 0);
        }

        [Test]
        public void testHighCard1()
        {
            Hand a = new(_calculator, C3, C4, D6, D7, DA);
            Hand b = new(_calculator, C2, C5, C7, DQ, DK);
            Assert.That(a.CompareTo(b) > 0);
        }

        [Test]
        public void testHighCard2()
        {
            Hand a = new(_calculator, C3, C4, D6, D7, DQ);
            Hand b = new(_calculator, C2, C5, C7, DJ, DK);
            Assert.That(a.CompareTo(b) < 0);
        }

        [Test]
        public void testHighCard3()
        {
            Hand a = new(_calculator, C3, C4, C6, CJ, DK);
            Hand b = new(_calculator, D2, D5, D7, DJ, SK);
            Assert.That(b.CompareTo(a) > 0);
            Assert.That(a.CompareTo(b) < 0);
        }

        [Test]
        public void testHighCard4()
        {
            Hand a = new(_calculator, C3, C4, C7, CJ, DK);
            Hand b = new(_calculator, D2, D5, D7, DJ, SK);
            Assert.That(b.CompareTo(a) > 0); // 5 > 4
        }

        [Test]
        public void testHighCard5()
        {
            Hand a = new(_calculator, C3, C5, C7, CJ, DK);
            Hand b = new(_calculator, D2, D5, D7, DJ, SK);
            Assert.That(a.CompareTo(b) > 0);
        }

        [Test]
        public void testPair1()
        {
            Hand a = new(_calculator, C3, C4, C7, CJ, DJ);
            Hand b = new(_calculator, D2, D5, D7, D10, S10);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testPair3()
        {
            Hand a = new(_calculator, CA, CK, CQ, C5, D5);
            Hand b = new(_calculator, DQ, DK, DA, D6, S6);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testPair13()
        { // do I have some of these pair tests below?
            Hand a = new(_calculator, CA, CK, CQ, C5, D5);
            Hand b = new(_calculator, DQ, DK, DA, D4, S4);
            Assert.That(a.CompareTo(b) > 0);
        }

        [Test]
        public void testPairWhenTied()
        {
            Hand a = new(_calculator, H3, CA, D4, H6, SA);
            Hand b = new(_calculator, D3, C4, DA, HA, C6);
            Assert.That(a.CompareTo(b) <= 0);
            Assert.That(b.CompareTo(a) >= 0);
        }

        [Test]
        public void testTwoPair1()
        {
            Hand a = new(_calculator, C4, CA, D4, H3, DA); // 2 Aces, two 4s, 3
            Hand b = new(_calculator, H4, C10, HA, SA, S4); // 2 Aces, two 4s, 10
            Assert.That(a.CompareTo(b) < 0);
        }

        [Test]
        public void testTwoPair2()
        {
            Hand a = new(_calculator, C4, CA, D4, H3, DA); // 2 Aces, two 4s, 3
            Hand b = new(_calculator, HQ, CJ, HK, SK, SQ); // 2 Kings, two Queens
            Assert.That(a.CompareTo(b) > 0);
        }

        [Test]
        public void testTwoPair3()
        {
            Hand a = new(_calculator, C4, CA, D4, H3, DA);
            Hand b = new(_calculator, H4, C10, HA, SA, S4);
            Assert.That(a.CompareTo(b) <= 0);
        }

        [Test]
        public void testTwoPair4()
        {
            Hand a = new(_calculator, C4, CA, D4, H3, DA);
            Hand b = new(_calculator, H4, C10, HA, SA, S4);
            Assert.That(b.CompareTo(a) >= 0);
        }

        [Test]
        public void testTwoPairWhenOnePairIsEqual()
        {
            Hand a = new(_calculator, C4, HK, D4, H3, DK);
            Hand b = new(_calculator, H4, C10, CA, DA, S4);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testTwoPairWhenOnePairIsEqual2()
        {
            Hand a = new(_calculator, C8, D8, CA, SA, CK);
            Hand b = new(_calculator, H9, S9, HA, DA, HK); // 2 AceS, 2 FourS
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testTwoPairWhenOnePairIsEqual3()
        {
            Hand a = new(_calculator, C9, D9, CK, DA, C2);
            Hand b = new(_calculator, H9, S9, HK, SA, C3);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
            Assert.That(a.CompareTo(b) != 0);
            Assert.That(b.CompareTo(a) != 0);
        }

        [Test]
        public void testTwoPairWhenTwoPairsAreEqual4()
        {
            Hand a = new(_calculator, C2, D2, C5, D5, CJ);
            Hand b = new(_calculator, H2, S2, H5, S5, C10);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testTwoPairWhenTwoPairsAreEquaAndTheFifthCardHasSameRank()
        {
            Hand a = new(_calculator, C2, D2, C5, D5, CJ);
            Hand b = new(_calculator, H2, S2, H5, S5, SJ);
            Assert.That(a.CompareTo(b) == 0);
            Assert.That(b.CompareTo(a) == 0);
        }

        [Test]
        public void testTwoPairWhenAtIndexesForCodeCoverage()
        {
            Hand a = new(_calculator, C2, D3, C5, D5, CJ);
            Hand b = new(_calculator, H2, S3, H3, S5, SJ);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testTwoPair6()
        {
            Hand a = new(_calculator, C2, C5, D2, D5, CJ);
            Hand b = new(_calculator, H5, S5, H2, S2, C10);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        // Trips
        [Test]
        public void testTrips1()
        {
            Hand a = new(_calculator, H7, C7, D7, S9, S10);
            Hand b = new(_calculator, H9, C10, H6, C6, D6);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testTrips2()
        {
            Hand a = new(_calculator, CK, DK, HK, CQ, CJ);
            Hand b = new(_calculator, CA, DA, HA, H2, D2);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testTripsBeatsTwoPair()
        {
            Hand a = new(_calculator, C2, H2, S2, CQ, CJ);
            Hand b = new(_calculator, CA, DA, HK, SK, D2);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testTripsLosesToFourOfAKind()
        {
            Hand a = new(_calculator, CA, HA, SA, CQ, CJ);
            Hand b = new(_calculator, C2, D2, H2, S2, D8);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testFullHouse1()
        {
            Hand a = new(_calculator, H8, C8, D8, H4, C4);
            Hand b = new(_calculator, H7, C7, D7, S4, D4);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }

        [Test]
        public void testFullHouse2()
        {
            Hand a = new(_calculator, H3, C3, D3, C4, D4);
            Hand b = new(_calculator, H5, C5, D5, H4, S4);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testFullHouse8()
        {
            Hand a = new(_calculator, H8, C8, D8, H4, C4);
            Hand b = new(_calculator, H7, C7, D7, S4, D4);
            Assert.That(a.CompareTo(b) > 0);
        }

        [Test]
        public void testFullHouseWhenPairsAreEqual()
        {
            Hand a = new(_calculator, C2, D2, C3, D3, H3);
            Hand b = new(_calculator, H2, S2, C4, D4, H4);
            Assert.That(a.CompareTo(b) < 0);
            Assert.That(b.CompareTo(a) > 0);
        }

        [Test]
        public void testFullHouseWhenPairIsGreaterThanTripsInOtherHandl()
        {
            Hand a = new(_calculator, C8, D8, C3, D3, H3);
            Hand b = new(_calculator, H7, S7, C4, D4, H4);
            Assert.That(b.CompareTo(a) > 0);
            Assert.That(a.CompareTo(b) < 0);
        }


        [Test]
        public void testFourOfKindWhenLast4Match()
        {
            Hand a = new(_calculator, CA, C2, D2, H2, S2);
            Hand b = new(_calculator, DA, C3, D3, H3, S3);
            Assert.That(a.CompareTo(b) < 0);
        }

        [Test]
        public void compareFlushes()
        {
            Hand a = new(_calculator, CA, C4, C6, C8, C9);
            Hand b = new(_calculator, HA, H4, H6, H8, H9);
            Assert.That(a.CompareTo(b) == 0);
        }

        // TEST CARD HGH HANDS

        [Test]
        public void testNothing0()
        {
            Hand nothing72 = new(_calculator, C2, C3, C4, C5, D7);
            Hand nothing73 = new(_calculator, D2, D4, D5, D6, C7);
            Assert.That(nothing73.CompareTo(nothing72) > 0);
        }

        [Test]
        public void testNothing1()
        {
            Hand nothing73 = new(_calculator, D2, D4, D5, D6, C7);
            Hand nothingJ = new(_calculator, C8, C9, C10, SJ, D3);
            Assert.That(nothingJ.CompareTo(nothing73) > 0);
        }

        [Test]
        public void testNothing2()
        {
            Hand nothingJ = new(_calculator, C8, C9, C10, SJ, D3);
            Hand nothingK8 = new(_calculator, HK, HQ, HJ, H10, S8);
            Assert.That(nothingK8.CompareTo(nothingJ) > 0);
        }

        [Test]
        public void testNothing3()
        {
            Hand nothingK9 = new(_calculator, CK, CQ, CJ, D10, H9);
            Hand nothingK8 = new(_calculator, HK, HQ, HJ, H10, S8);
            Assert.That(nothingK9.CompareTo(nothingK8) > 0);
        }

        [Test]
        public void testNothing4()
        {
            Hand nothingK8 = new(_calculator, HK, HQ, HJ, H10, S8);
            Hand nothingA = new(_calculator, S9, SJ, SQ, SK, CA);
            Assert.That(nothingA.CompareTo(nothingK8) > 0);
        }

        // TEST PAIRS
        [Test]
        public void testPair9()
        {
            Hand pair = new(_calculator, D2, H2, D3, S7, H6);
            Hand pair2 = new(_calculator, C2, S2, CQ, CK, CA);
            Assert.That(pair2.CompareTo(pair) > 0);
            Assert.That(pair.CompareTo(pair2) < 0);
        }

        [Test]
        public void testPair4()
        {
            Hand pair = new(_calculator, D2, H2, D3, S7, H6);
            Hand pair3 = new(_calculator, C3, H3, H4, H5, S6);
            Assert.That(pair3.CompareTo(pair) > 0);
            Assert.That(pair.CompareTo(pair3) < 0);
        }

        [Test]
        public void testPair5()
        {
            Hand pairLow = new(_calculator, C2, D2, C3, H4, H5);
            Hand pairHigh = new(_calculator, HA, CA, CK, CQ, HJ);
            Assert.That(pairHigh.CompareTo(pairLow) > 0);
        }

        [Test]
        public void testPair6()
        {
            Hand pairHigh = new(_calculator, HA, CA, CK, CQ, HJ);
            Hand pair = new(_calculator, D2, H2, D3, S7, H6);
            Assert.That(pairHigh.CompareTo(pair) > 0);
        }

        [Test]
        public void testPair7()
        {
            Hand pairHigh = new(_calculator, HA, CA, CK, CQ, HJ);
            Hand nothingJ = new(_calculator, C8, C9, C10, SJ, D3);
            Assert.That(pairHigh.CompareTo(nothingJ) > 0);
        }


        [Test]
        public void testPair10()
        {
            Hand pair = new(_calculator, D2, H2, D3, S7, H6);
            Hand nothingA = new(_calculator, S9, SJ, SQ, SK, CA);
            Assert.That(pair.CompareTo(nothingA) > 0);
        }

        // Test two pairs

        [Test]
        public void testTwoPairs0()
        {
            Hand twoPair = new(_calculator, D2, H4, C3, C2, H3);
            Hand twoPair2 = new(_calculator, H9, D9, S2, H2, SJ);
            Assert.That(twoPair2.CompareTo(twoPair) > 0);
        }

        [Test]
        public void testTwoPairs1()
        {
            Hand twoPairA = new(_calculator, DA, CA, DK, CK, H7);
            Hand twoPair2 = new(_calculator, H9, D9, S2, H2, SJ);
            Assert.That(twoPairA.CompareTo(twoPair2) > 0);
        }

        [Test]
        public void testTwoPairs2()
        {
            Hand twoPairA = new(_calculator, DA, CA, DK, CK, H7);
            Hand twoPairLow = new(_calculator, C2, D2, C3, H3, D4);
            Assert.That(twoPairA.CompareTo(twoPairLow) > 0);
        }

        [Test]
        public void testTwoPairs()
        {
            Hand twoPairHigh = new(_calculator, CA, HA, CK, HK, CQ);
            Hand twoPairLow = new(_calculator, C2, D2, C3, H3, D4);
            Assert.That(twoPairHigh.CompareTo(twoPairLow) > 0);
        }

        // TEST 3 OF A KIND

        [Test]
        public void testThreeMiddle3AreTheSameForCodeCoverage()
        {
            Hand ThreeKind = new(_calculator, D2, S5, D5, H5, CA);
            Hand ThreeKind2 = new(_calculator, C2, S4, D4, H4, SA);
            Assert.That(ThreeKind.CompareTo(ThreeKind2) > 0);
        }

        [Test]
        public void testThreeOfAKind1()
        {
            Hand ThreeKind = new(_calculator, D2, H5, H2, H4, C2);
            Hand ThreeKind2 = new(_calculator, C5, D5, S5, HA, HK);
            Assert.That(ThreeKind2.CompareTo(ThreeKind) > 0);
        }

        [Test]
        public void testThreeOfAKind2()
        {
            Hand ThreeKind3 = new(_calculator, H6, S6, C6, H3, S2);
            Hand ThreeKind2 = new(_calculator, C5, D5, S5, HA, HK);
            Assert.That(ThreeKind3.CompareTo(ThreeKind2) > 0);
        }

        [Test]
        public void testThreeOfAHigh3()
        {
            Hand ThreeKindLow = new(_calculator, D2, C2, H2, H3, H4);
            Hand ThreeKindHigh = new(_calculator, CA, HA, SA, CK, CQ);
            Assert.That(ThreeKindHigh.CompareTo(ThreeKindLow) > 0);
        }

        [Test]
        public void testThreeOfAHigh4()
        {
            Hand ThreeKindHigh = new(_calculator, CA, HA, SA, CK, CQ);
            Hand ThreeKind3 = new(_calculator, H6, S6, C6, H3, S2);
            Assert.That(ThreeKindHigh.CompareTo(ThreeKind3) > 0);
        }

        [Test]
        public void testThreeOfAHigh5()
        {
            Hand ThreeKind = new(_calculator, D2, H5, H2, H4, C2);
            Hand ThreeKindHigh = new(_calculator, CA, HA, SA, CK, CQ);
            Assert.That(ThreeKindHigh.CompareTo(ThreeKind) > 0);
        }

        [Test]
        public void testStaights1()
        {
            Hand straight = new(_calculator, C4, C6, C2, C5, S3);
            Hand straightInDifferentSuit = new(_calculator, D2, D3, D4, D5, S6);
            Assert.That(straight.CompareTo(straightInDifferentSuit) == 0);
        }

        [Test]
        public void testStaights2()
        {
            Hand straightHigh = new(_calculator, C10, HJ, CQ, CK, CA);
            Hand straight = new(_calculator, C4, C6, C2, C5, S3);
            Assert.That(straightHigh.CompareTo(straight) > 0);
        }

        // TEST FLUSHES
        private static Hand flush = new(_calculator, H7, H5, H3, H2, HJ);
        private static Hand flush2 = new(_calculator, S7, S5, S4, S2, SJ);
        private static Hand flushLow = new(_calculator, D2, D3, D4, D5, D7);
        private static Hand flushHigh = new(_calculator, CA, CK, CQ, CJ, C9);

        [Test]
        public void testFlush()
        {
            Assert.That(flush.CompareTo(flushLow) > 0);
        }

        [Test]
        public void testFlush2()
        {
            Assert.That(flushHigh.CompareTo(flushLow) > 0);
        }

        [Test]
        public void testFlush3()
        {
            Assert.That(flush2.CompareTo(flush) > 0);
        }

        [Test]
        public void testFlush4()
        {
            Assert.That(flush2.CompareTo(flushHigh) < 0);
        }

        // TEST FULL HOUSE
        // The higher triple wins
        [Test]
        public void testFullHouse3()
        {
            Hand fullHouse = new(_calculator, CA, DA, C3, D3, H3);
            Hand fullHouse2 = new(_calculator, C2, D2, C4, D4, H4);
            Assert.That(fullHouse2.CompareTo(fullHouse) > 0);
        }

        [Test]
        public void testFullHouse4()
        {
            Hand fullHouse3 = new(_calculator, HK, DK, SK, CA, HA);
            Hand fullHouse2 = new(_calculator, C2, D2, C4, D4, H4);
            Assert.That(fullHouse3.CompareTo(fullHouse2) > 0);
        }

        [Test]
        public void testFullHouse6()
        {
            Hand fullHouseLow = new(_calculator, C2, D2, H2, C3, H3);
            Hand fullHouseHigh = new(_calculator, CA, DA, HA, CK, HK);
            Assert.That(fullHouseHigh.CompareTo(fullHouseLow) > 0);
        }

        // TEST Four OF A KIND

        [Test]
        public void testFourOfAKind1()
        {
            Hand FourKindLow = new(_calculator, C2, D2, H2, S2, C3);
            Hand FourKindMid = new(_calculator, C8, D8, H8, S8, H3);
            Assert.That(FourKindMid.CompareTo(FourKindLow) > 0);
            Assert.That(FourKindLow.CompareTo(FourKindMid) < 0);
        }


        [Test]
        public void testFourOfAKind2()
        {
            Hand FourKindLow = new(_calculator, C2, D2, H2, S2, C3);
            Hand FourKindHigh = new(_calculator, CA, DA, HA, SA, CK);
            Assert.That(FourKindHigh.CompareTo(FourKindLow) > 0);
        }

        [Test]
        public void testFourOfAKind3()
        {
            Hand FourKindMid = new(_calculator, C8, D8, H8, S8, H3);
            Hand FourKindHigh = new(_calculator, CA, DA, HA, SA, CK);
            Assert.That(FourKindHigh.CompareTo(FourKindMid) > 0);
        }


        [Test]
        public void testFourOfAKind5()
        {
            Hand FourKindLow = new(_calculator, C2, D2, H2, S2, C3);
            Hand FourKindMid = new(_calculator, C2, D2, H2, S2, H3);
            Assert.That(FourKindMid.CompareTo(FourKindLow) == 0);
        }

        [Test]
        public void testFourOfAKind6()
        {
            Hand FourKindLow = new(_calculator, C2, D2, H2, S2, C3);
            Hand FourKindMid = new(_calculator, C2, D2, H2, S2, H4);
            Assert.That(FourKindMid.CompareTo(FourKindLow) > 0);
        }

        [Test]
        public void testFourOfAKind7()
        {
            Hand a = new(_calculator, C2, D2, H2, S2, C4);
            Hand b = new(_calculator, C2, D2, H2, S2, H3);
            Assert.That(a.CompareTo(b) > 0);
        }

        [Test]
        public void testFourOfAKind8()
        {
            Hand a = new(_calculator, C5, D5, H5, S5, C4);
            Hand b = new(_calculator, C5, D5, H5, S5, H3);
            Assert.That(a.CompareTo(b) > 0);
            Assert.That(b.CompareTo(a) < 0);
        }


        // TEST FLUSH

        [Test]
        public void testStraightFlush1()
        {
            Hand straightFlush = new(_calculator, H3, H4, H5, H6, H7);
            Hand straightFlushMid = new(_calculator, H8, H9, H10, HJ, HQ);
            Assert.That(straightFlushMid.CompareTo(straightFlush) > 0);
        }

        [Test]
        public void testStraightFlush2()
        {
            Hand straightFlushHi = new(_calculator, C10, CJ, CQ, CK, CA);
            Hand straightFlushMid = new(_calculator, H8, H9, H10, HJ, HQ);
            Assert.That(straightFlushHi.CompareTo(straightFlushMid) > 0);
        }

        [Test]
        public void testStraightFlush3()
        {
            Hand straightFlushHi = new(_calculator, C10, CJ, CQ, CK, CA);
            Hand straightFlush = new(_calculator, H3, H4, H5, H6, H7);
            Assert.That(straightFlushHi.CompareTo(straightFlush) > 0);
        }

        // Put ranks above others
        [Test]
        public void testManyRanks1()
        {
            Hand straightFlush = new(_calculator, H3, H4, H5, H6, H7);
            Hand FourKindHigh = new(_calculator, CA, DA, HA, SA, CK);
            Assert.That(straightFlush.CompareTo(FourKindHigh) > 0);
        }

        [Test]
        public void testManyRanks01()
        {
            Hand straightFlush = new(_calculator, H3, H4, H5, H6, H7);
            Hand pair2 = new(_calculator, C2, S2, CQ, CK, CA);
            Assert.That(straightFlush.CompareTo(pair2) > 0);
        }


        [Test]
        public void testManyRanks02()
        {
            Hand straightFlush = new(_calculator, H3, H4, H5, H6, H7);
            Hand twoPair2 = new(_calculator, H9, D9, S2, H2, SJ);
            Assert.That(straightFlush.CompareTo(twoPair2) > 0);
        }


        [Test]
        public void testStraightFlushes()
        {
            Hand a = new(_calculator, CA, DK, CQ, DJ, H10);
            Hand b = new(_calculator, H2, S3, C4, D5, H6);
            Assert.That(a.CompareTo(b) > 0);
        }

        [Test]
        public void testStraightFlushes2()
        {
            Hand a = new(_calculator, DA, DK, DQ, DJ, D10);
            Hand b = new(_calculator, SK, SQ, SJ, S10, S9);
            Assert.That(a.CompareTo(b) > 0);
        }

        // Test a variety

        Hand straightFlush = new(_calculator, H3, H4, H5, H6, H7);
        Hand fullHouse3 = new(_calculator, HK, DK, SK, CA, HA);
        Hand straight = new(_calculator, C4, C6, C2, C5, S3);
        Hand fullHouse2 = new(_calculator, C2, D2, C4, D4, H4);
        Hand straightHigh = new(_calculator, C10, HJ, CQ, CK, CA);
        Hand FourKindHigh = new(_calculator, CA, DA, HA, SA, CK);
        Hand FourKindMid = new(_calculator, C8, D8, H8, S8, H3);
        Hand ThreeKind2 = new(_calculator, C2, S4, D4, H4, SA);
        Hand ThreeKindHigh = new(_calculator, CA, HA, SA, CK, CQ);
        Hand ThreeKind3 = new(_calculator, H6, S6, C6, H3, S2);
        Hand straightFlushMid = new(_calculator, H8, H9, H10, HJ, HQ);
        Hand twoPairHigh = new(_calculator, CA, HA, CK, HK, CQ);
        Hand pairHigh = new(_calculator, HA, CA, CK, CQ, HJ);
        Hand nothingA = new(_calculator, S9, SJ, SQ, SK, CA);
        Hand pair = new(_calculator, D2, H2, D3, S7, H6);
        Hand pair3 = new(_calculator, C3, H3, H4, H5, S6);
        Hand pairLow = new(_calculator, C2, D2, C3, H4, H5);
        Hand nothing73 = new(_calculator, D2, D4, D5, D6, C7);


        [Test]
        public void testManyRanks03()
        {
            Assert.That(straightFlush.CompareTo(fullHouse3) > 0);
        }

        [Test]
        public void testManyRanks04()
        {
            Assert.That(straightFlush.CompareTo(straight) > 0);
        }

        [Test]
        public void testManyRanks05()
        {
            Assert.That(straightFlush.CompareTo(straightHigh) > 0);
        }

        [Test]
        public void testManyRanks2()
        {
            Assert.That(FourKindHigh.CompareTo(fullHouse2) > 0);
        }

        [Test]
        public void testManyRanks3()
        {
            Assert.That(FourKindMid.CompareTo(fullHouse2) > 0);
        }

        [Test]
        public void testManyRanks13()
        {
            Assert.That(FourKindMid.CompareTo(ThreeKind2) > 0);
        }

        [Test]
        public void testManyRanks14()
        {
            Assert.That(FourKindMid.CompareTo(ThreeKindHigh) > 0);
        }

        [Test]
        public void testManyRanks4()
        {
            Assert.That(fullHouse2.CompareTo(ThreeKind2) > 0);
        }

        [Test]
        public void testManyRanks5()
        {
            Assert.That(fullHouse2.CompareTo(ThreeKind3) > 0);
        }

        [Test]
        public void testManyRanks6()
        {
            Assert.That(fullHouse2.CompareTo(ThreeKind3) > 0);
        }

        [Test]
        public void testManyRanks7()
        {
            Assert.That(ThreeKind3.CompareTo(twoPairHigh) > 0);
        }

        [Test]
        public void testManyRanks07()
        {
            Assert.That(ThreeKind3.CompareTo(pairHigh) > 0);
        }

        [Test]
        public void testManyRanks08()
        {
            Assert.That(ThreeKind3.CompareTo(nothingA) > 0);
        }

        [Test]
        public void testManyRanks8()
        {
            Assert.That(twoPairHigh.CompareTo(pair) > 0);
        }

        [Test]
        public void testManyRanks9()
        {
            Assert.That(twoPairHigh.CompareTo(pair3) > 0);
        }

        [Test]
        public void testManyRanks10()
        {
            Assert.That(twoPairHigh.CompareTo(pairLow) > 0);
        }

        [Test]
        public void testManyRanks11()
        {
            Hand ThreeKind2 = new(_calculator, C2, S4, D4, H4, SA);
            Hand ThreeKindHigh = new(_calculator, CA, HA, SA, CK, CQ);
            Assert.That(ThreeKind2.CompareTo(ThreeKindHigh) < 0);
        }

        // Add Three random tests to get to 100 [Test]s
        [Test]
        public void testStraightFlush00()
        {
            Assert.That(straightFlushMid.CompareTo(fullHouse2) > 0);
        }

        [Test]
        public void testManyRanks44()
        {
            Assert.That(fullHouse2.CompareTo(ThreeKindHigh) > 0);
        }
    }
}