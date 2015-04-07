namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Common;

    class Toothpaste : Product, IToothpaste
    {
        private const int MinimumIngredientLength = 4;
        private const int MaximumIngredientLength = 12;

        private string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) : base(name, brand, price, gender)
        {
            this.Ingredients = string.Join(", ", ingredients);
        }

        public string Ingredients
        {
            get
            { 
                return this.ingredients;
            }
            set
            {
                // extract all ingridients and check each one
                List<string> ingredientsList = value.Split(new string[] { ", " }, StringSplitOptions.None).ToList();
                foreach (var ingredient in ingredientsList)
                {
                    Validator.CheckIfStringLengthIsValid(ingredient, MaximumIngredientLength, MinimumIngredientLength,
                        string.Format(GlobalErrorMessages.InvalidStringLength,
                            "Each ingredient",
                            MinimumIngredientLength,
                            MaximumIngredientLength));
                }
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            string baseDisplay = base.Print();
            StringBuilder toothpasteDisplay = new StringBuilder();
            toothpasteDisplay.Append(baseDisplay);
            toothpasteDisplay.AppendLine(String.Format("  * Ingredients: {0}", this.ingredients));
            return toothpasteDisplay.ToString().Trim();
        }
    }
}