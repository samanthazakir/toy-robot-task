namespace ToyRobotApp
{
    //taking input from user
    public class Program()
    {
        public static void Main(string[] args)
        {
            var app = new Robot();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string filePath = Path.Combine(baseDirectory, "..", "..", "..", "Input", "command.txt");
            var filePath = @"command1.txt";
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
