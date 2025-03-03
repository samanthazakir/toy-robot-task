
using ToyRobotApp.API.Models.Enums;

namespace ToyRobotApp.API.Interfaces
{
    public interface IRobotService
    {
        void Place(int x, int y, Direction facing);
        void Move();
        void Left();
        void Right();
        string Report();
    }
}
