using System;

namespace WarCardGame
{
    public enum CardSuite
    {
        Spades = 0,
        Clubs,
        Hearts,
        Diamonds
    }

    public enum CardName
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class PlayingCard
    {
        public CardSuite Suite { get; }
        public CardName Name { get; }

        public int Value 
        { 
            get;
        }

        public PlayingCard(CardSuite suite, CardName name)
        {
            Suite = suite;
            Name = name;
            Value = (int)name;
        }
    }
}
