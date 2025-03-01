using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotApp.Models;
using ToyRobotApp.Models.Enums;

namespace ToyRobotApp.Services
{
    public class RobotService
    {
        private readonly TableTopService _tableTop;
        private Position _position;
        private Direction _direction;
        private bool _isPlaced = false;

        public RobotService(TableTopService tableTop)
        {
            _tableTop = tableTop;
        }

        public void Place(int x, int y, Direction facing)
        {
            var newPosition = new Position { X = x, Y = y };
            if (_tableTop.IsValidPosition(newPosition))
            {
                _position = newPosition;
                _isPlaced = true;
                _direction = facing;
            }
        }

        public string Report()
        {
            if (!_isPlaced) return "Robot has not been placed yet.";
            return $"{_position.X},{_position.Y},{_direction}";
        }
    }
}
