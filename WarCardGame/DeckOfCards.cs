using System;
using System.Collections.Generic;
using System.Text;

namespace WarCardGame
{
    public class DeckOfCards
    {
        private Stack<PlayingCard> currentDeck;

        public DeckOfCards()
        {
            currentDeck = new Stack<PlayingCard>(52);

            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int cardVal = 2; cardVal < 15; cardVal++)
                {
                    currentDeck.Push(new PlayingCard((CardSuite)suitVal, (CardName)cardVal));
                }
            }
        }

        public void Shuffle()
        {
            var rnd = new Random();
            PlayingCard[] shuffledDeck = currentDeck.ToArray();

            // Fisher-Yates shuffle
            for (int n = currentDeck.Count - 1; n > 0; --n)
            {
                int k = rnd.Next(n + 1);
                PlayingCard temp = shuffledDeck[n];
                shuffledDeck[n] = shuffledDeck[k];
                shuffledDeck[k] = temp;
            }

            currentDeck.Clear();
            foreach (PlayingCard card in shuffledDeck)
            {
                currentDeck.Push(card);
            }
        }

        public PlayingCard RevealTop()
        {
            return currentDeck.Peek();
        }

        public List<List<PlayingCard>> Deal(int numberOfHands)
        {
            var handsToReturn = new List<List<PlayingCard>>(numberOfHands);

            for (int hand = 0; hand < numberOfHands; hand++)
            {
                handsToReturn.Add(new List<PlayingCard>());
            }

            while (currentDeck.TryPeek(out _))
            {
                for (int handNumber = 0; handNumber < numberOfHands; handNumber++)
                {
                    PlayingCard card;
                    if (currentDeck.TryPop(out card))
                    {
                        handsToReturn[handNumber].Add(card);
                    }
                }
            }

            return handsToReturn;
        }
    }
}
