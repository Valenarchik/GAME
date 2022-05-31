using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Model
{
    public class RifledBoard : Interior
    {
        public readonly List<Ingredient> IngredientsForCooking = new();
        public const int MaxIngredientsCount = 4;
        public event Action OnMakePizzaSuccess; 
        public event Action OnMakePizzaFailure; 
        public Pizza RawPizza; 
        public RifledBoard(Game game, Point position, Size size) : base(game, position, size)
        {
        }
        
        public  void MakePizza()
        {
            if(RawPizza is not null && Game.Player.Inventory.Count<Player.InventorySize)
                Game.Player.Inventory.Add(RawPizza);
            foreach (var e in Game.Recipes)
            {
                var pizza = e.Key;
                var ingredients = e.Value;
                var ing = new HashSet<Ingredient>(ingredients);
                if (IngredientsForCooking.Count==0 || !IngredientsForCooking.All(x =>
                    {
                        if (!ing.Contains(x)) return false;
                        ing.Remove(x);
                        return true;
                    })) continue;
                OnMakePizzaSuccess?.Invoke();
                RawPizza = new Pizza(pizza);
                IngredientsForCooking.Clear();
                return;
            }

            RawPizza = null;
            Game.Money += 4*Game.PriceIngredients;
            IngredientsForCooking.Clear();
            OnMakePizzaFailure?.Invoke();
            ;
        }
    }
}