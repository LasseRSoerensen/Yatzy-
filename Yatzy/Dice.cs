using System;

namespace Yatzy
{


    public class Dice
    {
        public virtual int Current { get; set; }
        public int DiceID;
        public double RollTimes { get; set; }
        public bool HoldState { get; set; }
        static Random rand = new Random();
      



     
        public void Roll()
        {
            

            if (!HoldState)
            {


                Current = rand.Next(1, 7);
            }
        }

 

        //diceRolledPercentage() --> function which checks the percentage of dice values rolled, based on rollTimes
        public void diceRolledPercentage(double rolltimes)
        {
            RollTimes = rolltimes;
            double diceNumber = 1;
            double[] diceSideSum = new double[6];

            for (int i = 0; i < RollTimes; i++)
            {
                Roll();

                switch (Current)
                {
                    case 1:
                        diceSideSum[0]++;
                        break;
                    case 2:
                        diceSideSum[1]++;
                        break;
                    case 3:
                        diceSideSum[2]++;
                        break;
                    case 4:
                        diceSideSum[3]++;
                        break;
                    case 5:
                        diceSideSum[4]++;
                        break;
                    default:
                        diceSideSum[5]++;
                        break;
                }
            }

            foreach (var side in diceSideSum)
            {
                var calculatedPercentage = (side / RollTimes) * 100;
                Console.WriteLine($"Dice value {diceNumber} rolled a total of {side}, with the percentile equivalent of {calculatedPercentage}%");
                diceNumber++;
            }
        }

        public void KeepDice()
        {
            HoldState = !HoldState;

        }

        public void ResetHoldState()
        {
            HoldState = false;
        }
        public override string ToString()
        {

            if (HoldState)
            {


                return $"{DiceID}) dice with value {Current} is on hold";
            }

            return $"{DiceID}) terningen rullede {Current}";

        }
    }
}
