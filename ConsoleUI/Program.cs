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

            PlayerModel activePlayer = CreatePlayer("Player One");
            PlayerModel opponent = CreatePlayer("Player Two");
            PlayerModel winner = null;

            do
            {
                // Display grid from activePlayer
                DisplayGridShot(activePlayer);

                // Ask activePlayer for a shot
                // Determine if the shot was valid
                // Determine shot results
                RecordPlayerShot(activePlayer, opponent);
                
                // Determine if the game is over
                //if over, set activePlayer as the winner
                //Else, swap positons with activePlayer to opponent

            } while (winner == null);

            Console.ReadLine();
        }
        
        /// <summary>
        /// Ask activePlayer for a shot.
        /// Determine if the shot was valid. 
        /// Determine shot results.
        /// </summary>
        /// <param name="activePlayer"></param>
        /// <param name="opponent"></param>
        private static void RecordPlayerShot(PlayerModel activePlayer, PlayerModel opponent)
        {
            // Ask for a shot (Ask the user to input in the form "A5")
            // Determine which row and column the shot was aimed at
            // Determine if the input was a valid shot
            // Go back to the beginning if shot was in valid
        }
        
        /// <summary>
        /// Display grid from activePlayer.
        /// </summary>
        /// <param name="model"></param>
        private static void DisplayGridShot(PlayerModel model)
        {
            string currentRow = model.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in model.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }

                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotFullName} ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write(" X ");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O ");
                }
                else
                {
                    Console.Write(" ? ");
                }
            }
        }
        
        /// <summary>
        /// Prints a welcome message and shows the game's creator name
        /// </summary>
        private static void WelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mini BattleShip Game!");
            Console.WriteLine("Created By HR Mandiv");
            Console.WriteLine();
        }
        
        /// <summary>
        /// Creates a playerModel object
        /// </summary>
        /// <param name="PlayerTitle"></param>
        /// <returns>playerModel object</returns>
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
        
        /// <summary>
        /// Asks user for a question passed through the message variable
        /// </summary>
        /// <param name="message"></param>
        /// <returns>user input as a string </returns>
        private static string AskForPLayersName(String message)
        {
            Console.Write(message);
            string output = Console.ReadLine();

            return output;
        }
       
        /// <summary>
        /// Places player ships in their desired locations (A1-E5)
        /// </summary>
        /// <param name="model"></param>
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
