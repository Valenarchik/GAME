using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;

namespace Model
{
    public class RifledBoard : Interior
    {
        public readonly List<Ingredient> IngredientsForCooking = new();
        
        public const int MaxIngredientsCount = 4;

        public bool EnoughIngredients => IngredientsForCooking.Count == MaxIngredientsCount; 
        public event Action OnMakePizzaSuccess; 
        public event Action OnEndMakePizza; 
        public event Action OnMakePizzaFailure; 
        
        public Pizza RawPizza;

        public readonly Timer Timer = new() {Interval = 3000};
        public RifledBoard(Game game, Point position, Size size) : base(game, position, size)
        {
            Timer.Elapsed += (_, _) =>
            {
                
                if (RawPizza is not null)
                {

                    RawPizza.IsMake = true;
                    OnEndMakePizza?.Invoke();
                }
                Timer.Stop();
            };
        }

        public void ToDefault()
        {
            IngredientsForCooking.Clear();
            RawPizza = null;
            Timer.Stop();
        }
        public void StartMakePizza()
        {
            MakePizza();
            Timer.Start();
        }
        
        private void MakePizza()
        {
            if(IngredientsForCooking.Count==0)
                return;
            
            if (RawPizza is null)
                foreach (var e in Game.Recipes)
                {
                    var pizza = e.Key;
                    var ingredients = e.Value;
                    var ing = new HashSet<Ingredient>(ingredients);
                    if (IngredientsForCooking.Count == 0 || !IngredientsForCooking.All(x =>
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
            
            Game.Money += 4*Game.PriceIngredients;
            IngredientsForCooking.Clear();
            OnMakePizzaFailure?.Invoke();
        }
    }
}