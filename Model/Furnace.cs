using System;
using System.Drawing;
using System.Linq;
using System.Timers;

namespace Model
{
    public class Furnace : Interior
    {
        public readonly Timer Timer = new();
        public Pizza Pizza { get; set; }
        public bool IsKindled { get; private set; }
        public static event Action OnStartCoking;
        public static event Action OnEndCoking;

        public Furnace(Game game, Point position, Size size, int timeCookInSecond = 4) : base(game, position, size)
        {
            Timer.Interval = timeCookInSecond * 1000;
            Timer.Elapsed += (_, _) =>
            {
                if (Pizza == null) return;
                Pizza.Progress++;
            };
        }


        public void ToDefault()
        {
            Pizza = default;
            IsKindled = default;
            Timer.Stop();
        }
        public void StartCooking()
        { 
            Pizza = Game.Player.Inventory.FirstOrDefault(pizza => !pizza.IsCook);
            if (Pizza is null)
                return;
            IsKindled = true;
            Game.Player.Inventory.Remove(Pizza);
            Timer.Start();
            OnStartCoking?.Invoke();
        }

        public void EndCooking()
        {
            IsKindled = false;
            Game.Player.Inventory.Add(Pizza);
            Pizza = null;
            Timer.Stop();
            OnEndCoking?.Invoke();
        }
    }
}