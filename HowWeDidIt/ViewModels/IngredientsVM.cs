//using GalaSoft.MvvmLight;
using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.ViewModels
{
    public class IngredientsVM : ObservableObject
    {
        private Dictionary<Foods, int> collectedFoods;
        private Dictionary<Foods, int> foodCapacities;


        #region Counts
        public int OnionCount
        {
            get { return collectedFoods?.GetValueOrDefault(Foods.Onion) ?? 0; }
            set
            {
                SetProperty(collectedFoods[Foods.Onion], value, collectedFoods, (cf, val) => cf[Foods.Onion] = val);
            }
        }


        public int CarrotCount
        {
            get { return collectedFoods?.GetValueOrDefault(Foods.Carrot) ?? 0; }
            set
            {
                SetProperty(collectedFoods[Foods.Carrot], value, collectedFoods, (cf, val) => cf[Foods.Carrot] = val);
            }
        }


        public int PotatoCount
        {
            get { return collectedFoods?.GetValueOrDefault(Foods.Potato) ?? 0; }
            set
            {
                SetProperty(collectedFoods[Foods.Potato], value, collectedFoods, (cf, val) => cf[Foods.Potato] = val);
            }
        }


        public int EggCount
        {
            get { return collectedFoods?.GetValueOrDefault(Foods.Egg) ?? 0; }
            set
            {
                SetProperty(collectedFoods[Foods.Egg], value, collectedFoods, (cf, val) => cf[Foods.Egg] = val);
            }
        }

        public int MeatCount
        {
            get { return collectedFoods?.GetValueOrDefault(Foods.Meat) ?? 0; }
            set
            {
                SetProperty(collectedFoods[Foods.Meat], value, collectedFoods, (cf, val) => cf[Foods.Meat] = val);
            }
        }


        public int UraniumCount
        {
            get { return collectedFoods?.GetValueOrDefault(Foods.Uranium) ?? 0; }
            set
            {
                SetProperty(collectedFoods[Foods.Uranium], value, collectedFoods, (cf, val) => cf[Foods.Uranium] = val);
            }
        }

        #endregion

        #region Capacities


        public int OnionCapacity
        {
            get { return foodCapacities?.GetValueOrDefault(Foods.Onion) ?? 0; }
            set
            {
                SetProperty(foodCapacities[Foods.Onion], value, foodCapacities, (cf, val) => cf[Foods.Onion] = val);
            }
        }

        public int CarrotCapacity
        {
            get { return foodCapacities?.GetValueOrDefault(Foods.Carrot) ?? 0; }
            set
            {
                SetProperty(foodCapacities[Foods.Carrot], value, foodCapacities, (cf, val) => cf[Foods.Carrot] = val);
            }
        }

        public int PotatoCapacity
        {
            get { return foodCapacities?.GetValueOrDefault(Foods.Potato) ?? 0; }
            set
            {
                SetProperty(foodCapacities[Foods.Potato], value, foodCapacities, (cf, val) => cf[Foods.Potato] = val);
            }
        }

        public int EggCapacity
        {
            get { return foodCapacities?.GetValueOrDefault(Foods.Egg) ?? 0; }
            set
            {
                SetProperty(foodCapacities[Foods.Egg], value, foodCapacities, (cf, val) => cf[Foods.Egg] = val);
            }
        }


        public int MeatCapacity
        {
            get { return foodCapacities?.GetValueOrDefault(Foods.Meat) ?? 0; }
            set
            {
                SetProperty(foodCapacities[Foods.Meat], value, foodCapacities, (cf, val) => cf[Foods.Meat] = val);
            }
        }

        public int UraniumCapacity
        {
            get { return foodCapacities?.GetValueOrDefault(Foods.Uranium) ?? 0; }
            set
            {
                SetProperty(foodCapacities[Foods.Uranium], value, foodCapacities, (cf, val) => cf[Foods.Uranium] = val);
            }
        }

        #endregion



        public IngredientsVM(Dictionary<Foods, int> collectedFoods, Dictionary<Foods, int> foodCapacities)
        {
            this.collectedFoods = collectedFoods;   //ref
            this.foodCapacities = foodCapacities;   //ref

        }
    }

}
