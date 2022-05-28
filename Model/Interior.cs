using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;

namespace Model
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
        public static event Action OnStartCoking;
        public static event Action OnEndCoking;
            public Furnace(Game game, Point position, Size size,int timeCookInSecond = 4) : base(game, position, size)
        {
            timer.Interval = timeCookInSecond*1000;
            timer.Elapsed += (_, _) =>
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
            OnStartCoking?.Invoke();
        }

        public void EndCooking()
        {
            IsKindled = false;
            Game.Player.Inventory.Add(Pizza);
            Pizza = null;
            timer.Stop();
            OnEndCoking?.Invoke();
        }
    }

    public class TrashBox : Interior
    {
        public event Action ThrowOutTrash; 
        public TrashBox(Game game, Point position, Size size) : base(game, position, size)
        {
        }

        public void OnThrowOutTrash()
        {
            var burnedPizza = Game.Player.Inventory.FirstOrDefault(x => x.IsBurnedDown);
            if (burnedPizza is null || !Game.InZone(this,Game.Player,Player.LittleActivationRadius))
                return;
            Game.Player.Inventory.Remove(burnedPizza);
            ThrowOutTrash?.Invoke();
        }
    }
}