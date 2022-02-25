// ***********************************************************************
// Assembly         : Yatzyhm
// Author           : Nicklas Høj, Danni Jørgensen, Christian Holtebo, Marcus Vittrup, Kasper & Jakob Kaiser.
// Created          : 11-30-2020
//
// Last Modified By : 
// Last Modified On : 11-30-2020
// ***********************************************************************
// <copyright file="Category.cs" company="Yatzyhm">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzyhm
{
    static class Category
    {

        /// <summary>
        /// This function is for finding the amount of occurences a given value in an array of dice.
        /// </summary>
        /// <param name="dices">The dices.</param>
        /// <param name="value">The value.</param>
        /// <returns><br /></returns>
        
        static private int GetOccurence(int[] dices, int value)
        {
            int occurence = 0;
            foreach (var item in dices)
            {
                if (item == value)
                {
                    occurence++;
                }
            }
            return occurence;
        }

        /// <summary>
        /// Overloaded function which does the same but with a List of Dice
        /// </summary>
        /// <param name="dices">dices</param>
        /// <param name="value">value</param>
        /// <returns><br /></returns>
        
        static private int GetOccurence(List<int> dices, int value)
        {
            int occurence = 0;
            foreach (var item in dices)
            {
                if (item == value)
                {
                    occurence++;
                }
            }
            return occurence;
        }
        
        /// <summary>
        /// Checks the ones.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckOnes(int[] dices)
        {
            int sum = 0;
            foreach ( var item in dices)
            {
                if (item == 1) sum += item;
            }
            return sum;
        }
        
        /// <summary>
        /// Checks the twos.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckTwos(int[] dices)
        {
            int sum = 0;
            foreach (var item in dices)
            {
                if (item == 2) sum += item;
            }
            return sum;
        }
        
        /// <summary>
        /// Checks the threes.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckThrees(int[] dices)
        {
            int sum = 0;
            foreach (var item in dices)
            {
                if (item == 3) sum += item;
            }
            return sum;
        }
        
        /// <summary>
        /// Checks the fours.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckFours(int[] dices)
        {
            int sum = 0;
            foreach (var item in dices)
            {
                if (item == 4) sum += item;
            }
            return sum;
        }
        
        /// <summary>
        /// Checks the fives.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckFives(int[] dices)
        {
            int sum = 0;
            foreach (var item in dices)
            {
                if (item == 5) sum += item;
            }
            return sum;
        }
        
        /// <summary>
        /// Checks the sixes.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckSixes(int[] dices)
        {
            int sum = 0;
            foreach (var item in dices)
            {
                if (item == 6) sum += item;
            }
            return sum;
        }
        // Lower Section:

        
        /// <summary>
        /// Checks the one pair.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckOnePair(int[] dices)
        {
            for (int i = 6; i>0; i--)
            {
                if (GetOccurence(dices, i) >= 2) return i * 2;
            }
            return 0;
        }
        
        /// <summary>
        /// Checks the two pair.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckTwoPair(int[] dices)
        {
            int value1 = -1, value2 = -1;
            int sum = 0;
            bool found = false;

            // For single pair
            for ( int i = 0; i < dices.Length; i++)
            {
                for (int j = 0; j < dices.Length; j++)
                {
                    if (i == j) continue;
                    if(dices[i] == dices[j])
                    {
                        sum += dices[i] * 2;
                        value1 = i;
                        value2 = j;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
            if (value1 == -1) return 0;
            found = false;

            // for another pair
            for ( int i = 0; i< dices.Length; i++)
            {
                for ( int j = 0; j < dices.Length; j++)
                {
                    if (i == j) continue;
                    if (i == value1 || j == value1 || i == value2 || j == value2) continue;
                    if (dices[i] == dices[j])
                    {
                        sum += dices[i] * 2;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
            if (found) return sum;
            else return 0;
        }

        // Three of a kind: Three dice showing the same number. Score: Sum of those threedice.
        /// <summary>
        /// Checks the kind of the three of a.
        /// </summary>
        /// <param name="dices">The dices.</param>
        static public int CheckThreeOfAKind(int[] dices)
        {
            for ( int i = 6; i > 0; i--)
            {
                if (GetOccurence(dices, i) >= 3) return i * 3;
            }
            return 0;
        }

        //Four of a kind: Four dice with the same number. Score: Sum of those four dice.
        /// <summary>
        /// Checks the kind of the four of a.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckFourOfAKind(int[] dices)
        {
            for (int i = 6; i > 0; i--)
            {
                if (GetOccurence(dices, i) >= 4) return i * 4;
            }
            return 0;
        }

        //Yatzy: All six dice with same number. Score: Sum of those six dice.
        /// <summary>
        /// Checks the yatzy.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckYatzy(int[] dices)
        {
            for ( int i = 6; i > 0; i--)
            {
                if (GetOccurence(dices, i) == 6) return i * 6;
            }
            return 0;
        }

        // Small Straight: Combination 1-2-3-4-5. Score: 15, sum of the dice.
        /// <summary>
        /// Checks the small straight.
        /// </summary>
        /// <param name="dices">The dices.</param>
        static public int CheckSmallStraight(int[] dices)
        {

            if (dices.Contains(1) && dices.Contains(2) && dices.Contains(3) && dices.Contains(4) && dices.Contains(5))
            {
                return 15;
            }
            else
            {
                return 0;
            }
        }

        // Large Straight: Combination 2-3-4-5-6. Score: 20, sum of the dice.
        /// <summary>
        /// Checks the large straight.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckLargeStraight(int[] dices)
        {
            if (dices.Contains(2) && dices.Contains(3) && dices.Contains(4) && dices.Contains(5) && dices.Contains(6))
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Checks the full house.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckFullHouse(int[] dices)
        {
            List<int> diceList = dices.ToList();
            diceList.Sort();
            int sum = 0;
            bool found = false;

            // For a single pair
            for (int i = 0; i < dices.Length; i++)
            {
                for (int j = 0; j < dices.Length; j++)
                {
                    if (i == j) continue;
                    if (dices[i] == dices[j])
                    {
                        sum += dices[i] * 2;
                        diceList[i] = -1;
                        diceList[j] = -1;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
            diceList.Remove(-1);
            found = false;

            // for a set of three
            for (int i = 6; i> 0; i--)
            {
                if (GetOccurence(diceList, i) >= 3)
                {
                    sum += i * 3;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                return sum;
            }
            return 0;
        }

        // Chance: Any combination of dice. Score: Sum of all dice.
        /// <summary>
        /// Checks the chance.
        /// </summary>
        /// <param name="dices">The dices.</param>
        
        static public int CheckChance(int[] dices)
        {
            int sum = 0;
            foreach ( var item in dices)
            {
                sum += item;
            }
            return sum;
        }
    } 
}
