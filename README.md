# Old Phone Pad

This is a simple console application that simulates an old phone keypad input system. The program takes user input as a string, processes it according to the old phone keypad rules, and outputs the corresponding characters.

## Features

- **Simulates Old Phone Keypad**: Handles inputs based on the classic mobile phone keypad layout (0-9) for text input.
- **Supports Repeated Key Presses**: Repeated presses of the same key cycle through the letters assigned to that key (e.g., pressing '2' three times would output 'C').
- **Error Handling**: Handles invalid inputs, including unsupported characters, and prompts the user with an error message.

## How It Works

The program accepts input based on the number mapping on a traditional mobile phone keypad:

| Key | Characters        |
|-----|-------------------|
| 0   | (space)           |
| 1   | &’(               |
| 2   | ABC               |
| 3   | DEF               |
| 4   | GHI               |
| 5   | JKL               |
| 6   | MNO               |
| 7   | PQRS              |
| 8   | TUV               |
| 9   | WXYZ              |

- Pressing a key once corresponds to the first character in the string.
- Pressing the same key multiple times cycles through the characters assigned to that key.

## How to Use

1. Clone or download this repository.
2. Open the project in Visual Studio or another C# compatible IDE.
3. Run the `Program.cs` file.

The program will prompt you to enter a phone pad sequence. Type in numbers (0-9), spaces, or '*' to simulate input. Pressing '*' will remove the last character. The program will process the input and display the corresponding characters.

- Use `#` to end your input and get the result.

### Example:

Please enter phone pad: 33#
Output: E

Please enter phone pad: 227*#
Output: B

Please enter phone pad: 4433555 555666#
Output: HELLO

Please enter phone pad: 8 88777444666*664#
Output: TURING

## Error Handling

- Invalid characters (anything other than digits, space, or asterisk) will result in an error message:  
  `An error occurred: Invalid character entered. Only digits and '*' are allowed.`
