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
            set
            {
                SetProperty(recipe.Name, value, recipe, (rec, val) => rec.Name = val);
            }
        }

        public List<Foods> FoodList
        {
            get { return recipe?.FoodList ?? null; }
            set
            {
                SetProperty(recipe.FoodList, value, recipe, (rec, val) => rec.FoodList = val);
            }
        }

        public TimeSpan CookingTime
        {
            get { return recipe?.CookingTime ?? default; }
            set
            {
                SetProperty(recipe.CookingTime, value, recipe, (rec, val) => rec.CookingTime = val);
            }
        }

        public int RecipeScore
        {
            get { return recipe?.RecipeScore ?? 0; }
            set
            {
                SetProperty(recipe.RecipeScore, value, recipe, (rec, val) => rec.RecipeScore = val);
            }
        }

        public int VitalityValue
        {
            get { return recipe?.VitalityValue ?? 0; }
            set
            {
                SetProperty(recipe.VitalityValue, value, recipe, (rec, val) => rec.VitalityValue = val);
            }
        }

        public int MoneyValue
        {
            get { return recipe?.MoneyValue ?? 0; }
            set
            {
                SetProperty(recipe.MoneyValue, value, recipe, (rec, val) => rec.MoneyValue = val);
            }
        }


        public Foods CurrentFood
        {
            get { return recipe?.FoodList[recipe.CurrentFoodIndex] ?? default; }
            //set
            //{
            //    SetProperty(recipe.CurrentFood, value, recipe, (rec, val) => rec.CurrentFood = val);
            //}
        }

        public bool Cooked  // NECESSARY HERE?
        {
            get { return recipe?.Cooked ?? false; }
            set
            {
                SetProperty(recipe.Cooked, value, recipe, (rec, val) => rec.Cooked = val);
            }
        }



        public RecipeVM(Recipe recipe)
        {
            this.recipe = recipe;
        }


    }
}
