using System;
using System.Collections.Generic;

namespace WarCardGame
{
    public class GameOfWar
    {
        private DeckOfCards cardDeck;
        private List<List<PlayingCard>> playerHands;
        private CardPool currentPool;

        public GameOfWar()
        {
            cardDeck = new DeckOfCards();
        }

        public void StartGame()
        {
            cardDeck.Shuffle();
            playerHands = cardDeck.Deal(2);
            currentPool = new CardPool();
        }

        public List<PlayingCard> Hand(int player)
        {
            return playerHands[player];
        }

        public void ClaimCards()
        {
            if (currentPool.CurrentFaceUpCard(0).Value == currentPool.CurrentFaceUpCard(1).Value)
            {
                throw new InvalidOperationException("Two cards are equal. Players must go to War");
            }

            if (currentPool.CurrentFaceUpCard(0).Value > currentPool.CurrentFaceUpCard(1).Value)
            {
                playerHands[0].AddRange(currentPool.ClaimCards());
            }
            else
            {
                playerHands[1].AddRange(currentPool.ClaimCards());
            }
        }

        public void GoToWar()
        {
            if (currentPool.CurrentFaceUpCard(0).Value != currentPool.CurrentFaceUpCard(1).Value)
            {
                throw new InvalidOperationException("Two cards are not equal. There is no need for a War");
            }

            // Both players deal face down cards to the pool
            Play(0, false);
            Play(1, false);

            // Both players deal new face up cards to the pool
            Play(0, true);
            Play(1, true);

            if (!IsThereAWinningHand())
            {
                GoToWar();
            }
        }

        public bool IsThereAWinningHand()
        {
            if (currentPool.CurrentFaceUpCard(0).Value != currentPool.CurrentFaceUpCard(1).Value)
            {
                return true;
            }

            return false;
        }

        public void Play(int player)
        {
            Play(player, isFaceUp: true);
        }

        private void Play(int player, bool isFaceUp)
        {
            if (playerHands[player].Count == 52)
            {
                throw new InvalidOperationException($"Player{player + 1} has all the cards and is the WINNER :)");
            }
            
            if (playerHands[player].Count == 0)
            {
                throw new InvalidOperationException($"Player{player + 1} is out of cards :(");
            }

            currentPool.Add(player, isFaceUp, playerHands[player][0]);
            playerHands[player].RemoveAt(0);
        }
    }
}
