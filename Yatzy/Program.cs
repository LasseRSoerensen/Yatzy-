using System;
namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {

            bool gameState = true;

            //UserInput() --> function that takes input from the user 
            static string UserInput()
            {
                Console.WriteLine("\r\n Enter command: ");
                return Console.ReadLine();
            }

            //Mainmenu
            while (gameState)
            {
                Console.Clear();
                Console.WriteLine("Main menu");
                Console.WriteLine("1) Start game");
                Console.WriteLine("2) Test dice");

                switch (UserInput())
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        EvaluateDice();
                        break;
                    default:
                        break;
                }

            }

            //StartGame() --> section that starts and encapsulates the yatzy game
            static bool StartGame()
            {
                Console.Clear();
                int rollCount = 0;
                var Cup  = new Yatzy();
                var testScoreboard = new Scoreboard();
                bool SelectCount = false;

                void SelectDice()
                {

                    Console.WriteLine("enter the number of the dice you want to keep");
                    Cup.KeepV2(UserInput());
                    Console.Clear();
                    Cup.PrintCup();
                    Cup.InsertDiceValueInArray();
                    Console.WriteLine(Cup);

                } 

                void SeeNumberOf()
                {
                    Console.WriteLine("Type a number to see how many of the dices holds that value as a current");
                    Cup.NumberOf(Convert.ToInt32(UserInput()));
                }

                void InsertScore()
                {
                    Console.WriteLine("Choose which section you want to score");
                    Console.WriteLine("\r\n1) Upper section");
                    Console.WriteLine("2) Lower section");
                    while (true)
                    {


                        switch (UserInput())
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Choose which slot to score");
                                Console.WriteLine("\r\n1) Ones");
                                Console.WriteLine("2) Twos");
                                Console.WriteLine("3) Threes");
                                Console.WriteLine("4) Fours");
                                Console.WriteLine("5) Fives");
                                Console.WriteLine("6) Sixes");
                                Cup.InsertScoreUpperSection(UserInput());
                                SelectCount = true;

                                break;
                            case "2":
                                Console.Clear();
                                Console.WriteLine("Choose Which slot to score");
                                Console.WriteLine("\r\n1) One pair");
                                Console.WriteLine("2) Two pairs");
                                Console.WriteLine("3) Three of a Kind");
                                Console.WriteLine("4) Four of a Kind");
                                Console.WriteLine("5) Small Straight");
                                Console.WriteLine("6) Large Straight");
                                Console.WriteLine("7) Full House");
                                Console.WriteLine("8) Chance");
                                Console.WriteLine("9) Yatzy");
                                Cup.InsertScoreLowerSection(UserInput());
                                SelectCount = true;
                                break;
                            default:
                                break;
                        }

                        if (SelectCount == true)
                        {
                            SelectCount = false;
                            break;
                        }
                    }


                }

                void PrintScoreboard()
                {
                    Cup.PrintScore();
                }


                void userRoll()
                {
                    if (rollCount < 3)
                    {
                        Console.Clear();
                        Cup.Roll();
                        Cup.InsertDiceValueInArray();
                        rollCount++;


                        if (rollCount == 3)
                        {
                            Console.WriteLine("\r\nYou have used your rolls, select which slot to score");
                            Console.WriteLine("Change which to keep, or score straight away");
                            Console.WriteLine("e) Choose dices");
                            Console.WriteLine("s) Go to scoreboard");

                            while (true)
                            {
                                switch (UserInput())
                                {
                                    case "e":
                                        SelectDice();
                                        Cup.InsertDiceValueInArray();
                                        break;
                                    case "s":
                                        InsertScore();
                                        SelectCount = true;
                                        break;
                                    default:
                                        Console.WriteLine("You have to insert score in the scoreboard");
                                        break;
                                }

                                if (SelectCount == true)
                                {
                                    SelectCount = false;
                                    break;

                                }
                            }

                            rollCount = 0;
                            Cup.ResetKeep();

                        }


                    }


                }

                while (true)
                {


                    if (rollCount <= 3)
                    {
                        Console.WriteLine($"\r\nRound {rollCount}");
                        Console.WriteLine("e) Choose dices");
                        Console.WriteLine("r) Shake cup");
                        Console.WriteLine("4) Scoreboard");
                        Console.WriteLine("5) numberOf function");
                    }

                    QuitToMenu();



                    switch (UserInput())
                    {
                        case "r":
                            userRoll();
                            break;
                        case "e":
                            SelectDice();
                            break;
                        case "quit":
                            return false;
                        case "3":
                            Cup.PrintDiceVal();
                            break;
                        case "4":
                            PrintScoreboard();
                            break;
                        case "5":
                            SeeNumberOf();
                            break;
                        default:
                            break;
                    }



                }
            }


            //EvaluateDice() --> Section that evalutes the fairness of the dice
            static bool EvaluateDice()
            {
                Console.Clear();
                var testDice = new Dice();

                while (true)
                {
                    Console.WriteLine("\r\nHit 'enter' to roll the dice");
                    QuitToMenu();

                    switch (UserInput())
                    {
                        case "quit":
                            return false;
                        default:
                            Console.Clear();
                            testDice.diceRolledPercentage(100);
                            break;
                    }


                }
            }


            static void QuitToMenu()
            {
                Console.WriteLine("\r\nType 'quit' to exit to menu");
            }

        }






    }
}



