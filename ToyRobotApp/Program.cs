using ToyRobotApp.Models;
using ToyRobotApp.Services;

namespace ToyRobotApp
{
    //taking input from user
    public class Program()
    {
        public static void Main(string[] args)
        {
            var tabletop = new TableTopService();
            var robotService = new RobotService(tabletop);
            var app = new RobotApp(robotService);
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "..", "..", "..", "Input", "command.txt");

            try
            {
                foreach (var command in File.ReadLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(command)) continue;
                    app.ProcessCommand(command);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Command file not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

}
