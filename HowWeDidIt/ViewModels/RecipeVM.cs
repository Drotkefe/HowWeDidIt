using HowWeDidIt.Core.Enums;
using HowWeDidIt.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowWeDidIt.ViewModels
{
    public class RecipeVM : ObservableObject
    {
        private Recipe recipe;

        public string Name
        {
            get { return recipe?.Name ?? null; }
            //set
            //{
            //    SetProperty(recipe.Name, value, recipe, (gm, val) => gm.Name = val);
            //}
        }


        public List<Foods> FoodList
        {
            get { return recipe?.FoodList ?? null; }
            //set
            //{
            //    SetProperty(recipe.FoodList, value, recipe, (gm, val) => gm.FoodList = val);
            //}
        }

        public TimeSpan CookingTime
        {
            get { return recipe?.CookingTime ?? default; }
            set
            {
                SetProperty(recipe.CookingTime, value, recipe, (gm, val) => gm.CookingTime = val);
            }
        }

        public int RecipeScore
        {
            get { return recipe?.RecipeScore ?? 0; }
            //set
            //{
            //    SetProperty(recipe.RecipeScore, value, recipe, (gm, val) => gm.RecipeScore = val);
            //}
        }

        public int VitalityValue
        {
            get { return recipe?.VitalityValue ?? 0; }
            //set
            //{
            //    SetProperty(recipe.VitalityValue, value, recipe, (gm, val) => gm.VitalityValue = val);
            //}
        }

        public int MoneyValue
        {
            get { return recipe?.MoneyValue ?? 0; }
            //set
            //{
            //    SetProperty(recipe.MoneyValue, value, recipe, (gm, val) => gm.MoneyValue = val);
            //}
        }


        public Foods CurrentFood
        {
            get { return recipe?.FoodList[recipe.CurrentFoodIndex] ?? default; }
            //set
            //{
            //    SetProperty(recipe.CurrentFood, value, recipe, (gm, val) => gm.CurrentFood = val);
            //}
        }

        public bool Cooked  // NECESSARY HERE?
        {
            get { return recipe?.Cooked ?? false; }
            //set
            //{
            //    SetProperty(recipe.Cooked, value, recipe, (gm, val) => gm.Cooked = val);
            //}
        }



        public RecipeVM(Recipe recipe)
        {
            this.recipe = recipe;
        }


    }
}
