using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata_Bowling
{

    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll = 0;
        /// <summary>
        /// Read score for the roll
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }
        /// <summary>
        /// Counting final game score
        /// </summary>
        /// <returns></returns>
        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }
        /// <summary>
        /// Check Is this a Strike 
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }
        /// <summary>
        /// Check Is this a Spare
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private bool IsSpare(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
        /// <summary>
        /// Count Strike bonus
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private int StrikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }
        /// <summary>
        /// Count Spare bonus
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private int SpareBonus(int frameIndex)
        {
            return _rolls[frameIndex + 2];
        }
        /// <summary>
        /// Count Sum of pins in one frame
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private int SumOfBallsInFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }
    }
}

