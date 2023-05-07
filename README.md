# Ghost Keyboard 2

Ghost Keyboard 2 is a Windows application that enables you to automate text input into any text field or document. It simulates keyboard input and writes out the text that is entered into a text box or from a saved file. The application is built using C# and .NET Framework.

## Getting Started

To get started with Ghost Keyboard 2, clone the repository and open it in Visual Studio. Once the project is loaded, build it and run the application. 

## Using Ghost Keyboard 2

The Ghost Keyboard 2 application has a simple user interface with the following features:

- Text Input: Enter text into the text box provided. 
- Delay: Enter the time delay before the writing starts.
- Font Size: Set the font size of the text.
- Start Writing: Click on this button to initiate the writing process.
- Cancel: Click on this button to terminate the writing process.
- Save File: Save the text in the text box as a .txt file.
- New: Clear the text box and start over.
- Edit: Enable or disable the undo and redo menu items.
- Cut: Cut the selected text.
- Copy: Copy the selected text.
- Paste: Paste copied or cut text into the text box.

## New Features

- **Support for Special Characters**: Ghost_Keyboard can now handle special characters such as parentheses, brackets, plus, caret, percent, and tilde. When these characters are encountered in the input string, they will be wrapped in curly braces to ensure that they are properly interpreted by the system.

- **Timer Functionality**: You can now specify a delay before the simulated keystrokes begin by setting a timer in the application. This is useful when you need to set up your application or document before the keystrokes begin.

- **Improved User Interface**: The user interface has been updated with clearer labels and more intuitive controls. The application is now easier to use, even for beginners.

## How to Use Ghost_Keyboard

1. Launch the application and enter the string of characters you want to simulate in the text box.

2. (Optional) Set a delay timer using the dropdown box and "Start" button.

3. Click the "Start" button to begin simulating keystrokes.

4. The application will begin sending keystrokes to the active window. Make sure the window you want to receive the keystrokes is active and in the foreground.

5. To stop the keystrokes, simply close the Ghost_Keyboard application.

## Functionality

The Ghost Keyboard 2 application uses the SendKeys method to simulate keyboard input. When the user clicks on the Start Writing button, the application will initiate a countdown before starting the writing process. It then calls the SendKeysFunction method which will iterate over each character of the text in the text box and simulate keyboard input. If the text contains special characters such as !, @, #, $, etc., it will be enclosed in braces to avoid any conflicts with the SendKeys method. 

If the user clicks on the Cancel button or the process is terminated for any other reason, the writing process will be stopped, and the label will display "Terminated". The Save File option allows the user to save the text in the text box as a .txt file. The New option clears the text box, and the Edit option enables or disables the undo and redo menu items. 

## Dependencies

Ghost Keyboard 2 uses the following dependencies:

- System.Drawing
- System.IO
- System.Linq
- System.Reflection.Emit
- System.Text
- System.Threading
- System.Threading.Tasks
- System.Windows.Forms

## System Requirements

- Windows 7, 8, or 10
- 1 GHz or faster processor
- 512 MB RAM or more
- 10 MB of available hard drive space

## Installation

To install GhostKeyboard V2.0, follow these simple steps:

1. Download the setup file from the official website.
2. Double-click the setup file to launch the installation wizard.
3. Follow the on-screen instructions to complete the installation process.

## Usage

To get started with GhostKeyboard V2.0, launch the application and start configuring your shortcuts and tasks. The interface is intuitive and easy to use, with clear instructions and helpful tooltips.
