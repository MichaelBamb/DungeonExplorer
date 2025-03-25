using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Media;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            Player player1 = new Player("Player", 10);
            player = player1;

            List<string> newItems = new List<string>();
            newItems.Add("Sword");
            newItems.Add("Shield");
            Room starting_room = new Room("This is the starting room and I'm terrible at descriptions.", newItems);
            currentRoom = starting_room;
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                // Code your playing logic here
                string optionsString = "\nOptions:\nView Player Stats (Stats)\n";
                bool itemAvailable = false;
                Console.WriteLine(currentRoom.GetDescription());
                if (currentRoom.GetItemCount() > 0) // Checks if any items are present in the room, if so adds an option to get them into the string
                {
                    optionsString += "Get Item (Get)\n";
                    itemAvailable = true;
                }

                string userInput = InputCheckStrings(optionsString + "Exit\n"); // Uses InputCheckStrings() method for input validation
                if (userInput.Contains("Stats")) // Displays the user's stats
                {
                    Console.WriteLine("Name = {0}\nHealth = {1}\nInventory = {2}", player.Name, player.Health, player.InventoryContents());
                }
                else if (userInput.StartsWith("Get") && itemAvailable == true) // Checks if items are available and the user enters Get
                {
                    List<string> items = currentRoom.GetItems(); // Gets items in the current room and displays them to the user
                    Console.WriteLine("\nAvailable Items:\n");
                    foreach (string item in items)
                    {
                        Console.WriteLine(item);
                    }

                    userInput = InputCheckStrings("\nWhat would you like to pick up?\n"); // Gets user input and moves item from room to inventory if applicable
                    if (items.Contains(userInput))
                    {
                        currentRoom.RemoveItem(userInput);
                        player.PickUpItem(userInput);
                        Console.WriteLine("You have picked up a " + userInput);
                    }
                    else
                        Console.WriteLine("That was not an available item.");
                }
                else if (userInput.Contains("Exit")) // Checks if player wants to exit the game
                {
                    playing = false;
                    continue;
                }
                else
                {
                    Console.WriteLine("That was not a valid input, please try again\nPlease note that the phrases are Case Sensetive!\n");
                }
            }
        }

        public string InputCheckStrings(string displayString) // Function used to validate user input
        {
            while (true)
            {
                Console.WriteLine(displayString);
                try
                {
                    string userInput = Console.ReadLine();
                    return userInput;
                }
                catch (FormatException)
                {
                    Console.WriteLine("That was not a valid input, please try again\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " If you see this, please report it to the Developer.\n");
                }
            }
        }
    }
}