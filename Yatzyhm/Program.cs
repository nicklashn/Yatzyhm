// ***********************************************************************
// Assembly         : Yatzyhm
// Author           : Nicklas Høj, Danni Jørgensen, Christian Holtebo, Marcus Vittrup, Kasper & Jakob Kaiser.
// Created          : 11-30-2020
//
// Last Modified By : 
// Last Modified On : 11-30-2020
// ***********************************************************************
// <copyright file="Program.cs" company="Yatzyhm">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>This program is for GOOP exam for BAIT 3. Authors is seen at the top. The game is built around how we see a game of yatzy and how structural a program can be even for a simple game
// The program have different classes which more or less can be refined as the props in a real game of yatzy, Dice, Roll, category(scoreboard) e.g.
// </summary>
// ***********************************************************************
using System;

namespace Yatzyhm
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            // Run game
            
            var yatzy = new Yatzy();
            yatzy.WelcomeMsg();
            yatzy.Game();
        }
    }
}
