using GalaSoft.MvvmLight;
using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
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
        private int onionCount;
        public int OnionCount
        {
            get { return onionCount; }
            set
            {
                Set(ref onionCount, value);
                collectedFoods[Foods.Onion] = value;
            }
        }

        private int carrotCount;
        public int CarrotCount
        {
            get { return carrotCount; }
            set
            {
                Set(ref carrotCount, value);
                collectedFoods[Foods.Carrot] = value;
            }
        }

        private int potatoCount;
        public int PotatoCount
        {
            get { return potatoCount; }
            set
            {
                Set(ref potatoCount, value);
                collectedFoods[Foods.Potato] = value;
            }
        }

        private int eggCount;
        public int EggCount
        {
            get { return eggCount; }
            set
            {
                Set(ref eggCount, value);
                collectedFoods[Foods.Egg] = value;
            }
        }

        private int meatCount;
        public int MeatCount
        {
            get { return meatCount; }
            set
            {
                Set(ref meatCount, value);
                collectedFoods[Foods.Meat] = value;
            }
        }

        private int uraniumCount;
        public int UraniumCount
        {
            get { return uraniumCount; }
            set
            {
                Set(ref uraniumCount, value);
                collectedFoods[Foods.Uranium] = value;
            }
        }

        #endregion

        #region Capacities       
        private int onionCapacity;
        public int OnionCapacity
        {
            get { return onionCapacity; }
            set
            {
                Set(ref onionCapacity, value);
                foodCapacities[Foods.Onion] = value;
            }
        }

        private int carrotCapacity;
        public int CarrotCapacity
        {
            get { return carrotCapacity; }
            set
            {
                Set(ref carrotCapacity, value);
                foodCapacities[Foods.Carrot] = value;
            }
        }

        private int potatoCapacity;
        public int PotatoCapacity
        {
            get { return potatoCapacity; }
            set
            {
                Set(ref potatoCapacity, value);
                foodCapacities[Foods.Potato] = value;
            }
        }

        private int eggCapacity;
        public int EggCapacity
        {
            get { return eggCapacity; }
            set
            {
                Set(ref eggCapacity, value);
                foodCapacities[Foods.Egg] = value;
            }
        }

        private int meatCapacity;
        public int MeatCapacity
        {
            get { return meatCapacity; }
            set
            {
                Set(ref meatCapacity, value);
                foodCapacities[Foods.Meat] = value;
            }
        }

        private int uraniumCapacity;
        public int UraniumCapacity
        {
            get { return uraniumCapacity; }
            set
            {
                Set(ref uraniumCapacity, value);
                foodCapacities[Foods.Uranium] = value;
            }
        }

        #endregion


        public IngredientsVM()
        {

        }

        public IngredientsVM(Dictionary<Foods, int> collectedFoods, Dictionary<Foods, int> foodCapacities)
        {
            this.collectedFoods = collectedFoods;
            this.foodCapacities = collectedFoods;

            this.onionCount = collectedFoods[Foods.Onion];
            this.carrotCount = collectedFoods[Foods.Carrot];
            this.potatoCount = collectedFoods[Foods.Potato];
            this.eggCount = collectedFoods[Foods.Egg];
            this.meatCount = collectedFoods[Foods.Meat];
            this.uraniumCount = collectedFoods[Foods.Uranium];

            this.onionCapacity = foodCapacities[Foods.Onion];
            this.carrotCapacity = foodCapacities[Foods.Carrot];
            this.potatoCapacity = foodCapacities[Foods.Potato];
            this.eggCapacity = foodCapacities[Foods.Egg];
            this.meatCapacity = foodCapacities[Foods.Meat];
            this.uraniumCapacity = foodCapacities[Foods.Uranium];
        }
    }

}
