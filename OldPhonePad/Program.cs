using System;
using System.Text;

namespace OldPhonePad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = null;
            do
            {
                Console.Write("Please enter phone pad: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) // if not input any value
                {
                    break; // exit loop
                }
                
                try
                {
                    string result = OldPhonePad(input);
                    Console.WriteLine("Output: " + result);
                }
                catch (Exception ex)
                {
                    // Handle exception and show the error
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            } while (true);
        }

        public static string OldPhonePad(string input)
        {
            StringBuilder output = new StringBuilder();
            char? lastChar = null;
            int repeatCount = 0;

            foreach (char c in input)
            {
                if (c == '#')   // return output when found '#'
                {
                    return output.ToString();
                }
                else if (c == ' ')  //type two characters from the same button
                {
                    repeatCount = 0;
                }
                else if (c == '*')
                {
                    // If there's no character to remove, skip the operation
                    if (output.Length > 0)
                    {
                        output.Remove(output.Length - 1, 1);
                    }
                }
                else if (c >= '0' && c <= '9') // Only process valid input
                {
                    // If there are repeated numbers other than 0, replace them with new letters.
                    if (c == lastChar && c != '0')
                    {
                        repeatCount++;
                        output.Remove(output.Length - 1, 1);
                        output.Append(GetKey(c, repeatCount));
                    }
                    else
                    {
                        repeatCount = 0;
                        output.Append(GetKey(c, repeatCount));
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid character entered. Only digits and '*' are allowed.");
                }

                    lastChar = c;
            }

            output.Clear();
            output.Append("\"#\" will always be included at the end of every input");
            return output.ToString();
        }

        private static char GetKey(char c, int repeatCount)
        {
            // Define the mapping for the phone keypad
            string[] keypad =
            {
                " ",    // 0
                "&’(",  // 1
                "ABC",  // 2
                "DEF",  // 3
                "GHI",  // 4
                "JKL",  // 5
                "MNO",  // 6
                "PQRS", // 7
                "TUV",  // 8
                "WXYZ"  // 9
            };

            int charIndex = repeatCount % keypad[c - '0'].Length;
            return keypad[c - '0'][charIndex];
        }
    }
}