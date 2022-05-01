using GalaSoft.MvvmLight.Messaging;
using HowWeDidIt.BusinessLogic;
using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.Test
{
    [TestFixture]
    class KitchenScreenContolTests
    {

        static GameModel GameModelTestData()
        {
            var result = new GameModel(0, 0);

            //default settings 
            result.GarbageCount = 0;
            result.GarbageCapacity = 10;
            result.Vitality = 90;
            result.Money = 200;
            result.GameScore = 0;


            result.FoodCapacities = new Dictionary<Foods, int>();
            result.FoodCapacities.Add(Foods.Carrot, 2);
            result.FoodCapacities.Add(Foods.Egg, 2);
            result.FoodCapacities.Add(Foods.Meat, 2);
            result.FoodCapacities.Add(Foods.Onion, 2);
            result.FoodCapacities.Add(Foods.Potato, 2);
            result.FoodCapacities.Add(Foods.Uranium, 2);

            result.CollectedFoods = new Dictionary<Foods, int>();
            result.CollectedFoods.Add(Foods.Carrot, 0);
            result.CollectedFoods.Add(Foods.Egg, 0);
            result.CollectedFoods.Add(Foods.Meat, 0);
            result.CollectedFoods.Add(Foods.Onion, 0);
            result.CollectedFoods.Add(Foods.Potato, 0);
            result.CollectedFoods.Add(Foods.Uranium, 0);


            result.Recipe = new Recipe();
            result.Recipe.Name = "Pizza";
            result.Recipe.FoodList = new List<Foods>();

            return result;
        }



        [Test]
        public void CreateServiceTest()
        {
            // Arrange
            var messengerMock = new Mock<IMessenger>();

            // Act
            KitchenService service = new KitchenService(messengerMock.Object);

            // Assert
            Assert.That(service, Is.Not.Null);
        }

        [Test]
        public void UpdateStorage_EnoughMoneyTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.Money = 200;

            // Act
            kitchenServiceMock.Object.UpgradeStorage(Foods.Carrot.ToString(), gameModel);

            // Assert
            Assert.That(gameModel.FoodCapacities[Foods.Carrot] == 4);
            messengerMock.Verify(messenger => messenger.Send("Upgrade was successful", "KitchenBlOperationResult"), Times.Once());

        }




        [Test]
        public void UpdateStorage_NoEnoughMoneyTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.Money = 199;


            // Act
            kitchenServiceMock.Object.UpgradeStorage(Foods.Carrot.ToString(), gameModel);

            // Assert
            Assert.That(gameModel.FoodCapacities[Foods.Carrot] == 2);
            messengerMock.Verify(messenger => messenger.Send("Upgrade was not successful", "KitchenBlOperationResult"), Times.Once());
        }


        [Test]
        public void SellProduct_CookedFoodTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.Recipe.Cooked = true;
            var oldRecipe = gameModel.Recipe;

            // Act
            kitchenServiceMock.Object.SellProduct(gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Product sell was successful", "KitchenBlOperationResult"), Times.Once());
            Assert.That(!gameModel.Recipe.Equals(oldRecipe));
        }

        [Test]
        public void SellProduct_UncookedFoodTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.Recipe.Cooked = false;
            var oldRecipe = gameModel.Recipe;

            // Act
            kitchenServiceMock.Object.SellProduct(gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Product sell was not successful", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.Recipe.Equals(oldRecipe));
        }


        [Test]
        public void RestoreHeathPoits_LowerVitalityTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.Recipe.Cooked = true;
            gameModel.Vitality = 70;
            gameModel.Recipe.VitalityValue = 20;

            // Act
            kitchenServiceMock.Object.RestoreHeathPoits(gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Player healing was successful", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.Vitality.Equals(90));
        }

        [Test]
        public void RestoreHeathPoits_MaxVitalityTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.Recipe.Cooked = true;
            gameModel.Vitality = 90;
            gameModel.Recipe.VitalityValue = 20;

            // Act
            kitchenServiceMock.Object.RestoreHeathPoits(gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Player healing was successful", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.Vitality.Equals(100));
        }

        [Test]
        public void RestoreHeathPoits_NotCookedFoodTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.Recipe.Cooked = false;
            gameModel.Vitality = 90;
            gameModel.Recipe.VitalityValue = 20;

            // Act
            kitchenServiceMock.Object.RestoreHeathPoits(gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Player healing was not successful", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.Vitality.Equals(90));
        }






        [Test]
        public void FoodToPot_FullGarbageCapacityTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.GarbageCapacity = 10;
            gameModel.GarbageCount = 10;
            gameModel.CollectedFoods[Foods.Carrot] = 2;

            // Act
            kitchenServiceMock.Object.FoodToPot(Foods.Carrot.ToString(), gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Hygenie Alert! Empty the trash.", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.CollectedFoods[Foods.Carrot].Equals(2));
        }

        [Test]
        public void FoodToPot_NotEnoughCollectedTypeOfFoodTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.GarbageCount = 0;
            gameModel.GarbageCapacity = 10;
            gameModel.CollectedFoods[Foods.Carrot] = 0;


            // Act
            kitchenServiceMock.Object.FoodToPot(Foods.Carrot.ToString(), gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("There is not enough food like this.", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.CollectedFoods[Foods.Carrot].Equals(0));
        }

        [Test]
        public void FoodToPot_DishIsCompleteTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.GarbageCount = 0;
            gameModel.GarbageCapacity = 10;
            gameModel.CollectedFoods[Foods.Carrot] = 2;
            gameModel.Recipe.Cooked = true;

            // Act
            kitchenServiceMock.Object.FoodToPot(Foods.Carrot.ToString(), gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("The dish is complete. Sell or heal!", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.CollectedFoods[Foods.Carrot].Equals(2));
        }


        //[Test]
        //public void FoodToPot_DishIsNotCompleteTest()
        //{
        //    //Arrange
        //    var messengerMock = new Mock<IMessenger>();
        //    var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
        //    kitchenServiceMock.SetupAllProperties();

        //    var gameModel = GameModelTestData();
        //    gameModel.GarbageCount = 0;
        //    gameModel.CollectedFoods[Foods.Carrot] = 2;
        //    gameModel.Recipe.Cooked = false;
        //    gameModel.Recipe.CurrentFoodIndex = 0;

        //    gameModel.Recipe.FoodList.Add(Foods.Carrot);
        //    gameModel.Recipe.FoodList.Add(Foods.Egg);


        //    kitchenServiceMock.Setup(mock => mock.CookFood(, gameModel));
        //    //KitchenService kitchenService = new KitchenService(messengerMock.Object);

        //    // Act
        //    kitchenService.FoodToPot(Foods.Carrot.ToString(), gameModel);
        //    kitchenServiceMock.Object.FoodToPot(Foods.Carrot.ToString(), gameModel);

        //    // Assert
        //    kitchenService.Verify(service => service.CookFood(Foods.Carrot, gameModel), Times.Once());
        //    //kitchenServiceMock.VerifyAll();
        //}


        [Test]
        public void CookFood_NotGoodItemCaughtTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.GarbageCount = 0;
            gameModel.GarbageCapacity = 10;
            gameModel.CollectedFoods[Foods.Egg] = 2;
            gameModel.Recipe.Cooked = false;



            gameModel.Recipe.FoodList.Add(Foods.Egg);
            gameModel.Recipe.FoodList.Add(Foods.Carrot);

            gameModel.Recipe.CurrentFoodIndex = 1; // one of egg's index is 0



            // Act
            kitchenServiceMock.Object.CookFood(Foods.Egg, gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Wrong item cauthed", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.CollectedFoods[Foods.Egg].Equals(1));
            Assert.That(gameModel.GarbageCount.Equals(5));
        }

        [Test]
        public void CookFood_NotGoodItemCaught_AND_GarbageWillBeFullTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.GarbageCount = 9;
            int maximum = 10;
            gameModel.GarbageCapacity = maximum;
            gameModel.CollectedFoods[Foods.Egg] = 2;
            gameModel.Recipe.Cooked = false;

            gameModel.Recipe.FoodList.Add(Foods.Egg);
            gameModel.Recipe.FoodList.Add(Foods.Carrot);

            gameModel.Recipe.CurrentFoodIndex = 1; // one of egg's index is 0


            // Act
            kitchenServiceMock.Object.CookFood(Foods.Egg, gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Hygenie Alert! Empty the trash.", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.GarbageCount.Equals(maximum));
        }

        [Test]
        public void CookFood_GoodItemCaught_ButItIsNotTheLastoneInTheRecipeTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.GarbageCount = 0;
            int maximum = 10;
            gameModel.GarbageCapacity = maximum;
            gameModel.CollectedFoods[Foods.Egg] = 2;
            gameModel.Recipe.Cooked = false;

            gameModel.Recipe.FoodList.Add(Foods.Egg);
            gameModel.Recipe.FoodList.Add(Foods.Carrot);

            int oldindex = 0;
            gameModel.Recipe.CurrentFoodIndex = oldindex; // one of egg's index is 2

            int oldGameScore = 0;
            gameModel.GameScore = oldGameScore;


            // Act
            kitchenServiceMock.Object.CookFood(Foods.Egg, gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("Food added to pot!", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.Recipe.CurrentFoodIndex.Equals(++oldindex));
            Assert.That(gameModel.GarbageCount.Equals(2));
            Assert.That(gameModel.Recipe.Cooked.Equals(false));
            Assert.That(gameModel.GameScore.Equals(oldGameScore));
        }

        [Test]
        public void CookFood_GoodItemCaught_AndItIsTheLastoneInTheRecipeTest()
        {
            //Arrange
            var messengerMock = new Mock<IMessenger>();
            var kitchenServiceMock = new Mock<KitchenService>(messengerMock.Object);
            kitchenServiceMock.SetupAllProperties();

            var gameModel = GameModelTestData();
            gameModel.GarbageCount = 0;
            int maximum = 10;
            gameModel.GarbageCapacity = maximum;
            gameModel.CollectedFoods[Foods.Carrot] = 2;
            gameModel.Recipe.Cooked = false;


            gameModel.Recipe.FoodList.Add(Foods.Egg);
            gameModel.Recipe.FoodList.Add(Foods.Carrot);

            int oldGameScore = 0;
            gameModel.GameScore = oldGameScore;

            int oldindex = 1;
            gameModel.Recipe.CurrentFoodIndex = oldindex; // one of carrot's index is 1


            // Act
            kitchenServiceMock.Object.CookFood(Foods.Carrot, gameModel);

            // Assert
            messengerMock.Verify(messenger => messenger.Send("The dish is complete. Sell or heal!", "KitchenBlOperationResult"), Times.Once());
            Assert.That(gameModel.Recipe.CurrentFoodIndex.Equals(oldindex));
            Assert.That(gameModel.Recipe.Cooked.Equals(true));
            Assert.That(gameModel.GarbageCount.Equals(1));
            Assert.That(gameModel.GameScore.Equals(oldGameScore += gameModel.Recipe.RecipeScore));
        }



    }
}
