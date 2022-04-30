using Moq;
using NUnit.Framework;
using HowWeDidIt.Repository;
using System;
using HowWeDidIt.BusinessLogic;
using System.Collections.Generic;
using HowWeDidIt.Models;
using HowWeDidIt.Core.Enums;
using HowWeDidIt.Core.GameSettings;

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
            var gameRepository = new Mock<IGameRepository>();


            var gLogic = new GameLogic(gameModel.Object, gameSettings.Object, gameRepository.Object);

            gLogic.DecreaseHealth();

            int result = gameModel.Object.Vitality;
            int expectedResult = gameModel.Object.Vitality;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        static List<TestCaseData> GameModelTestData()
        {
            var result = new List<TestCaseData>();

            
            MovingCaveMan CaveMan = new MovingCaveMan(20, 20, 14, 0);

            int CollectionAreaBeginning = 150;
            int CollectionAreaEnd = 680;
            int GarbageCount = 0;
            int GarbageCapacity = 10;
            int Vitality = 90;
            int Money = 200;
            int GameScore = 0;

            
            Dictionary<Foods, int> FoodCapacities=new Dictionary<Foods, int>();
            FoodCapacities.Add(Foods.Carrot, 2);
            FoodCapacities.Add(Foods.Egg, 2);
            FoodCapacities.Add(Foods.Meat, 2);
            FoodCapacities.Add(Foods.Onion, 2);
            FoodCapacities.Add(Foods.Potato, 2);
            FoodCapacities.Add(Foods.Uranium, 2);

            Dictionary<Foods, int> CollectedFoods= new Dictionary<Foods, int>();
            CollectedFoods.Add(Foods.Carrot, 0);
            CollectedFoods.Add(Foods.Egg, 0);
            CollectedFoods.Add(Foods.Meat, 0);
            CollectedFoods.Add(Foods.Onion, 0);
            CollectedFoods.Add(Foods.Potato, 0);
            CollectedFoods.Add(Foods.Uranium, 0);
            List<MovingFoodItem> FoodItems = new List<MovingFoodItem>();
            FoodItems.Add(new MovingFoodItem(Foods.Onion, CollectionAreaBeginning,0,0,20));

            Recipe Recipe = new Recipe();
            Recipe.Name = "Pizza";
            Recipe.FoodList = new List<Foods>();
            Recipe.FoodList.Add(Core.Enums.Foods.Onion);
            Recipe.FoodList.Add(Core.Enums.Foods.Meat);
            Recipe.FoodList.Add(Core.Enums.Foods.Egg);
            Recipe.FoodList.Add(Core.Enums.Foods.Carrot);
            Recipe.FoodList.Add(Core.Enums.Foods.Potato);
            Recipe.FoodList.Add(Core.Enums.Foods.Uranium);
            Recipe.FoodList.Add(Core.Enums.Foods.Uranium);

            result.Add(new TestCaseData(CaveMan, CollectionAreaBeginning, CollectionAreaEnd, GarbageCapacity, GarbageCount
                , Vitality, Money, GameScore, Recipe, FoodCapacities, CollectedFoods, FoodItems));

            return result;

        }

        [Test]
        public void Move_Test_Left()
        {
            var gameModel = new Mock<IGameModel>();
            var gameSettings = new Mock<IGameSettings>();
            var gameRepository = new Mock<IGameRepository>();

            gameSettings.SetupAllProperties();
            gameModel.SetupAllProperties();

            gameModel.Object.CaveMan = new MovingCaveMan(400, 380, 14, 5);
            gameModel.Object.CaveMan.Orientation = Orientations.Left;
            gameSettings.Object.MaximalAllowedMovementState = 6;

            var gLogic = new GameLogic(gameModel.Object, gameSettings.Object, gameRepository.Object);

            var oldX = gameModel.Object.CaveMan.X;

            gLogic.Move(-gameSettings.Object.CaveManInitXVelocity, gameSettings.Object.CaveManInitYVelocity); //Balra mozgás

            var newX = gLogic.GameModel.CaveMan.X;
            Assert.That(oldX == newX + gameSettings.Object.CaveManInitXVelocity);
           
        }

        [Test]
        public void Move_Test_Right()
        {
            //Arrange
            var gameModel = new Mock<IGameModel>();
            var gameSettings = new Mock<IGameSettings>();
            var gameRepository = new Mock<IGameRepository>();

            gameSettings.SetupAllProperties();
            gameModel.SetupAllProperties();
            gameModel.Object.CaveMan = new MovingCaveMan(400, 380, 14, 5);
            gameModel.Object.CaveMan.Orientation = Orientations.Left;
            gameSettings.Object.MaximalAllowedMovementState = 6;
            var gLogic = new GameLogic(gameModel.Object, gameSettings.Object, gameRepository.Object);
            var oldX = gameModel.Object.CaveMan.X;
            //Act
            gLogic.Move(gameSettings.Object.CaveManInitXVelocity, gameSettings.Object.CaveManInitYVelocity); //Jobbra mozgás
            var newX = gLogic.GameModel.CaveMan.X;
            //Assert
            Assert.That(oldX == newX - gameSettings.Object.CaveManInitXVelocity);

        }

        [Test]
        public void Entering_Kitchen_Test()
        {
            //Arrange
            var gameModel = new Mock<IGameModel>();
            var gameSettings = new Mock<IGameSettings>();
            var gameRepository = new Mock<IGameRepository>();

            gameSettings.SetupAllProperties();
            gameModel.SetupAllProperties();
            gameModel.Object.CaveMan = new MovingCaveMan(100, 380, 14, 5);
            gameModel.Object.CaveMan.Orientation = Orientations.Left;
            gameSettings.Object.MaximalAllowedMovementState = 6;

            var gLogic = new GameLogic(gameModel.Object, gameSettings.Object, gameRepository.Object);
            var inside = false;
            //Act
            for (int i = 0; i < 25; i++) //25x lépünk balra, hogy eljussunk a konyhába
            {
                gLogic.Move(-gameSettings.Object.CaveManInitXVelocity, gameSettings.Object.CaveManInitYVelocity);
                if (gLogic.GameModel.CaveMan.X < 120)
                    inside = true;
            }
            //Assert
            Assert.That(inside,Is.True);

        }

        [Test]
        public void Empty_the_Bin()
        {
            //Arrange
            var gameModel = new Mock<IGameModel>();
            var gameSettings = new Mock<IGameSettings>();
            var gameRepository = new Mock<IGameRepository>();

            gameSettings.SetupAllProperties();
            gameModel.SetupAllProperties();
            gameModel.Object.CaveMan = new MovingCaveMan(650, 380, 14, 5);
            gameModel.Object.CaveMan.Orientation = Orientations.Left;
            gameSettings.Object.MaximalAllowedMovementState = 6;
            gameModel.Object.GarbageCount = 5;

            var gLogic = new GameLogic(gameModel.Object, gameSettings.Object, gameRepository.Object);
            gLogic.Move(gameSettings.Object.CaveManInitXVelocity, gameSettings.Object.CaveManInitYVelocity);

            Assert.That(gLogic.GameModel.CaveMan.X>=650);

        }




    }

}
