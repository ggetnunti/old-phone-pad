using System;
using System.Text;

namespace OldPhonePad
{
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine("Output: " + OldPhonePad(input));
            } while (true);
        }

        public static string OldPhonePad(string input)
        {
            StringBuilder output = new StringBuilder();
            char? lastChar = null;
            int letterRepeatCount = 0;

            foreach (char c in input)
            {
                if (c == '#')   // return output when found '#'
                {
                    return output.ToString();
                }
                else if (c == ' ')
                {
                    letterRepeatCount = 0;
                }
                else if (c == '*')
                {
                    output.Remove(output.Length - 1, 1);  // delete last char
                }
                else if (c == lastChar)
                {
                    letterRepeatCount++;
                    output.Remove(output.Length - 1, 1);  // delete last char
                    output.Append(GetKey(c, letterRepeatCount));
                }
                else if (c != lastChar)
                {
                    letterRepeatCount = 0;
                    output.Append(GetKey(c, letterRepeatCount));
                }
                else
                {
                    output.Append(GetKey(c, letterRepeatCount));
                }

                lastChar = c;
            }

            output.Clear();
            output.Append("\"#\" will always be included at the end of every input");
            return output.ToString();
        }

        private static char GetKey(char c, int letterRepeatCount)
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

            int charIndex = letterRepeatCount % keypad[c - '0'].Length;
            return keypad[c - '0'][charIndex];
        }
    }
}