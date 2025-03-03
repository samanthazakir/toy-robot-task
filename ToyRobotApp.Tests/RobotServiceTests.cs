using ToyRobotApp.Models.Enums;
using ToyRobotApp.Services;

namespace ToyRobotApp.Tests
{
    public class RobotServiceTests
    {
        private readonly RobotService _robotService;
        private readonly TableTopService _tableTopService;

        public RobotServiceTests()
        {
            _tableTopService = new TableTopService();
            _robotService = new RobotService(_tableTopService);
        }

        [Fact]
        public void Place_ValidPosition_ShouldPlaceRobotCorrectly()
        {
            _robotService.Place(0, 0, Direction.NORTH);

            var report = _robotService.Report();

            Assert.Equal("0,0,NORTH", report);
        }

        [Fact]
        public void Place_InvalidPosition_ShouldIgnorePlacement()
        {
            _robotService.Place(6, 6, Direction.NORTH);

            var report = _robotService.Report();

            Assert.Equal("Please place in a valid position.", report);
        }

        [Fact]
        public void Move_AfterPlacing_ShouldMoveCorrectly()
        {
            _robotService.Place(0, 0, Direction.NORTH);
            _robotService.Move();

            var report = _robotService.Report();

            Assert.Equal("0,1,NORTH", report);
        }

        [Fact]
        public void Move_WithoutPlacing_ShouldThrowException()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => _robotService.Move());
            Assert.Equal("PLACE in a valid position first to perform this operation.", exception.Message);
        }

        [Fact]
        public void Left_AfterPlacing_ShouldRotateLeft()
        {
            _robotService.Place(0, 0, Direction.NORTH);
            _robotService.Left();

            var report = _robotService.Report();

            Assert.Equal("0,0,WEST", report);
        }

        [Fact]
        public void Right_AfterPlacing_ShouldRotateRight()
        {
            _robotService.Place(0, 0, Direction.NORTH);
            _robotService.Right();

            var report = _robotService.Report();

            Assert.Equal("0,0,EAST", report);
        }

        [Fact]
        public void Move_ShouldNotMoveOutOfBounds()
        {
            _robotService.Place(0, 0, Direction.SOUTH);
            _robotService.Move();

            var report = _robotService.Report();

            Assert.Equal("0,0,SOUTH", report);
        }

        [Fact]
        public void Report_WithoutPlacing_ShouldIndicateNotPlaced()
        {
            var report = _robotService.Report();

            Assert.Equal("Please place in a valid position.", report);
        }
    }
}
