// ***********************************************************************
// Assembly         : Yatzyhm
// Author           : Nicklas Høj, Danni Jørgensen, Christian Holtebo, Marcus Vittrup, Kasper & Jakob Kaiser.
// Created          : 11-30-2020
//
// Last Modified By : 
// Last Modified On : 11-30-2020
// ***********************************************************************
// <copyright file="Roll.cs" company="Yatzyhm">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace Yatzyhm
{
    /// <summary>
    /// Class Roll.
    /// </summary>
    public class Roll
    {
        // This will be set to false when the user made their first move
        /// <summary>
        /// Gets a value indicating whether [first turn].
        /// </summary>
        /// <value><c>true</c> if [first turn]; otherwise, <c>false</c>.</value>
        public bool firstTurn { get; private set; } = true;
        /// <summary>
        /// The dices
        /// </summary>
        public readonly Dice[] Dices =
        {
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),

            // To make the BiasedDice work, uncomment the code below and vise versa

            //new Dice(),
            //new Dice(),
            //new Dice(),
            //new BiasedDice(),
            //new BiasesdDice(),
            //new BiasedDice(false)
        };

        /// <summary>
        /// Returns all dices in hand
        /// </summary>
        /// <returns><br /></returns>
        public Dice[] GetDices()
        {
            return Dices;
        }


        /// <summary>
        /// In Iterate through every dice in the toReroll aray<br />And check if it's in Dices array. If its in the array, do nothing<br />If we find a vlaue thats not equal to toReroll number, roll.
        /// </summary>
        /// <param name="toReroll">To reroll.</param>
        public void HoldDices(int[] toReroll)
        {
            
            for (int i = 0; i < Dices.Length; i++)
            {
                bool numFound = false;

                foreach (int roll in toReroll)
                {
                    if (Dices[i].currentValue == roll)
                    {
                        numFound = true;
                    }
                }
                if (numFound)
                {
                    continue;
                }
                else
                {
                    Dices[i].Reroll();
                }
            }
            ShowDices();
        }

        /// <summary>
        /// Display value of all dice.
        /// </summary>
        public void ShowDices()
        {
            Console.WriteLine();
            foreach (Dice dice in Dices)
            {
                Console.WriteLine("[{0}] ", dice.currentValue);
                firstTurn = false;
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        /// <summary>
        /// Reroll all dice.
        /// </summary>
        public void ReRollAll()
        {
            foreach (Dice dice in Dices)
            {
                dice.Reroll();
            }
            // display all the dices after the reroll
            ShowDices();
        }

        /// <summary>
        /// Set when first round is completed.
        /// </summary>
        public void SetFirstRound()
        {
            firstTurn = true;
        }
    }

}