using ToyRobotApp.API.Interfaces;
using ToyRobotApp.API.Models.Enums;

namespace ToyRobotApp.API.Services
{
    public class RobotAppService : IRobotAppService
    {
        private readonly IRobotService _robotService;

        public RobotAppService(IRobotService robotService)
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
                    _robotService.Left();
                    break;
                case "RIGHT":
                    _robotService.Right();
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
