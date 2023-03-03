using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSim.Simulation
{
    internal class Robot
    {
        public string? currentCoodinates;
        public int currentXCoordinate;
        public int currentYCoordinate;
        public string? currentFacingDirection;
        public bool isPlaced = false;

        public void SetCoordinates(int xCoordinate, int yCoordinate)
        {
            currentCoodinates = xCoordinate.ToString() + "," + yCoordinate.ToString();
            currentXCoordinate = xCoordinate;
            currentYCoordinate = yCoordinate;
        }

        public void SetDirection(string direction) 
        { 
            currentFacingDirection = direction;
        }
    }
}
