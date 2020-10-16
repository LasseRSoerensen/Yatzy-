using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class Scoreboard
    {
        public int SumOfCombo { get; set; }
        public int ScoreCount { get; set; }
        public int ScoreCountUpper { get; set; }
        public int TotalScoreUpper { get; set; }
        public int TotalScore { get; set; }
        public int UpperSectionBonus;

        public string[] UpperSection = { " ", " ", " ", " ", " ", " " };
        public string[] LowerSection = { " ", " ", " ", " ", " ", " ", " ", " ", " "};

        public Scoreboard()
        {
            ScoreCount = 0;
            UpperSectionBonus = 50;

            foreach (var i in UpperSection)
            {
                if (i != " ")
                {
                    ScoreCountUpper++;
                    TotalScoreUpper = TotalScoreUpper + Convert.ToInt32(i);
                }
            }

            if (ScoreCountUpper == 6 && TotalScoreUpper >= 63)
            {
                TotalScore = TotalScore + UpperSectionBonus;
            }
        }

        public void ResetScoreBoard()
        {

            for (int i = 0; i < UpperSection.Length; i++)
            {
                UpperSection[i] = " "; 
                
            }

            for (int i = 0; i < LowerSection.Length; i++)
            {
                LowerSection[i] = " ";
            }

            ScoreCount = 0;
            TotalScore = 0;
        }

        public void TotalScoreScoreboard()
        {
            foreach (var i in UpperSection)
            {
                TotalScore = TotalScore + Convert.ToInt32(i);
            }

            foreach (var i in LowerSection)
            {
                TotalScore = TotalScore + Convert.ToInt32(i);
            }
            Console.WriteLine($"The Total score is {TotalScore}");

        }

        public override string ToString()
        {
            return $"\r\n Upper section " +
                $"\r\nOnes: {UpperSection[0]} " +
                $"\r\nTwos: {UpperSection[1]} " +
                $"\r\nThrees: {UpperSection[2]} " +
                $"\r\nFours: {UpperSection[3]} " +
                $"\r\nFives: {UpperSection[4]} " +
                $"\r\nSixes: {UpperSection[5]} " +
                $"\r\n " +
                $"\r\n Lower section" +
                $"\r\nOne Pair: {LowerSection[0]}" +
                $"\r\nTwo Pairs: {LowerSection[1]}" +
                $"\r\nThree of a Kind: {LowerSection[2]}" +
                $"\r\nFour of a Kind: {LowerSection[3]}" +
                $"\r\nSmall Straight: {LowerSection[4]}" +
                $"\r\nLarge Straight: {LowerSection[5]} " +
                $"\r\nFull House: {LowerSection[6]}" +
                $"\r\nChance: {LowerSection[7]}" +
                $"\r\nYatzy: {LowerSection[8]}"; 
        }

    }
}
