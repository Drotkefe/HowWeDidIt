using Moq;
using NUnit.Framework;
using System;

namespace HowWeDidIt.Test
{
    [TestFixture]
    public class GameLogicTests
    {
        [Test]
        public void DecreaseVitalityDecreasesVitalityTest()
        {
            var gameModel = new Mock<IGameModel>();
            var gameSettings = new Mock<IGameSettings>();


            var gameLogic = new GameLogic
        }

    }
}
