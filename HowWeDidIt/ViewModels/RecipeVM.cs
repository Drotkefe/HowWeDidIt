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

        public BindingList<Foods> FoodList
        {
            get { return recipe?.FoodList != null ? new BindingList<Foods>(recipe.FoodList) : null; }
        }

        public int RecipeScore
        {
            get { return recipe?.RecipeScore ?? 0; }
        }

        public int VitalityValue
        {
            get { return recipe?.VitalityValue ?? 0; }
        }

        public int MoneyValue
        {
            get { return recipe?.MoneyValue ?? 0; }
        }

        public int CurrentFood
        {
            get { return recipe?.CurrentFoodIndex ?? 0; }
        }

        public bool Cooked
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
