using Xunit;

namespace WarCardGame.Tests
{
    public class CardPoolTests
    {
        [Fact]
        public void VerifyPoolCreation()
        {
            var cardPool = new CardPool();
            Assert.Null(cardPool.CurrentFaceUpCard(0));
        }

        [Fact]
        public void ClaimCardsOnEmptyPool()
        {
            var cardPool = new CardPool();
            PlayingCard[] cards = cardPool.ClaimCards();

            Assert.True(cards.Length == 2);
            Assert.Null(cards[0]);
            Assert.Null(cards[1]);
        }
    }
}
