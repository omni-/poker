using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Models
{
    public interface IDeck
    {
        void Shuffle();

        void Reset();

        IEnumerable<Card> Deal(int amount);

        IEnumerable<Card> GetCards();
    }
}
