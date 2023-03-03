using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSim.Simulation
{
    public class ErrorHandling
    {
        public string WrongCoordinate = "An errornous coordinate was used. Please try again with a coordinate within the board size.";
        public string WrongDirection = "An errornous direction was used. Please try again with one of the following cardinal directions: N, S, E or W";
    }
}
