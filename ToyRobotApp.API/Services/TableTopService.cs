using ToyRobotApp.API.Interfaces;
using ToyRobotApp.API.Models;

namespace ToyRobotApp.API.Services
{
    public class TableTopService : ITableTopService
    {
        private const int Width = 5;
        private const int Height = 5;

        public bool IsValidPosition(Position postion)
        {
            return postion.X >= 0 && postion.X < Width && postion.Y >= 0 && postion.Y < Height;
        }
    }
}
