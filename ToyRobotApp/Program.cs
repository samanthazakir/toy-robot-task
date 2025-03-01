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
            Position pos = new Position();
            pos.X = 1;
            pos.Y = 2;
            var result = tabletop.IsValidPosition(pos);
            Console.WriteLine(result);

            var app = new Robot();
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
