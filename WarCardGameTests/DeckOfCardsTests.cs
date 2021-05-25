using WarCardGame;
using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace WarCardGame.Tests
{
    public class DeckOfCardsTests
    {
        [Fact]
        public void RevealTopTest()
        {
            var deck = new DeckOfCards();

            PlayingCard topCard = deck.RevealTop();

            Assert.Equal(CardSuite.Diamonds, topCard.Suite);
            Assert.Equal(CardName.Ace, topCard.Name);
            Assert.Equal(14, topCard.Value);
        }
        
        [Fact]
        public void DealTest()
        {
            var deck = new DeckOfCards();
            var hands = deck.Deal(2);

            Assert.Equal(2, hands.Count);
            Assert.Equal(26, hands[0].Count);
            Assert.Equal(26, hands[1].Count);
        }

        [Fact]
        public void ShuffleTest()
        {
            var deck = new DeckOfCards();
            deck.Shuffle();

            PlayingCard topCard = deck.RevealTop();
            Assert.NotNull(topCard);
        }
    }
}