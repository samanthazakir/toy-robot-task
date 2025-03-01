using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotApp
{
    public class Robot
    {
        public void ProcessCommand(string command)
        {
            var parts = command.Split(' ');

            switch (parts[0].ToUpper())
            {
                case "PLACE":
                    Console.WriteLine("PLACE");
                    break;
                case "MOVE":
                    Console.WriteLine("MOVE");
                    break;
                case "LEFT":
                    Console.WriteLine("LEFT");
                    break;
                case "RIGHT":
                    Console.WriteLine("RIGHT");
                    break;
                case "REPORT":
                    Console.WriteLine("Output:");
                    break;
                default:
                    Console.WriteLine("INVALID COMMAND");
                    break;
            }
        }
    }
}
