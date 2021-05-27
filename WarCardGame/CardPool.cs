using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    public class CardPool
    {
        private PlayingCard[] currentFaceUpCards;
        private List<PlayingCard> otherCards;

        public CardPool()
        {
            currentFaceUpCards = new PlayingCard[2];
            otherCards = new List<PlayingCard>();
        }

        public PlayingCard CurrentFaceUpCard(int player)
        {
            return currentFaceUpCards[player];
        }

        public PlayingCard[] ClaimCards()
        {
            return currentFaceUpCards;
        }

        public string PrintCurrentPool()
        {
            var output = new StringBuilder();
            if (currentFaceUpCards[0] != null)
            {
                output.AppendLine($"Player 1: {currentFaceUpCards[0].Name} | {currentFaceUpCards[0].Suite} (face-up)");
            }

            if (currentFaceUpCards[1] != null)
            {
                output.AppendLine($"Player 2: {currentFaceUpCards[1].Name} | {currentFaceUpCards[1].Suite} (face-up)");
            }

            foreach (PlayingCard card in otherCards)
            {
                output.AppendLine($"{currentFaceUpCards[1].Name} | {currentFaceUpCards[1].Suite}");
            }

            return output.ToString();
        }

        internal void Add(int player, bool isFaceUp, PlayingCard card)
        {
            if (isFaceUp)
            {
                if (currentFaceUpCards[player] != null)
                {
                    otherCards.Add(currentFaceUpCards[player]);
                }
                currentFaceUpCards[player] = card;
            }
            else
            {
                otherCards.Add(card);
            }
        }
    }
}
