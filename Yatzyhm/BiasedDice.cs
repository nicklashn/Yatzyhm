// ***********************************************************************
// Assembly         : Yatzyhm
// Author           : Nicklas Høj, Danni Jørgensen, Christian Holtebo, Marcus Vittrup, Kasper & Jakob Kaiser.
// Created          : 11-30-2020
//
// Last Modified By : 
// Last Modified On : 11-30-2020
// ***********************************************************************
// <copyright file="BiasedDice.cs" company="Yatzyhm">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace Yatzyhm
{

    /// <summary>
    /// This class is inherited from the Dice class.<br />
    /// This class will alter your roles.
    /// </summary>
    public class BiasedDice : Dice
    {

        /// <summary>
        /// Negative / Positive biased depends upon this attribute.
        /// </summary>
        private bool isPositive;

        /// <summary>
        /// Initializes a new instance of the <see cref="BiasedDice" /> class.
        /// </summary>
        /// <param name="isPositive">if set to <c>true</c> [is positive].</param>
        public BiasedDice(bool isPositive = true)
        {
        this.isPositive = isPositive;
        }

        /// <summary>
        /// This function is overriding its base clas, producing a biased value
        /// </summary>
        public override void Reroll()
        {
            base.Reroll();
            if (isPositive)
            {
                currentValue = (currentValue == 6) ? currentValue : currentValue + 1;
            }
            else
            {
                currentValue = (currentValue == 1) ? currentValue : currentValue - 1;
            }
        }

        /// <summary>
        /// Toggle for Positive / Negative
        /// </summary>
        public void ChangeBiased()
        {
            if (isPositive)
            {
                isPositive = false;
            }
            else
            {
                isPositive = true;
            }
        }
    }
}
