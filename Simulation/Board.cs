using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSim.Simulation
{
    internal class Board
    {
        // Set board size for a square board inside a variable.
        // To facilitate a non square board, extension would be to have xSizeArray and ySizeArray
        public List<int> boardSizeArr = new List<int>()
                    {
                        0,1,2,3,4
                    };

        // create the variable that contains the list of coordinates for the board
        public List<String> board = new List<String>();
        
        // Method that initialises board size and sets the coordinates
        public void InitBoard ()
        {
            var xCoordinates = boardSizeArr;
            var yCoordinates = boardSizeArr;

            foreach (var x in xCoordinates) 
            { 
                foreach(var y in yCoordinates)
                {
                    board.Add(x + "," + y);
                }
            }
        }
    }
}
