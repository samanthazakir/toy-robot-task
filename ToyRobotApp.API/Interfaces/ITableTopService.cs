using ToyRobotApp.API.Models;

namespace ToyRobotApp.API.Interfaces
{
    public interface ITableTopService
    {
        bool IsValidPosition(Position postion);
    }
}
