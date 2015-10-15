﻿using System;
using Xunit;

namespace BowlingKata
{
    public class DescribeBowlingGame
    {
        private Game game;

        public DescribeBowlingGame()
        {
            game = new Game();
        }

        private void RollMany(int number, int pins)
        {
            for (int i = 0; i < number; i++)
                game.Roll(pins);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        [Fact]
        public void GutterGame()
        {
            RollMany(20, 0);

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void AllOnes()
        {
            RollMany(20, 1);

            Assert.Equal(20, game.Score());
        }

        [Fact]
        public void GameWithOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);

            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void GameWithOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);

            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void PerfectGame()
        {
            RollMany(12, 10);

            Assert.Equal(300, game.Score());
        }
    }
}
