
namespace BowlingKata
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int Score()
        {
            var score = 0;
            var firstInFrame = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(firstInFrame))
                {
                    score += 10 + BonusForStrike(firstInFrame);
                    firstInFrame += 1;
                }
                else if (IsSpare(firstInFrame))
                {
                    score += 10 + BonusForSpare(firstInFrame);
                    firstInFrame += 2;
                }
                else
                {
                    score += TotalForFrame(firstInFrame);
                    firstInFrame += 2;
                }
            }

            return score;
        }

        private int TotalForFrame(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1];
        }

        private bool IsStrike(int firstInFrame)
        {
            return rolls[firstInFrame] == 10;
        }

        private int BonusForStrike(int firstInFrame)
        {
            return rolls[firstInFrame + 1] + rolls[firstInFrame + 2];
        }

        private bool IsSpare(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1] == 10;
        }

        private int BonusForSpare(int firstInFrame)
        {
            return rolls[firstInFrame + 2];
        }
    }
}
