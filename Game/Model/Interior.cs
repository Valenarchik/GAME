using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Sprites;

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
                if (IngredientsForCooking.Count==0 || !IngredientsForCooking.All(x =>
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
        private readonly Timer timer = new();
        public Pizza Pizza { get; set; }
        public bool IsKindled { get; private set; }
        public Furnace(Game game, Point position, Size size,int timeCookInSecond) : base(game, position, size)
        {
            timer.Interval = timeCookInSecond*1000;
            timer.Tick += (_, _) =>
            {
                if (Pizza == null) return;
                Pizza.Progress++;
            };
        }
        
        public void StartCooking()
        { 
            Pizza = Game.Player.Inventory.FirstOrDefault(pizza => !pizza.IsCook);
            if (Pizza is null)
                return;
            IsKindled = true;
            Game.Player.Inventory.Remove(Pizza);
            timer.Start();
        }

        public void EndCooking()
        {
            IsKindled = false;
            Game.Player.Inventory.Add(Pizza);
            Pizza = null;
            timer.Stop();
        }
    }
}