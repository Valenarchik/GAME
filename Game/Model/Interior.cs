using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Game.Model
{
    public class Interior : GameObject
    {
        public Interior(Game game, Point position, Size size) : base(game, position, size)
        {
        }
    }

    public class RifledBoard : Interior
    {
        public readonly List<Ingredient> IngredientsForCooking = new();
        private int maxIngredientsCount = 4;
        
        public Pizza RawPizza; 
        public RifledBoard(Game game, Point position, Size size) : base(game, position, size)
        {
        }
        
        public void MakePizza()
        {
            if (IngredientsForCooking.Count<maxIngredientsCount)
                return;
            foreach (var (pizza, ingredients) in Game.Recipes)
            {
                if (IngredientsForCooking.Any(x => !ingredients.Contains(x))) continue;
                RawPizza = new Pizza(pizza);
                return;
            }

            RawPizza = null;
            IngredientsForCooking.Clear();
        }
    }

    public class Furnace :Interior
    {
        public Pizza Pizza { get; set; }
        public bool IsKindled { get; set; }
        public Furnace(Game game, Point position, Size size) : base(game, position, size)
        {
        }

        public void CookPizza(Pizza pizza)
        {
            pizza.IsCook = true;
        }
        
    }
}