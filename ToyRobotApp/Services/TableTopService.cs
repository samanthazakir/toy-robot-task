using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotApp.Models;

namespace ToyRobotApp.Services
{
    public class TableTopService
    {
        private const int Width = 5;
        private const int Height = 5;

        public bool IsValidPosition(Position postion)
        {
            return postion.X >= 0 && postion.X < Width && postion.Y >= 0 && postion.Y < Height;
        }
    }
}
