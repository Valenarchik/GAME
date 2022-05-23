using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
        public const int MaxIngredientsCount = 4;

        public Pizza RawPizza; 
        public RifledBoard(Game game, Point position, Size size) : base(game, position, size)
        {
        }
        
        public void MakePizza()
        {
            foreach (var (pizza, ingredients) in Game.Recipes)
            {
                var ing = new HashSet<Ingredient>(ingredients);
                if (!IngredientsForCooking.All(x =>
                    { 
                        if (!ing.Contains(x)) return false; 
                        ing.Remove(x);
                        return true;
                    })) continue;
                RawPizza = new Pizza(pizza);
                IngredientsForCooking.Clear();
                return;
            }
            RawPizza = null;
            IngredientsForCooking.Clear();
        }
    }

    public class Furnace :Interior
    {
        public readonly Timer Timer = new() {Interval = 5000};
        public Pizza Pizza { get; set; }
        public bool IsKindled { get; set; }
        public Furnace(Game game, Point position, Size size) : base(game, position, size)
        {
            Timer.Tick += (_, _) =>
            {
                if (Pizza == null) return;
                if (Pizza.IsCook)
                    Pizza.IsBurnedDown = true;
                Pizza.IsCook = true;
            };
        }
    }
}