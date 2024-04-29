using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Models
{
    public interface IPlayer
    {
        double Money { get; }

        void Bet(double amount);

        void Win(double amount);

        void Reset(bool resetMoney = false);

        void Deal(IEnumerable<Card> cards, bool isPocket = false);
    }
}
