using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Bowling.Test
{
    public class GameTests
    {
        readonly Game _sut = new Game();

        [Theory]
        [InlineData(2, 18, false, 10,
            2, 2)]
        [InlineData(10, 133, true, 1, 4,
            4, 5,
            6, 4,
            5, 5,
            10,
            0, 1,
            7, 3,
            6, 4,
            10,
            2, 8, 6)]
        public void TestsMethod1(int frameCount, int totalScore, bool over, params int[] rolls)
        {
            foreach (var pins in rolls)
            {
                _sut.AddRoll(pins);
            }
            _sut.Frames().Count.Should().Be(frameCount);
            _sut.TotalScore().Should().Be(totalScore);
            _sut.Over().Should().Be(over);
        }

        [Fact]
        public void GameIsOverThrowsExeption()
        {
            foreach (var i in Enumerable.Range(0, 20))
            {
                _sut.AddRoll(1);
            }

            Assert.Throws<Exception>(() => _sut.AddRoll(1));
        }

    }
}
