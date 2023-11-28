using System;
using System.Threading;

namespace DASTRU_Final_NatworkingProject.Extensions
{
    public enum Align
    {
        Left,
        Center,
        Right
    }

    public static class ConsoleWriter
    {
        /// <summary>
        /// Indicates whether the typewriter mode is enabled.
        /// </summary>
        /// <value>True if the typewriter mode is enabled, false otherwise.</value>
        /// <remarks>
        /// The `IsTypeWriterMode` property determines whether the `TypeWrite()` and `TypeWriteLine()` methods simulate the typing of text on a typewriter. When this property is set to true, these methods introduce a randomized delay between each character being written to the console.
        /// </remarks>
        public static bool IsTypeWriterMode = false;

        /// <summary>
        /// Specifies the speed of the typewriter effect in milliseconds.
        /// </summary>
        /// <value>The delay duration in milliseconds between each character being typed.</value>
        /// <remarks>
        /// The `TypeWriterSpeed` property controls the delay between each character being written to the console when the typewriter mode is enabled. A higher value increases the delay, simulating slower typing, while a lower value decreases the delay, simulating faster typing.
        /// </remarks>
        public static int TypeWriterSpeed = 2;

        /// <summary>
        /// Writes the specified value to the console with the specified foreground and background colors.
        /// </summary>
        /// <param name="value">The value to write to the console.</param>
        /// <param name="foregroundColor">The color of the text. The default value is White.</param>
        /// <param name="backgroundColor">The color of the background. The default value is Black.</param>
        /// <remarks>
        /// This method writes the specified value to the console, sets the foreground and background colors, and then resets the colors to the default values.
        /// </remarks>
        public static void Write(string value, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            TypeWrite(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes the specified value followed by a newline to the console with the specified foreground and background colors.
        /// </summary>
        /// <param name="value">The value to write to the console.</param>
        /// <param name="foregroundColor">The color of the text. The default value is White.</param>
        /// <param name="backgroundColor">The color of the background. The default value is Black.</param>
        /// <remarks>
        /// This method writes the specified value to the console, sets the foreground and background colors, and then resets the colors to the default values. It also appends a newline character after the written value.
        /// </remarks>
        public static void WriteLine(string value, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            TypeWriteLine(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes a column of text to the console with the specified alignment, maximum character width, and foreground and background colors.
        /// </summary>
        /// <param name="values">An array of strings to be displayed in the column.</param>
        /// <param name="align">The alignment of the text within the column. The default value is Align.Left.</param>
        /// <param name="maxChar">The maximum width of each column in characters. The default value is 8.</param>
        /// <param name="foregroundColor">The color of the text. The default value is ConsoleColor.White.</param>
        /// <param name="backgroundColor">The color of the background. The default value is ConsoleColor.Black.</param>
        /// <remarks>
        /// This method formats the provided text into a visually appealing column, taking into account the specified alignment, maximum character width, and foreground and background colors.
        /// </remarks>
        public static void WriteColumn(
            string[] values, 
            Align align = Align.Left, 
            int maxChar = 8, 
            ConsoleColor foregroundColor = ConsoleColor.White, 
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            foreach (var value in values)
            {
                int withOneSpace = (maxChar - value.Length) % 2;
                int spacesAll = (maxChar - value.Length);
                int spaceLeftAndRight = spacesAll / 2;

                string spaces = "";
                string oneSpace = "";

                for (int i = 0; i < spaceLeftAndRight; i++)
                    spaces += " ";
                if (withOneSpace == 1) oneSpace = " ";

                string left = "";
                string right = "";

                if (align == Align.Left)
                {
                    left = "";
                    right = spaces + spaces + oneSpace;
                }
                else if (align == Align.Right)
                {
                    left = spaces + spaces + oneSpace;
                    right = "";
                }
                else if (align == Align.Center)
                {
                    left = spaces;
                    right = spaces + oneSpace;
                }

                TypeWrite($"|{left}{value}{right}");
            }
            Console.WriteLine("|");
            Console.ResetColor();
        }

        /// <summary>
        /// Writes the specified string to the console with a typewriter-like effect, simulating the delay between each character being typed.
        /// </summary>
        /// <param name="value">The string to write to the console.</param>
        /// <remarks>
        /// This method simulates the typing of text on a typewriter by introducing a randomized delay between each character being written to the console. The delay duration is controlled by the `TypeWriterSpeed` property.
        /// </remarks>
        public static void TypeWrite(string value)
        {
            int ms = TypeWriterSpeed;
            if (!IsTypeWriterMode)
            {
                Console.Write(value);
                return;
            }

            Random rand = new Random();
            foreach (var ch in value.ToCharArray())
            {
                Thread.Sleep(rand.Next(ms));
                Console.Write(ch);
            }
        }

        /// <summary>
        /// Writes the specified string followed by a newline to the console with a typewriter-like effect, simulating the delay between each character being typed and appending a newline character after the written text.
        /// </summary>
        /// <param name="value">The string to write to the console.</param>
        /// <remarks>
        /// This method simulates the typing of text on a typewriter by introducing a randomized delay between each character being written to the console and appending a newline character after the written text. The delay duration is controlled by the `TypeWriterSpeed` property.
        /// </remarks>
        public static void TypeWriteLine(string value)
        {
            int ms = TypeWriterSpeed;
            if (!IsTypeWriterMode)
            {
                Console.WriteLine(value);
                return;
            }

            Random rand = new Random();
            foreach (var ch in value.ToCharArray())
            {
                Thread.Sleep(rand.Next(ms));
                Console.Write(ch);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Writes a centered header to the console with the specified foreground and background colors, maximum character width, and border style.
        /// </summary>
        /// <param name="value">The header text to display.</param>
        /// <param name="foregroundColor">The color of the header text. The default value is ConsoleColor.DarkYellow.</param>
        /// <param name="backgroundColor">The color of the header background. The default value is ConsoleColor.Black.</param>
        /// <param name="maxChar">The maximum width of the header in characters. The default value is 42.</param>
        /// <param name="border">The border style to use around the header. The default value is "═".</param>
        /// <remarks>
        /// This method creates a visually appealing header by centering the text, applying the specified foreground and background colors, and drawing a border around the header using the provided border style.
        /// </remarks>
        public static void WriteHeader(
            string value,
            ConsoleColor foregroundColor = ConsoleColor.DarkYellow,
            ConsoleColor backgroundColor = ConsoleColor.Black,
            int maxChar = 42, 
            string border = "═")
        {
            int totalNoOfSpaces = (maxChar - value.Length);
            int withOneSpace = totalNoOfSpaces % 2;
            int spaceLeftAndRight = totalNoOfSpaces / 2;

            string spaces = "";
            string oneSpace = "";
            string headerBorder = "";

            for (int i = 0; i < spaceLeftAndRight; i++) 
                spaces += " ";
            for (int i = 0; i < maxChar; i++)
                headerBorder += border;
            if (withOneSpace == 1) oneSpace = " ";

            Console.Clear();
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine($"╔{headerBorder}╗");
            Console.WriteLine($"║{spaces}{value}{spaces}{oneSpace}║");
            Console.WriteLine($"╚{headerBorder}╝");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an error message to the console with a red background and prompts the user to press any key to continue.
        /// </summary>
        /// <param name="value">The error message to display.</param>
        /// <remarks>
        /// This method clears the console, displays a header with a red background indicating an error, presents the error message in red text, and prompts the user to press any key to continue.
        /// </remarks>
        public static void WriteError(string value)
        {
            Console.Clear();
            WriteHeader("Oops! Error 404!", ConsoleColor.DarkRed);

            WriteLine($"Error Message: {value}", ConsoleColor.Red);

            WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Reads a line of input from the console and returns the input string.
        /// </summary>
        /// <param name="color">The color of the text prompt. The default value is ConsoleColor.White.</param>
        /// <returns>The input string entered by the user.</returns>
        /// <remarks>
        /// This method prompts the user for input with the specified text color, reads the input line, and returns the input string. The method resets the console color to the default value after reading the input.
        /// </remarks>
        public static string ReadLine(ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            string input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }
    }
}
