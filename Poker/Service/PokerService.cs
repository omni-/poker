using Poker.Constants;
using Poker.Extensions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public class PokerService(IDeck deck, IHandCalculator handCalculator) : IPokerService
    {
        private bool _playing = true;

        public Player Player { get; init; } = new(handCalculator, 1, 100);

        public List<Player> NPCs { get; init; } = [];

        public List<Player> AllPlayers { get; init; } = [];

        public IDeck Deck { get; init; } = deck;

        public int Ante { get; private set; } = 2;

        public void Run()
        {
            Console.WriteLine("Please enter the number of players.");
            int players = int.Parse(Console.ReadLine());
            AllPlayers.Add(Player);
            for (int i = 0; i < players - 1; i++) 
            {
                Player npc = new(handCalculator, i + 2, 100);
                AllPlayers.Add(npc);
                NPCs.Add(npc);
            }

            while (_playing) 
            {
                Deck.Reset();
                Deck.Shuffle();

                var river = Deck.Deal(5);
                Console.WriteLine("Community Cards: " + river.ToFormattedString());

                foreach (Player player in AllPlayers) 
                {
                    player.Reset();
                    player.Bet(Ante);
                    player.Deal(Deck.Deal(2), true);
                    player.Deal(river);
                    Console.Write($"{player}: ${player.Money} - {player.Pocket.Item1} {player.Pocket.Item2}\r\n\tBest hand: {player.Hand.BestHand.ToFormattedString()}");
                    Console.Write($"\t{player.Hand.Ranking}");
                    Console.WriteLine();
                }

                var winner = AllPlayers.MaxBy(x => x.Hand);
                double pot = Ante * AllPlayers.Count;
                var winners = AllPlayers.Where(x => x.Hand.CompareTo(winner.Hand) == 0);
                int winnerCount = winners.Count();
                if (winnerCount > 1)
                {
                    Console.WriteLine("Winning hands (tie)");
                    foreach (var w in winners)
                    {
                        w.Win(pot / winnerCount);
                        Console.WriteLine($"{winner.Hand.BestHand.ToFormattedString()} {w.Hand.Ranking} {w} ${w.Money}");
                    }
                }
                else
                {
                    winner.Win(pot);
                    Console.WriteLine($"Winner: {winner} ${winner.Money}");
                    Console.WriteLine($"{winner.Hand.BestHand.ToFormattedString()}\t{winner.Hand.Ranking}");
                }
                Console.WriteLine("Play again? <y or n>");
                _playing = Console.ReadLine() == "y";
            }
        }
    }
}
