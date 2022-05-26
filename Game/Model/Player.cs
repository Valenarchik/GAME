using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Game.Model
{
    public class Player:GameEntity
    {
        public readonly List<Pizza> Inventory = new();
        public const int ActivationRadius = 65;
        public const int LittleActivationRadius = 10;
        public const int InventorySize = 10;
        public Furnace NearestFurnace { get; set; }
        public bool CanGo { get; set; } = true;
        public override void Move(Direction direction)
        {
            if(CanGo)base.Move(direction);
        }

        public Player(Game game, Point position, int speed, Size size) : base(game, position, speed, size)
        {
        }
        
        public void CompleteOrder()
        {
            var visitor = Game.Visitors.FirstOrDefault(x => !x.OrderIsCompleted);
            if(visitor is null) return;

            if (!Game.InZone(this, visitor, ActivationRadius)) return;
            var pizzaNotFound = true;
            for (var i = 0; i < Inventory.Count; i++)
            {
                var pizza = Inventory[i];
                if (pizza.Type != visitor.WantPizzaType || !pizza.IsCook || pizza.IsBurnedDown) continue;
                Inventory.Remove(pizza);
                Game.Money += 7;
                pizzaNotFound = false;
                break;
            }
            if (pizzaNotFound) return;
            visitor.OrderIsCompleted = true;
            visitor.GoToExit();
        }

        public bool FindNearestFurnace()
        {
            var min = double.MaxValue;
            var flag = false;
            foreach (var gameFurnace in Game.Furnaces.Where(x=>Game.InZone(this,x,LittleActivationRadius)))
            {
                var dist = Game.GetDistance(Centre, gameFurnace.Centre);
                if (dist < min)
                {
                    min = dist;
                    NearestFurnace = gameFurnace;
                    flag = true;
                }
            }

            if (flag)
                return true;
            NearestFurnace = null;
            return false;
        }
    }
}
