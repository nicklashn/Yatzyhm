// ***********************************************************************
// Assembly         : Yatzyhm
// Author           : Nicklas Høj, Danni Jørgensen, Christian Holtebo, Marcus Vittrup, Kasper & Jakob Kaiser.
// Created          : 11-30-2020
//
// Last Modified By : 
// Last Modified On : 11-30-2020
// ***********************************************************************
// <copyright file="Dice.cs" company="Yatzyhm">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace Yatzyhm
{
    // This dice class will is the one representing the single dice.
    public class Dice
    {
        // static random so every dice object can use it.
        private static readonly Random rnd = new Random();
        // attribute to hold dice current value(s)
        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        /// <value>The current value.</value>
        public int currentValue { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dice"/> class.
        /// </summary>
        public Dice()
        {
            currentValue = rnd.Next(1, 7);
        }

        /// <summary>
        /// Changes the current dice value. Can be overriden
        /// </summary>
        public virtual void Reroll()
        {
            currentValue = rnd.Next(1, 7);
        }
    }
}
