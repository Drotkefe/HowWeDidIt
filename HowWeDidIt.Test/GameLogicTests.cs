using Moq;
using NUnit.Framework;
using HowWeDidIt.Repository;
using System;
using HowWeDidIt.BusinessLogic;
using System.Collections.Generic;
using HowWeDidIt.Models;

namespace HowWeDidIt.Test
{
    [TestFixture]
    public class GameLogicTests
    {
        [Test]
        public void DecreaseVitalityDecreasesVitalityTest()
        {
            var gameSettings = new Mock<Core.GameSettings.IGameSettings>();
            var gameModel = new GameModel(800, 450, gameSettings.Object);            
            var gameRepository = new Mock<IGameRepository>();


            var gLogic = new GameLogic(gameModel, gameSettings.Object, gameRepository.Object);

            gLogic.DecreaseHealth();

            int result = gameModel.Vitality;
            int expectedResult = 89;

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
