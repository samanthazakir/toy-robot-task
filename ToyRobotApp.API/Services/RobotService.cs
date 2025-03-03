using ToyRobotApp.API.Interfaces;
using ToyRobotApp.API.Models;
using ToyRobotApp.API.Models.Enums;

namespace ToyRobotApp.API.Services
{
    public class RobotService : IRobotService
    {
        private readonly ITableTopService _tableTop;
        private Position _position;
        private Direction _direction;
        private bool _isPlaced = false;

        public RobotService(ITableTopService tableTop)
        {
            _tableTop = tableTop;
        }

        public virtual void Place(int x, int y, Direction facing)
        {
            var newPosition = new Position { X = x, Y = y };
            if (_tableTop.IsValidPosition(newPosition))
            {
                _position = newPosition;
                _isPlaced = true;
                _direction = facing;
            }
        }

        public virtual void Move()
        {
            if (!_isPlaced) throw new InvalidOperationException($"PLACE in a valid position first to perform this operation.");
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

        public virtual void Left()
        {
            if (!_isPlaced) throw new InvalidOperationException($"PLACE first to perform this operation.");
            _direction = (Direction)(((int)_direction + 3) % 4);
        }

        public virtual void Right()
        {
            if (!_isPlaced) throw new InvalidOperationException($"PLACE first to perform this operation.");
            _direction = (Direction)(((int)_direction + 1) % 4);
        }

        public virtual string Report()
        {
            if (!_isPlaced) return "Please place in a valid position.";
            return $"{_position.X},{_position.Y},{_direction}";
        }
    }
}
