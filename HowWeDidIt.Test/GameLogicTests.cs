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
            var gameModel = new Mock<Models.IGameModel>();
            var gameSettings = new Mock<Core.GameSettings.IGameSettings>();
            var gameRepository = new Mock<IGameRepository>();
            var kitchenService = new Mock<IKitchenService>();

            var gLogic = new GameLogic(gameModel.Object, gameSettings.Object, gameRepository.Object, kitchenService.Object);

            gameModel.Object.Vitality = 90;

            gLogic.DecreaseHealth();

            int result = gameModel.Object.Vitality;
            int expectedResult = 0;

            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [Test]
        public void FoodItemsFalling()
        {
            var gameModel = new Mock<Models.IGameModel>();
            var gameSettings = new Mock<Core.GameSettings.IGameSettings>();
            var gameRepository = new Mock<IGameRepository>();
            var kitchenService = new Mock<IKitchenService>();

            var gLogic = new GameLogic(gameModel.Object, gameSettings.Object, gameRepository.Object, kitchenService.Object);

            gameModel.Setup(x => x.FoodItems);

            gLogic.FoodItemsFalling();



            Assert.That(() => FoodItemsFalling(), Throws.Nothing);
        }

    }
}
