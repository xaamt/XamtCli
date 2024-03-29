﻿using System;
using System.IO;
using System.Reflection;

namespace XamtCli
{
    /// <summary>
    /// Console Output Helper
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Write Application Log
        /// </summary>
        public static void WriteLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            var logoText = @"
               _  _____   __  _________  _______   ____
              | |/_/ _ | /  |/  /_  __/ / ___/ /  /  _/
             _>  </ __ |/ /|_/ / / /   / /__/ /___/ /  
            /_/|_/_/ |_/_/  /_/ /_/    \___/____/___/";

            Console.WriteLine(logoText);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("XAMT CLI, Copyright (C) XAMT Professionals. All rights reserved.");
            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Write Application Version
        /// </summary>
        public static void WriteVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "No Version";
            var location = Directory.GetCurrentDirectory();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Version: {version}");
            Console.WriteLine($"Path: {location}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"_________________________________________________________________________");
            Console.ResetColor();
        }

        /// <summary>
        /// Get User Input
        /// </summary>
        /// <returns></returns>
        public static string GetInput()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(">> ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        /// <summary>
        /// Write a line with color
        /// </summary>
        /// <param name="value">plain text</param>
        /// <param name="color">foreground color</param>
        public static void WriteLine(string value, ConsoleColor color = ConsoleColor.Gray, bool withoutTime = false)
        {
            Console.ForegroundColor = color;
            if (withoutTime)
            {
                Console.WriteLine($"{value}");
            }
            else
            {
                Console.WriteLine($"{DateTime.Now:HH:mm:ss} => {value}");
            }
            
            Console.ResetColor();
        }

        /// <summary>
        /// Write a text with color
        /// </summary>
        /// <param name="value">plain text</param>
        /// <param name="color">foreground color</param>
        public static void Write(string value, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write($"{value}");
            Console.ResetColor();
        }

        /// <summary>
        /// Write Title Line
        /// </summary>
        /// <param name="value"></param>
        public static void WriteTitle(string value, bool withoutTime = false) => WriteLine(value, ConsoleColor.Cyan, withoutTime);

        /// <summary>
        /// Write Info Line
        /// </summary>
        /// <param name="value"></param>
        public static void WriteInfo(string value, bool withoutTime = false) => WriteLine(value, ConsoleColor.DarkYellow, withoutTime);

        /// <summary>
        /// Write Info2 Line
        /// </summary>
        /// <param name="value"></param>
        public static void WriteInfo2(string value, bool withoutTime = false) => WriteLine(value, ConsoleColor.Yellow, withoutTime);

        /// <summary>
        /// Write Success Line
        /// </summary>
        /// <param name="value"></param>
        public static void WriteSuccess(string value, bool withoutTime = false) => WriteLine(value, ConsoleColor.Green, withoutTime);

        /// <summary>
        /// Write Error Line
        /// </summary>
        /// <param name="value"></param>
        public static void WriteError(string value, bool withoutTime = false) => WriteLine(value, ConsoleColor.Red, withoutTime);

    }
}
