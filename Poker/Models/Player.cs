using Poker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Models
{
    public class Player(IHandCalculator handCalculator, int id, double baseMoney) : IPlayer
    {
        public int Id { get; init; } = id;

        public Hand Hand { get; set; } = new(handCalculator);

        public Tuple<Card, Card> Pocket { get; set; }

        private double _money = baseMoney;
         
        private double _baseMoney = baseMoney;

        public double Money => Math.Round(_money, 2);

        public void Reset(bool resetMoney = false) 
        {
            if (resetMoney)
                _money = _baseMoney;
            Hand.Clear();
            Pocket = null;
        }

        public void Bet(double amount)
        {
            _money -= amount;
        }

        public void Win(double amount)
        {
            _money += amount;   
        }

        public override string ToString()
        {
            return $"Player {Id}";
        }

        public void Deal(IEnumerable<Card> cards, bool isPocket = false)
        {
            if (isPocket)
            {
                var _cards = cards.ToList();
                Pocket = new(_cards[0], _cards[1]);
            }

            Hand.AddCards(cards);
        }
    }
}
