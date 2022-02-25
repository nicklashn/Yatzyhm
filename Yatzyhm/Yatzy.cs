// ***********************************************************************
// Assembly         : Yatzyhm
// Author           : Nicklas Høj, Danni Jørgensen, Christian Holtebo, Marcus Vittrup, Kasper & Jakob Kaiser.
// Created          : 11-30-2020
//
// Last Modified By : 
// Last Modified On : 11-30-2020
// ***********************************************************************
// <copyright file="Yatzy.cs" company="Yatzyhm">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>
// 
//</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Yatzyhm
{
    /// <summary>
    /// This function display a formatted scoreboard.
    /// </summary>
    public class Yatzy
    {
        /// <summary>
        /// The default rolls
        /// </summary>
        private static int DEFAULT_ROLLS = 3; // default rolls per turn.
        /// <summary>
        /// The bonus
        /// </summary>
        public int bonus = 0; // default bonus unless you hit the target score.
        /// <summary>
        /// Gets the roll.
        /// </summary>
        /// <value>The roll.</value>
        public Roll roll { get; private set; } = new Roll();
        /// <summary>
        /// The rounds left
        /// </summary>
        int roundsLeft = 15; // number of roudns per game.
        /// <summary>
        /// The choice
        /// </summary>
        private int Choice; // variable to get input from the user.
        /// <summary>
        /// The game running
        /// </summary>
        private bool GameRunning = false; // To stop the game or start it.
        /// <summary>
        /// The rolls
        /// </summary>
        private int rolls = DEFAULT_ROLLS; // Number of rolls per turn can be change. default at start
        /// <summary>
        /// The scoreboard
        /// </summary>
        private Dictionary<string, int> scoreboard = new Dictionary<string, int>() // scoreboard for categories
        {
            { "Ones", 0},
            { "Twos", 0},
            { "Threes", 0},
            { "Fours", 0},
            { "Fives", 0},
            { "Sixes", 0},
            { "One Pair", 0},
            { "Two Pairs", 0},
            { "Three of a Kind", 0},
            { "Four of a Kind", 0},
            { "Small Straight", 0},
            { "Large Straight", 0},
            { "Full House", 0},
            { "Chance", 0},
            { "Yatzy", 0},
        };

        /// <summary>
        /// Games this instance.
        /// </summary>
        public void Game()
        {
            // run as long as the user wants it to.
            while (true)
            {
                // Choose an option
                Console.WriteLine("Please choose an option");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Change Rolls per round");
                Console.WriteLine("0. Quit Game");
                Console.WriteLine("\nEnter Choice: ");

                //Invalid input
                while (!int.TryParse(Console.ReadLine(), out Choice))
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid input. Please try again");

                    Console.WriteLine("Please choose an option: ");
                    Console.WriteLine("1. Start Game");
                    Console.WriteLine("2. Change Rolls per Round");
                    Console.WriteLine("0. Quit Game");
                    Console.WriteLine("\n Enter chocie: ");
                }
                Console.Clear();
                if (Choice == 1)
                {
                    GameRunning = true;
                    while (GameRunning && roundsLeft >= 0)
                    {
                        //give bonus if the user scores 63 or above in the upper section
                        if (roundsLeft == 9 && GetTotalScore() >= 63)
                        {
                            Console.WriteLine("\n50 bonus points has been added.\n");
                            bonus = 50;
                        }
                        string section = (roundsLeft > 9) ? "Upper Section" : "lower Section";
                        // Display info
                        Console.WriteLine("\n" + section + "\tRemaining Tries: " + rolls + "\t Rounds Left: " + roundsLeft);

                        //Menu
                        Console.WriteLine("\nPlease choose an option: \n");
                        Console.WriteLine("1. Roll Dice");
                        Console.WriteLine("2. Show Score");

                        if (!roll.firstTurn) // only visible when the first roll round is completed.
                        {
                            Console.WriteLine("3. Hold Dices");
                            Console.WriteLine("4. Choose a Category");
                        }
                        Console.WriteLine("0. Quit Game");
                        Console.Write("\n Enter choice: ");

                        // Invalid Input
                        while (!int.TryParse(Console.ReadLine(), out Choice))
                        {
                            Console.Clear();
                            Console.WriteLine("\n Invalid input. Try again.");
                            //Display info
                            Console.WriteLine("\n Remaining Tries: " + rolls + "\t" + "Rounds left: " + roundsLeft);
                            Console.WriteLine("\n Please choose an option: \n");
                            Console.WriteLine("1. Roll Dice");
                            Console.WriteLine("2. Show Score");
                            if (!roll.firstTurn) // only visible when first roll is completed.
                            {
                                Console.WriteLine("3. Hold Dices");
                                Console.WriteLine("4. Choose a Category");
                            }
                            Console.WriteLine("0. Quit Game");
                            Console.WriteLine("\nEnter Choice: ");
                        }
                        Console.Clear();
                        switch (Choice)
                        {
                            // Quit game.
                            case 0:
                                GameRunning = false;
                                break;

                            // only roll if the rolls per turn is remaining
                            case 1:
                                if (hasRemainingTries() == false)
                                {
                                    Console.WriteLine("\nNo rolls left. Choose a category\n");
                                    Console.Write("Your last throw: ");
                                    roll.ShowDices();
                                }
                                else
                                {
                                    roll.ReRollAll();
                                    rolls--;
                                }
                                break;
                            // display of scoreboard.
                            case 2:
                                Console.WriteLine("\n Remaining tries: " + rolls + "\t" + "Rounds left: " + roundsLeft);
                                DisplayScore();
                                Console.Clear();
                                break;

                            // allowance for the user to hold dice.
                            case 3:
                                if (!roll.firstTurn && hasRemainingTries())
                                {
                                    roll.HoldDices(AskUserForDices());
                                }
                                else if (roll.firstTurn)
                                {
                                    Console.WriteLine("Invalid Choice");
                                }
                                else
                                {
                                    Console.WriteLine("\nNo rolls left. Choose a category");
                                    Console.WriteLine("Your last throw: ");
                                    roll.ShowDices();
                                }
                                break;

                            //allowance for the user to choose a category
                            case 4:
                                if (!roll.firstTurn)
                                {
                                    Console.Clear();
                                    ChooseCategory();
                                    rolls = DEFAULT_ROLLS;
                                    roundsLeft--;
                                    roll.SetFirstRound();
                                }
                                else
                                    Console.WriteLine("Invalid Choice");
                                break;
                                // Invalid Input
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                    }
                    if (roundsLeft < 0) DisplayScore();
                    Console.Clear();
                    ResetScore();
                    bonus = 0;
                    rolls = DEFAULT_ROLLS;
                    roundsLeft = 15;
                    roll.SetFirstRound();
                }
                // change number of rolls per turn.
                else if (Choice == 2)
                {
                    Console.WriteLine("\n Set a number between 2-10: ");
                    int defaultRoll = 3;
                    if (int.TryParse(Console.ReadLine(), out defaultRoll) && defaultRoll > 2 && defaultRoll < 10)
                    {
                        rolls = DEFAULT_ROLLS = defaultRoll;
                        Console.Clear();
                        Console.WriteLine("\n number of roll per turn has been set to " + defaultRoll + ".\n");
                    }
                    else // if value is invalid. Set rolls to default
                    {
                        rolls = DEFAULT_ROLLS = 3;
                        Console.Clear();
                        Console.WriteLine("Invalid input. Number of roll per turn has been set to " + DEFAULT_ROLLS + "(Default).\n");

                    }
                }
                //Quit application.
                else if (Choice == 0)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// This function allows the user to choose a category to achieve score, based on the dice value.
        /// User has a choice to check and select the most desired category.
        /// </summary>
        private void ChooseCategory()
        {
            // Initializing defaults.
            int sum;
            string choice;
            Dice[] dice = roll.GetDices();
            int[] dices = new int[dice.Length];

            // storing numbersof dice in array
            for (int i = 0; i < dice.Length; i++)
            {
                dices[i] = dice[i].currentValue;
            }
            while (true)
            {
                //Upper section
                if (roundsLeft > 9)
                {
                    roll.ShowDices();
                    Console.WriteLine("\nUpper Section\n");
                    Console.WriteLine("1. Ones");
                    Console.WriteLine("2. Twos");
                    Console.WriteLine("3. Threes");
                    Console.WriteLine("4. Fours");
                    Console.WriteLine("5. Fives");
                    Console.WriteLine("6. Sixes");
                    Console.WriteLine("\nYour choice: ");
                    choice = Console.ReadLine();
                    // Select Ones
                    if (choice == "1")
                    {
                        sum = Category.CheckOnes(dices);
                        scoreboard["Ones"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points have been added to Ones.\n");
                        break;
                    }
                    // Select twos
                    else if (choice == "2")
                    {
                        sum = Category.CheckTwos(dices);
                        scoreboard["Twos"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points have been added to Twos.\n");
                        break;
                    }
                    // Select Threes
                    else if (choice == "3")
                    {
                        sum = Category.CheckThrees(dices);
                        scoreboard["Threes"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points have been added to Threes.\n");
                        break;
                    }
                    // Select Fours
                    else if (choice == "4")
                    {
                        sum = Category.CheckFours(dices);
                        scoreboard["Fours"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points have been added to Fours.\n");
                        break;
                    }
                    // Select twos
                    else if (choice == "5")
                    {
                        sum = Category.CheckFives(dices);
                        scoreboard["Fives"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points have been added to Fives.\n");
                        break;
                    }
                    // Select twos
                    else if (choice == "6")
                    {
                        sum = Category.CheckSixes(dices);
                        scoreboard["Sixes"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points have been added to Sixes.\n");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n Invalid Choice\n");
                    }
                }
                else
                {
                    // Lower Section
                    roll.ShowDices();
                    Console.WriteLine("\n Lower Section \n");
                    Console.WriteLine("1. One Pair");
                    Console.WriteLine("2. Two Pairs");
                    Console.WriteLine("3. Three of a kind");
                    Console.WriteLine("4. Four of a kind");
                    Console.WriteLine("5. Small straight");
                    Console.WriteLine("6. Large Straight");
                    Console.WriteLine("7. Full house");
                    Console.WriteLine("8. Chance");
                    Console.WriteLine("9. Yatzy");
                    Console.WriteLine("\nYour Choice :");
                    choice = Console.ReadLine();
                    // Select One Pair
                    if ( choice == "1")
                    {
                        sum = Category.CheckOnePair(dices);
                        scoreboard["One Pair"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to One Pair.\n");
                        break;
                    }
                    // Select Two Pair
                    else if (choice == "2")
                    {
                        sum = Category.CheckTwoPair(dices);
                        scoreboard["Two Pairs"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to Two pair.\n");
                        break;
                    }
                    // Three of a Kind
                    else if (choice == "3")
                    {
                        sum = Category.CheckThreeOfAKind(dices);
                        scoreboard["Three of a Kind"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to Three of a kind.\n");
                        break;
                    }
                    // Four of a Kind
                    else if (choice == "4")
                    {
                        sum = Category.CheckFourOfAKind(dices);
                        scoreboard["Four of a Kind"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to Four of a kind.\n");
                        break;
                    }
                    // Small Straight
                    else if (choice == "5")
                    {
                        sum = Category.CheckSmallStraight(dices);
                        scoreboard["Small Straight"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to Small straight.\n");
                        break;
                    }
                    // Large Straight
                    else if (choice == "6")
                    {
                        sum = Category.CheckFullHouse(dices);
                        scoreboard["Large Straight"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to Large straight.\n");
                        break;
                    }
                    // Full House
                    else if (choice == "7")
                    {
                        sum = Category.CheckTwoPair(dices);
                        scoreboard["Full House"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to Full House.\n");
                        break;
                    }
                    // Chance
                    else if (choice == "8")
                    {
                        sum = Category.CheckChance(dices);
                        scoreboard["Chance"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to Chance.\n");
                        break;
                    }
                    // Yatzy
                    else if (choice == "9")
                    {
                        sum = Category.CheckYatzy(dices);
                        scoreboard["Yatzy"] += sum;
                        Console.Clear();
                        Console.WriteLine("\n" + sum + " points has been added to One Pair.\n");
                        break;
                    }
                    // Invalid input
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nInvalid Choice");
                    }
                }
            }
        }

        /// <summary>
        /// This function is used to hold the dices, so that only unselected dices will roll per turn.
        /// multiple dices = commas between values.
        /// </summary>
        /// <returns><br /></returns>
        private int[] AskUserForDices()
        {
            roll.ShowDices();
            Console.WriteLine("Enter the numbers like: 1,2,3,4 accordingly to which dice you want to hold: ");
            string userinput = Console.ReadLine();
            Console.Clear();
            string[] chosenDices = userinput.Split(',');
            int[] toReroll = new int[chosenDices.Length];
            for ( int i = 0; i < chosenDices.Length; i++)
            {
                toReroll[i] = int.Parse(chosenDices[i]);
            }
            rolls--;
            return toReroll;
        }

        /// <summary>
        /// This function display a formatted scoreboard
        /// </summary>
        private void DisplayScore()
        {
            Console.WriteLine("\n\tCategories\t\tSelected\tScore");
            Console.WriteLine("\n\tUpper section\n");
            foreach ( string category in scoreboard.Keys)
            {
                if (category == "One Pair") Console.WriteLine("\n\t Lower Section\n");
                if (category.Length > 6)
                {
                    Console.WriteLine("\t" + category + "\t\t" + (scoreboard[category] != 0).ToString() + "\t\t" + scoreboard[category]);
                }
                else
                {
                    Console.WriteLine("\t" + category + "\t\t" + (scoreboard[category] != 0).ToString() + "\t\t" + scoreboard[category]);
                }
            }
            Console.WriteLine("\n\tBonus\t\t\t\t\t" + bonus);
            Console.WriteLine("\n\tTotal\t\t\t\t\t" + Convert.ToInt32(GetTotalScore() + bonus).ToString() + "\n");

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// This function returns the total score.
        /// </summary>
        /// <returns><br /></returns>
        private int GetTotalScore()
        {
            int sum = 0;
            foreach ( string category in scoreboard.Keys)
            {
                sum += scoreboard[category];
            }
            return sum;
        }

        /// <summary>
        /// This function resets the score
        /// </summary>
        private void ResetScore()
        {
            List<string> categories = new List<string>(scoreboard.Keys);
            foreach (string category in categories)
            {
                scoreboard[category] = 0;
            }
        }
        /// <summary>
        /// Determines whether [has remaining tries].
        /// </summary>
        /// <returns><c>true</c> if [has remaining tries]; otherwise, <c>false</c>.</returns>
        private bool hasRemainingTries()
        {
            return rolls > 0;
        }
        /// <summary>
        /// A welcome message to the player.
        /// </summary>
        public void WelcomeMsg()
        {
            Console.WriteLine("Hi. Welcome to a game of Yatzy developed by:\nNicklas Høj, Danni Jørgensen, Christian Holtebo, Marcus Vittrup, Kasper & Jakob Kaiser.");
            Console.WriteLine("To start off with. Let's go through some rules.");
            Console.WriteLine("There will be 2 different sections. Upper section, and Lower section.");
            Console.WriteLine("The upper section will consists of 1 - 2 - 3 - 4 - 5 - 6 of a kind. E.g if you roll 3, threes. You get 9 points.");
            Console.WriteLine("The lower section conists of different outcomes. There are:");
            Console.WriteLine("1 pair, 2 pairs, Three of a kind, Four of a kind, Small straight, Large straight, Full house, Chance and Yatzy");
            Console.WriteLine("You have the ability to hold the dices e.g. if you are in lower section \nAnd you need to get a full house and you rolled 3 threes. Then you have the ability to hold them \nAnd roll x more times for a chance of Full house");
            Console.WriteLine("Are you ready to play? \n( Press any key... )");
            Console.ReadKey();
            Console.Clear();
        }
    }
}