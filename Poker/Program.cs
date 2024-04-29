using Poker.Models;
using Poker.Service;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;

        Deck deck = new();
        HandCalculator handCalculator = new();

        IPokerService service = new PokerService(deck, handCalculator);

        service.Run();
    }
}