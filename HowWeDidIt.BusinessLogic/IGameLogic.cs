﻿using HowWeDidIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.BusinessLogic
{
    public interface IGameLogic
    {
        IGameModel GameModel { get; set; }
        event EventHandler CallRefresh;

        bool Move(double dx, double dy);

        void FoodItemsFalling();
        void FoodItemCaught(MovingFoodItem foodItem);
        void Save(); 
    }
}
