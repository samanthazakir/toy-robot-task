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
        public void Move()
        {
            if (!_isPlaced) throw new InvalidOperationException($"PLACE first to perform this operation.");
            var newPosition = new Position { X = _position.X, Y = _position.Y };

            switch (_direction)
            {
                case Direction.NORTH:
                    newPosition.Y = newPosition.Y + 1;
                    break;
                case Direction.SOUTH:
                    newPosition.Y = newPosition.Y - 1;
                    break;
                case Direction.EAST:
                    newPosition.X = newPosition.X + 1;
                    break;
                case Direction.WEST:
                    newPosition.X = newPosition.X - 1;
                    break;
                default:
                    throw new InvalidOperationException($"Invalid Direction: {_direction}");

            }
            if (_tableTop.IsValidPosition(newPosition))
            {
                _position = newPosition;
            }
        }
        public void Left()
        {
            if (!_isPlaced) throw new InvalidOperationException($"PLACE first to perform this operation.");
            _direction = (Direction)(((int)_direction + 3) % 4);
        }   
        public void Right()
        {
            if (!_isPlaced) throw new InvalidOperationException($"PLACE first to perform this operation.");
            _direction = (Direction)(((int)_direction + 1) % 4);
        }
        public string Report()
        {
            if (!_isPlaced) return "Robot has not been placed yet.";
            return $"{_position.X},{_position.Y},{_direction}";
        }
    }
}
