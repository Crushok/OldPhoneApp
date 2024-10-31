using System;
using System.Collections.Generic;

public class OldPhone
{
    static Dictionary<char, string> buttonMappings = new Dictionary<char, string>
    {
        { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" }, { '5', "JKL" }, { '6', "MNO" },
        { '7', "PQRS" }, { '8', "TUV" }, { '9', "WXYZ" }, { '0', " " }, { '*', "" }
    };

    public static string OldPhonePad(string input)
    {
        string result = "";
        char currentButton = ' ';
        int pressCount = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (c == '#')
            {
                break;
            }

            if (c == '*')
            {
                if (result.Length > 0)
                {
                    result = result.Substring(0, result.Length - 1);
                }
                currentButton = ' ';
                pressCount = 0;
                continue;
            }

            if (c == ' ')
            {
                if (buttonMappings.ContainsKey(currentButton))
                {
                    string letters = buttonMappings[currentButton];
                    int letterIndex = (pressCount - 1) % letters.Length;
                    result += letters[letterIndex];
                }
                currentButton = ' ';
                pressCount = 0;
                continue;
            }

            if (currentButton == c)
            {
                pressCount++;
            }
            else
            {
                if (buttonMappings.ContainsKey(currentButton) && pressCount > 0)
                {
                    string letters = buttonMappings[currentButton];
                    int letterIndex = (pressCount - 1) % letters.Length;
                    result += letters[letterIndex];
                }
                currentButton = c;
                pressCount = 1;
            }
        }

        return result;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("enter the number or 'exit' if you want to exit the program ");
            string? userInput = Console.ReadLine();

            if (userInput?.ToLower() == "exit")
            {
                Console.WriteLine("exiting");
                break;
            }

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("no input detected, try once more");
                continue;
            }

            string output = OldPhone.OldPhonePad(userInput);
            Console.WriteLine("result " + output);
        }
    }

    public static string OldPhonePad(string input)
    {
        if (!input.EndsWith("#"))
        {
            return "Invalid. Please end with 'number #'";
        }
        return "Input detected with #: " + input;
    }
}