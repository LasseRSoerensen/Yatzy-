using System;

namespace Yatzy
{
    public class Yatzy
    {

        Dice[] dices;
        Scoreboard GameScoreboard = new Scoreboard();
        int[] diceVal;
        int holdDiceCount = 0;
        public int sumOfCupRoll = 0;

        public Yatzy()
        {



            int idCount = 1;
            dices = new Dice[5];

            for (var i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice();

                dices[i].DiceID = idCount;
                idCount++;
            }




        }

        //Roll() --> rolls the cup with all dice 
        public void Roll()
        {
            foreach (var i in dices)
            {
                i.Roll();
                Console.WriteLine(i);
            }
        }

        public void InsertDiceValueInArray()
        {

            holdDiceCount = 0;

            for (int i = 0; i < dices.Length; i++)
            {
                if (dices[i].HoldState == true)
                {
                    holdDiceCount++;
                }
            }

            diceVal = new int[holdDiceCount];

            for (int i = 0; i < dices.Length; i++)
            {
                if (dices[i].HoldState == true)
                {
                    try
                    {
                        int a = 0;
                        while (true)
                        {
                            if (diceVal[a] == 0)
                            {
                                diceVal[a] = dices[i].Current;
                                break;
                            }
                            a++;

                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        if (diceVal[0] == 0)
                        {

                            for (int a = 0; a < diceVal.Length; a++)
                            {
                                if (diceVal[a] == 0)
                                {
                                    diceVal[a] = dices[i].Current;
                                }
                            }

                        }

                    }


                }

            }

            Array.Sort(diceVal);

        }

        //Chance() --> Gives the sum of all dices pr. roll, and saves the value to sumOfCupRoll

        public void NumberOf(int requestedNumber)
        {
            var sideSum = 0;

            switch (requestedNumber)
            {


                case 1:
                    foreach (var i in dices)
                    {
                        if (i.Current == 1)
                        {
                            sideSum++;
                        }
                    }
                    Console.WriteLine($"{sideSum} dice have rolled 1");
                    break;

                case 2:
                    foreach (var i in dices)
                    {
                        if (i.Current == 2)
                        {
                            sideSum++;
                        }
                    }
                    Console.WriteLine($"{sideSum} dice have rolled 2");
                    break;
                case 3:
                    foreach (var i in dices)
                    {
                        if (i.Current == 3)
                        {
                            sideSum++;
                        }
                    }
                    Console.WriteLine($"{sideSum} dice have rolled 3");
                    break;
                case 4:
                    foreach (var i in dices)
                    {
                        if (i.Current == 4)
                        {
                            sideSum++;
                        }
                    }
                    Console.WriteLine($"{sideSum} dice have rolled 4");
                    break;
                case 5:
                    foreach (var i in dices)
                    {
                        if (i.Current == 5)
                        {
                            sideSum++;
                        }
                    }
                    Console.WriteLine($"{sideSum} dice have rolled 5");
                    break;
                case 6:
                    foreach (var i in dices)
                    {
                        if (i.Current == 6)
                        {
                            sideSum++;
                        }
                    }
                    Console.WriteLine($"{sideSum} dice have rolled 6");
                    break;
            }




        }

        public int HasHouse()
        {
            int sumOfHasHouse = 0;
            if (diceVal.Length == 5)
            {

                if (diceVal[0] == diceVal[1] && diceVal[1] == diceVal[2] &&
                    diceVal[3] == diceVal[4] &&
                    diceVal[2] != diceVal[3] ||
                   diceVal[0] == diceVal[1] &&
                    diceVal[2] == diceVal[3] && diceVal[3] == diceVal[4] &&
                    diceVal[1] != diceVal[2])
                {
                    for (int i = 0; i < diceVal.Length; i++)
                    {
                        sumOfHasHouse = sumOfHasHouse + diceVal[i];
                    }
                }
            }


            return sumOfHasHouse;
        }

        public int SumOfSameValue(int input)
        {
            int SumOfSameValue = 0;
            int valueCount = 0;

            for (int i = 0; i < diceVal.Length; i++)
            {
                if (diceVal[i] == input)
                {
                    valueCount++;
                }



            }

            SumOfSameValue = input * valueCount;

            return SumOfSameValue;
        }

        public int OneHouse()
        {
            int sumOfOneHouse = 0;

            if (diceVal.Length >= 2)
            {
                for (int i = 0; i < diceVal.Length - 1; i++)
                {
                    if (diceVal[i] == diceVal[i + 1])
                    {
                        sumOfOneHouse = diceVal[i] + diceVal[i + 1];
                    }
                }

            }

            return sumOfOneHouse;

        }

        public int TwoHouse()
        {
            int sumOfTwoHouse = 0;

            if (diceVal.Length == 4)
            {

                if (diceVal[0] == diceVal[1] && diceVal[2] == diceVal[3])
                {
                    for (int i = 0; i < diceVal.Length; i++)
                    {
                        sumOfTwoHouse = sumOfTwoHouse + diceVal[i];
                    }
                }

            }


            else if (diceVal.Length == 5)
            {

                if (diceVal[0] == diceVal[1] && diceVal[2] == diceVal[3] && diceVal[3] != diceVal[4])
                {
                    sumOfTwoHouse = sumOfTwoHouse + diceVal[0] + diceVal[1] + diceVal[2] + diceVal[3];
                }
                else if (diceVal[1] == diceVal[2] && diceVal[3] == diceVal[4] && diceVal[1] != diceVal[0])
                {
                    sumOfTwoHouse = sumOfTwoHouse + diceVal[1] + diceVal[2] + diceVal[3] + diceVal[4];
                }
                if (diceVal[0] == diceVal[1] && diceVal[3] == diceVal[4] && diceVal[3] != diceVal[1])
                {
                    sumOfTwoHouse = sumOfTwoHouse + diceVal[0] + diceVal[1] + diceVal[3] + diceVal[4];
                }


            }

            return sumOfTwoHouse;

        }

        public int ThreeOfAKind()
        {
            int SumOfThreeOfAKind = 0;

            if (diceVal.Length >= 3)
            {

                for (int i = 0; i < diceVal.Length - 2; i++)
                {
                    if (diceVal[i] == diceVal[i + 1] && diceVal[i + 1] == diceVal[i + 2])
                    {


                        SumOfThreeOfAKind = diceVal[i] + diceVal[i + 1] + diceVal[i + 2];
                    }
                }

            }
            return SumOfThreeOfAKind;
        }

        public int Chance()
        {
            int sumOfChance = 0;

            for (int i = 0; i < diceVal.Length; i++)
            {
                sumOfChance = sumOfChance + diceVal[i];
            }

            return sumOfChance;
        }
        public void PrintDiceVal()
        {
            foreach (var i in diceVal)
            {
                Console.WriteLine(i);
            }
        }


        public int FourOfAKind()
        {
            int sumOfFourOfAKind = 0;

            if (diceVal.Length == 4)
            {

                if (diceVal[0] == diceVal[1] && diceVal[2] == diceVal[3])
                {
                    sumOfFourOfAKind = diceVal[0] + diceVal[1] + diceVal[2] + diceVal[3];
                }
            }

            if (diceVal.Length == 5)
            {

                if (diceVal[1] == diceVal[2] && diceVal[3] == diceVal[4])
                {
                    sumOfFourOfAKind = diceVal[1] + diceVal[2] + diceVal[3] + diceVal[4];
                }

            }



            return sumOfFourOfAKind;
        }

        public int YatzyCombo()
        {
            int sumOfYatzy = 0;
            int Count = 0;

            if (diceVal.Length == 5)
            {

                for (int i = 0; i < diceVal.Length; i++)
                {
                    if (diceVal[0] == diceVal[i])
                    {
                        Count++;
                    }
                }

                if (Count == 5)
                {
                    sumOfYatzy = 50;
                }

            }
            return sumOfYatzy;
        }

        public int SmallStraight()
        {
            int sumOfSmallStraight = 0;
            int count = 0;
            if (diceVal.Length == 5)
            {
                for (int i = 1; i < diceVal.Length; i++)
                {

                    if (diceVal[count] == i)
                    {
                        count++;
                    }

                }

                if (count == 5)
                {
                    sumOfSmallStraight = 15;
                }
            }

            return sumOfSmallStraight;
        }

        public int LargeStraight()
        {
            int sumOfLargeStraight = 0;
            int count = 0;
            if (diceVal.Length == 5)
            {
                for (int i = 2; i < 7; i++)
                {

                    if (diceVal[count] == i)
                    {
                        count++;
                    }

                }

                if (count == 5)
                {
                    sumOfLargeStraight = 20;
                }
            }

            return sumOfLargeStraight;
        }


        public void KeepV2(string input)
        {
            try
            {
                int Input = Convert.ToInt32(input) - 1;
                dices[Input].KeepDice();

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("You need to enter a number between 1 and 5");
            }

            catch (IndexOutOfRangeException w)
            {
                Console.WriteLine(w.Message);
                Console.WriteLine("You need to enter a number between 1 and 5");
            }

        }

        public void ResetKeep()
        {
            foreach (var i in dices)
            {
                i.ResetHoldState();
            }
        }

        public void ResetScoreBoard()
        {
            Console.Clear();
            Console.WriteLine("All slots in the scoreboard have been filled");
            Console.WriteLine("Type 'reset' to reset the scoreboard");
            PrintScore();
            GameScoreboard.TotalScoreScoreboard();
            Console.WriteLine("Enter command: ");


            while (true)
            {

                var input = Console.ReadLine();

                if (input == "reset")
                {

                    GameScoreboard.ResetScoreBoard();
                    Console.WriteLine("\r\n");
                    break;
                }


            }
        }

        public void InsertScoreUpperSection(string input)
        {

            while (true)
            {


                try
                {

                    int Input = Convert.ToInt32(input) - 1;

                    if (GameScoreboard.UpperSection[Input] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.UpperSection[Input] = Convert.ToString(SumOfSameValue(Convert.ToInt32(input)));
                        break;
                    }
                    else if (GameScoreboard.UpperSection[Input] != " ")
                    {
                        Console.WriteLine("Slot have already been assigned a value");
                        Console.WriteLine("Choose another slot");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.UpperSection[Input] = Convert.ToString(0);
                        break;
                    }
                }



                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("You need to enter a number between 1 and 5");
                    Console.WriteLine("Enter command: ");
                    input = Console.ReadLine();



                }

                catch (IndexOutOfRangeException w)
                {
                    Console.WriteLine(w.Message);
                    Console.WriteLine("You need to enter a number between 1 and 5");
                    Console.WriteLine("Enter command: ");
                    input = Console.ReadLine();
                }
            }
            if (GameScoreboard.ScoreCount == 15)
            {

                ResetScoreBoard();

            }

        }

