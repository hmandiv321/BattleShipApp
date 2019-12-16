using BattleShipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLibrary
{
    public class GameLogic
    {
        /// <summary>
        /// Populates PlayerModel object's game grid, with values from A1-E5
        /// </summary>
        /// <param name="model"></param>
        public static void InitializeGrid(PlayerModel model)
        {
            List<string> letters = new List<string> 
            { 
                "A",
                "B",
                "C",
                "D",
                "E"
            
            };
            
            List<int> numbers = new List<int> 
            { 
                1,
                2,
                3,
                4,
                5
            };
            
            foreach (string letter in letters)
            {
                foreach (int number in numbers)
                {
                    AddGridSpot(model, letter, number);
                }

            }
            
        }

        /// <summary>
        /// Creates a new GridSpotModel object and adds a grid spot to the 
        /// PlayerModel object's ShotGrid list
        /// </summary>
        /// <param name="model"></param>
        /// <param name="letter"></param>
        /// <param name="number"></param>
        private static void AddGridSpot(PlayerModel model, string letter, int number)
        {
            GridSpotModel gridSpot = new GridSpotModel
            {
                SpotLetter = letter,
                SpotNumber = number,
                Status = GridSpotStatus.Empty
            };

            model.ShotGrid.Add(gridSpot);
        }

        public static bool PlaceShip(PlayerModel model, string location)
        {
            throw new NotImplementedException();
        }
    }
}
