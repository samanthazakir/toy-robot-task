using Moq;
using ToyRobotApp.Models.Enums;
using ToyRobotApp.Services;

namespace ToyRobotApp.Tests
{
    public class RobotAppTests
    {
        private readonly Mock<RobotService> _robotServiceMock;
        private readonly RobotApp _robotApp;

        public RobotAppTests()
        {
            _robotServiceMock = new Mock<RobotService>(new TableTopService()); 
            _robotApp = new RobotApp(_robotServiceMock.Object);
        }

        [Fact]
        public void ProcessCommand_Place_ShouldCallPlaceOnService()
        {
            _robotApp.ProcessCommand("PLACE 1,2,NORTH");

            _robotServiceMock.Verify(service => service.Place(1, 2, Direction.NORTH), Times.Once);
        }

        [Fact]
        public void ProcessCommand_Move_ShouldCallMoveOnService()
        {
            _robotApp.ProcessCommand("MOVE");

            _robotServiceMock.Verify(service => service.Move(), Times.Once);
        }

        [Fact]
        public void ProcessCommand_Left_ShouldCallLeftOnService()
        {
            _robotApp.ProcessCommand("LEFT");

            _robotServiceMock.Verify(service => service.Left(), Times.Once);
        }

        [Fact]
        public void ProcessCommand_Right_ShouldCallRightOnService()
        {
            _robotApp.ProcessCommand("RIGHT");

            _robotServiceMock.Verify(service => service.Right(), Times.Once);
        }

    }
   
}
