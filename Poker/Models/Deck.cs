using Poker.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Models
{
    public class Deck : IDeck
    {
        public IReadOnlyList<Card> Cards { get; private set; }

        private static readonly Random rng = new();

        public Deck() 
        {
            Reset();
            Shuffle();
        }

        public void Reset()
        {
            List<Card> cards = [.. PokerConstants.Deck];
            Cards = cards;
        }

        public void Shuffle()
        {
            Cards = [.. Cards.OrderBy(_ => rng.Next())];
        }

        public IEnumerable<Card> Deal(int amount)
        {
            var result = Cards.Take(amount);
            var cards = Cards.ToList();
            cards.RemoveRange(0, amount);
            Cards = cards;
            return result;
        }

        public IEnumerable<Card> GetCards()
        {
            return Cards;
        }
    }
}
