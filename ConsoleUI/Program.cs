using BattleShipLibrary;
using BattleShipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            PlayerModel playerOne = CreatePlayer("Player One");
            PlayerModel playerTwo = CreatePlayer("Player Two");

            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mini BattleShip Game!");
            Console.WriteLine("Created By HR Mandiv");
            Console.WriteLine();
        }

        private static PlayerModel CreatePlayer(string PlayerTitle)
        {
            PlayerModel output = new PlayerModel();

            Console.WriteLine($"Player information for {PlayerTitle}:");
            Console.WriteLine($"------------------------------------");

            //Ask player for thier name
            output.UserName = AskForPLayersName($"{PlayerTitle} please enter your name: ");
            
            //Load up the shot grid
            GameLogic.InitializeGrid(output);

            //Ask player for their 5 battleship positions in the grid
            PlaceShips(output);

            //Clear the screen
            Console.Clear();

            return output;

        }

        private static string AskForPLayersName(String message)
        {
            Console.Write(message);
            string output = Console.ReadLine();

            return output;
        }
        private static void PlaceShips(PlayerModel model)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter locations of your 5 ships:-");

            do
            {
                Console.Write($"Where do you want to place ship number {model.ShipLocations.Count + 1}: ");
                string location = Console.ReadLine();
                bool isValid = GameLogic.PlaceShip(model, location);

                if (isValid == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again!");
                }

            } while (model.ShipLocations.Count < 5);
        }
    }
}
