using System;
using Xunit;

namespace WarCardGame.Tests
{
    public class GameOfWarTests
    {
        [Fact]
        public void GameOfWarTest()
        {
            Assert.True(false);
        }

        [Fact]
        public void StartGameTest()
        {
            var game = new GameOfWar();
            game.StartGame();

            // Ensure the 2 players have an equal number of cards
            Assert.Equal(game.Hand(0).Count, game.Hand(1).Count);

            game.Play(0);
            game.Play(1);

            if (game.IsThereAWinningHand())
            {
                game.ClaimCards();
            }
            else
            {
                game.GoToWar();
                game.ClaimCards();
            }

            // Ensure the 2 players no longer have an equal number of cards
            Assert.NotEqual(game.Hand(0).Count, game.Hand(1).Count);
        }

        [Fact]
        public void PlayToEnd()
        {
            var game = new GameOfWar();
            game.StartGame();

            try
            {
                while (true)
                {
                    game.Play(0);
                    game.Play(1);

                    if (game.IsThereAWinningHand())
                    {
                        game.ClaimCards();
                    }
                    else
                    {
                        game.GoToWar();
                        game.ClaimCards();
                    }
                }
            }
            catch (InvalidOperationException excep)
            {
                Console.WriteLine(excep.Message);
            }
        }
    }
}