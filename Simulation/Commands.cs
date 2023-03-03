using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSim.Simulation
{
    internal class Commands
    {
        //Instantiation of ErrorHandlingMessages
        ErrorHandling errorHandling = new ErrorHandling();

        // List of acceptable directions able to be input into any given command
        public List<string> acceptableDirections = new List<string>()
        {
            "NORTH","EAST","SOUTH","WEST"
        };

        // List of acceptable coordinates able to be input into any given command.
        // Even though this in theory will always mimick the board size array, I wanted to separate concerns for
        // board size construction from acceptable parameters for commands.
        public List<int> acceptableCoordinates = new List<int>()
        {
            0,1,2,3,4
        };

        public void PlaceRobot(Robot robot, int xCoordinate, int yCoordinate, string direction)
        {
            if (acceptableCoordinates.Contains(xCoordinate) && acceptableCoordinates.Contains(yCoordinate))
            {
                robot.SetCoordinates(xCoordinate, yCoordinate);
            }
            else
            {
                // Unacceptable coordinate(s).
                Console.WriteLine(errorHandling.WrongCoordinate);
            }
            
            if (acceptableDirections.Contains(direction))
            {
                robot.SetDirection(direction);
            }
            else
            {
                // Unacceptable Direction.
                Console.WriteLine(errorHandling.WrongDirection);
            }

            robot.isPlaced = true;
        }

        // When the robot moves, a given facing direction will amount to +1 or -1 on the relevant axis. So we can call the PlaceRobot command with the modification based
        // on the current facing direction.
        public void MoveRobot(Robot robot)
        {
            if (robot.isPlaced)
            {
                if (robot.currentFacingDirection == "NORTH")
                {
                    PlaceRobot(robot, robot.currentXCoordinate + 1, robot.currentYCoordinate, robot.currentFacingDirection);
                }
                else if (robot.currentFacingDirection == "EAST")
                {
                    PlaceRobot(robot, robot.currentXCoordinate, robot.currentYCoordinate + 1, robot.currentFacingDirection);
                }
                else if (robot.currentFacingDirection == "SOUTH")
                {
                    PlaceRobot(robot, robot.currentXCoordinate - 1, robot.currentYCoordinate, robot.currentFacingDirection);
                }
                else if (robot.currentFacingDirection == "WEST")
                {
                    PlaceRobot(robot, robot.currentXCoordinate, robot.currentYCoordinate - 1, robot.currentFacingDirection);
                }
                else
                {
                    // No valid direction
                    // Not placed?
                }
            }
        }

        Dictionary<string, int> DirectionOrdering = new Dictionary<string, int>()
        {
            { "NORTH", 0 },
            { "EAST", 1 },
            { "SOUTH", 2 },
            { "WEST", 3 }
        };

        // Rotate the robot left or right based on the command given.
        void TurnRobot(Robot robot, string rotation)
        {
            // check if robot has been placed before and therefore has a valid direction
            if (robot.isPlaced)
            {
                // Fetch current int value of robot current facing direction
                var currentIntVal = DirectionOrdering.Where(dir => dir.Key == robot.currentFacingDirection).Select(d => d.Value).FirstOrDefault();

                if (rotation == "LEFT")
                {
                    // check to see if value needs to loop around to 3.
                    if (currentIntVal == 0)
                    {
                        currentIntVal = 3;
                    }
                    else
                    {
                        currentIntVal = currentIntVal - 1;
                    }
                }
                else if (rotation == "RIGHT")
                {
                    // check to see if value needs to loop around to 0.
                    if (currentIntVal == 3)
                    {
                        currentIntVal = 0;
                    }
                    else
                    {
                        currentIntVal = currentIntVal + 1;
                    }
                }
                else
                {
                    // No Valid Direction for turn?
                }
                var direction = DirectionOrdering.Where(dir => dir.Value == currentIntVal).Select(d => d.Key).FirstOrDefault();
                if (direction != null)
                {
                    robot.SetDirection(direction);
                }
            }
        }

        public void LeftTurn(Robot robot)
        {
            TurnRobot(robot, "LEFT");
        }

        public void RightTurn(Robot robot)
        {
            TurnRobot(robot, "RIGHT");
        }

        public void Report(Robot robot)
        {
            if (robot.isPlaced)
            {
                Console.WriteLine("The current coordinates of the robot are: " + robot.currentCoodinates);
                Console.WriteLine("The current facing direction of the robot is: " + robot.currentFacingDirection);
            }
        }
    }
}
