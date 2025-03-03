using ToyRobotApp.Models;
using ToyRobotApp.Services;

namespace ToyRobotApp.Tests
{
    public class TableTopServiceTests
    {
        private readonly TableTopService _tableTopService;

        public TableTopServiceTests()
        {
            _tableTopService = new TableTopService();
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(4, 4, true)]
        [InlineData(-1, 0, false)]
        [InlineData(5, 5, false)]
        [InlineData(3, 5, false)]
        public void IsValidPosition_ShouldReturnExpectedResult(int x, int y, bool expected)
        {
            var position = new Position { X = x, Y = y };

            var result = _tableTopService.IsValidPosition(position);

            Assert.Equal(expected, result);
        }
    }
}
