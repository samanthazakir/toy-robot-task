using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotApp.Models.Enums;
using ToyRobotApp.Services;

namespace ToyRobotApp
{
    public class RobotApp
    {
        private readonly RobotService _robotService;

        public RobotApp(RobotService robotService)
        {
            _robotService = robotService;
        }
        public void ProcessCommand(string command)
        {
            var inputParts = command.Split(' ');

            switch (inputParts[0].ToUpper())
            {
                case "PLACE":
                    var args = inputParts[1].Split(',');
                    int x = int.Parse(args[0]);
                    int y = int.Parse(args[1]);
                    if (Enum.TryParse(args[2], out Direction facing))
                    {
                        _robotService.Place(x, y, facing);
                    }
                    break;
                case "MOVE":
                    _robotService.Move();
                    break;
                case "LEFT":
                    Console.WriteLine("LEFT");
                    break;
                case "RIGHT":
                    Console.WriteLine("RIGHT");
                    break;
                case "REPORT":
                    Console.WriteLine(_robotService.Report());
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}