        public void InsertScoreLowerSection(string input)
        {

            while (true)
            {

                try
                {


                    int Input = Convert.ToInt32(input) - 1;

                    if (GameScoreboard.LowerSection[Input] != " ")
                    {

                        Console.WriteLine("Slot have already been assigned a value");
                        Console.WriteLine("Choose another slot");
                        input = Console.ReadLine();
                    }
                    else if (Input == 1 && GameScoreboard.LowerSection[1] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[1] = Convert.ToString(TwoHouse());
                        break;
                    }
                    else if (Input == 0 && GameScoreboard.LowerSection[0] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[0] = Convert.ToString(OneHouse());
                        break;
                    }


                    else if (Input == 2 && GameScoreboard.LowerSection[2] == " ")
                    {
                        GameScoreboard.ScoreCount++;

                        GameScoreboard.LowerSection[2] = Convert.ToString(ThreeOfAKind());
                        break;
                    }

                    else if (Input == 3 && GameScoreboard.LowerSection[3] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[3] = Convert.ToString(FourOfAKind());
                        break;
                    }
                    else if (Input == 4 && GameScoreboard.LowerSection[4] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[4] = Convert.ToString(SmallStraight());
                        break;
                    }

                    else if (Input == 5 && GameScoreboard.LowerSection[5] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[5] = Convert.ToString(LargeStraight());
                        break;
                    }

                    else if (Input == 6 && GameScoreboard.LowerSection[6] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[6] = Convert.ToString(HasHouse());
                        break;
                    }

                    else if (Input == 7 && GameScoreboard.LowerSection[7] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[7] = Convert.ToString(Chance());
                        break;
                    }
                    else if (Input == 8 && GameScoreboard.LowerSection[8] == " ")
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[8] = Convert.ToString(YatzyCombo());
                        break;
                    }

                    else
                    {
                        GameScoreboard.ScoreCount++;
                        GameScoreboard.LowerSection[Input] = Convert.ToString(0);
                        break;
                    }

                }

                catch (FormatException e)
                {



                    Console.WriteLine(e.Message);
                    Console.WriteLine("You need to enter a number between 1 and 9");
                    Console.WriteLine("Enter command: ");
                    input = Console.ReadLine();


                }

                catch (IndexOutOfRangeException w)
                {
                    Console.WriteLine(w.Message);
                    Console.WriteLine("You need to enter a number between 1 and 5");
                    Console.WriteLine("Enter command: ");
                    input = Console.ReadLine();
                }


            }

