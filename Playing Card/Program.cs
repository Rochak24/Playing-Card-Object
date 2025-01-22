//Submitted By: Rochak Dahal 
//I soley have written this code own my own,However, after encountering several issue, I opted 
// for help with my seniors and asked questioned in various chatforum in order to complete the code

using System;

namespace Playing_Card
{
    // Creating PlayingCard Class
    public class PlayingCard
    {
        // Fields to store the values
        private string _suit;
        private string _value;

        // Constructor to assign suit and value
        public PlayingCard(string suit, string value)
        {
            _suit = suit;
            _value = value;
        }

        // Default constructor for Joker
        public PlayingCard()
        {
            _suit = "Joker";
            _value = "Joker";
        }

        // Getters and Setters
        public string Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        // Method to print the card
        public void PrintCard()
        {
            Console.WriteLine($"{Value} of {Suit}");
        }
    }

    // Creating Class Deck
    public class Deck
    {
        private PlayingCard[] Cards;
        private int cardCount;

        // Constructor to initialize the deck
        public Deck()
        {
            Cards = new PlayingCard[53];
            cardCount = 0;
            InitializeDeck();
        }

        // Method to initialize the deck with cards
        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            // Using nested loops to create cards
            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    Cards[cardCount] = new PlayingCard(suit, value);
                    cardCount++;
                }
            }

            // Adding the Joker card
            Cards[cardCount] = new PlayingCard();
            cardCount++;
        }

        // Method to draw a card
        public PlayingCard Draw()
        {
            if (cardCount == 0)
            {
                Console.WriteLine("The deck is empty.");
                return null;
            }

            PlayingCard topCard = Cards[0];

            // loop to shift cards down
            for (int i = 1; i < cardCount; i++)
            {
                Cards[i - 1] = Cards[i];
            }

            // This will clear our last card and decrease the count
            Cards[cardCount - 1] = null;
            cardCount--;

            return topCard;
        }
    }

    // Main Program to test the classes
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a deck of cards
            Deck deck = new Deck();

            // Card drawing 
            PlayingCard drawnCard = deck.Draw();
            if (drawnCard != null)
            {
                drawnCard.PrintCard(); 
            }

            // Drawing another set of card
            drawnCard = deck.Draw();
            if (drawnCard != null)
            {
                drawnCard.PrintCard(); 
            }
        }
    }
}