            if (GameScoreboard.ScoreCount == 15)
            {

                ResetScoreBoard();

            }
        }

        public void PrintCup()
        {
            foreach (var i in dices)
            {
                Console.WriteLine(i);
            }
        }


        public void PrintScore()
        {
            Console.WriteLine(GameScoreboard);
        }

        public override string ToString()
        {
            if (HasHouse() > 0)
            {
                Console.WriteLine($"\r\nYou have a full house! with the sum of {HasHouse()}");
            }

            if (OneHouse() > 0)
            {
                Console.WriteLine($"\r\nYou have a pair! with the sum of {OneHouse()}");
            }

            if (TwoHouse() > 0)
            {
                Console.WriteLine($"\r\nYou have two pairs! with the combined sum of {TwoHouse()}");
            }

            if (ThreeOfAKind() > 0)
            {
                Console.WriteLine($"\r\nYou have three of a kind! with the sum of {ThreeOfAKind()}");
            }

            if (FourOfAKind() > 0)
            {
                Console.WriteLine($"\r\nYou have four of a kind! with the sum of {FourOfAKind()}");
            }

            if (SmallStraight() > 0)
            {
                Console.WriteLine($"\r\nYou have a small straight! with the sum of {SmallStraight()}");
            }

            if (LargeStraight() > 0)
            {
                Console.WriteLine($"\r\nYou have a large straight! with the sum of {LargeStraight()}");
            }

            if (Chance() > 0)
            {
                Console.WriteLine($"\r\nYou have a chance! with the sum of {Chance()}");
            }

            if (YatzyCombo() > 0)
            {
                Console.WriteLine($"\r\nYou have yatzy! with the sum of {YatzyCombo()}");
            }

            return " ";


        }
    }



}



