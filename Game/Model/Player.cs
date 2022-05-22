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
        public const int InventorySize = 10;
        public bool CanGo = true;
        public override void Move(Direction direction)
        {
            if(CanGo)base.Move(direction);
        }

        public Player(Game game, Point position, int speed, Size size) : base(game, position, speed, size)
        {
        }
        
        public void AcceptOrder()
        {
            var visitor = Game.Visitors.FirstOrDefault(x=>!x.OrderAccepted);
            if(visitor is null || !visitor.OrderIsActivated) return;
            if (Game.InZone(this,visitor,ActivationRadius))
                visitor.OrderAccepted = true;
        }

        public void CompleteOrder()
        {
            var visitor = Game.Visitors.FirstOrDefault(x => x.OrderAccepted && !x.OrderIsCompleted);
            if(visitor is null) return;

            if (!Game.InZone(this, visitor, ActivationRadius)) return;
            var pizzaNotFound = true;
            for (var i = 0; i < Inventory.Count; i++)
            {
                var pizza = Inventory[i];
                if (pizza.Type != visitor.WantPizzaType || !pizza.IsCook || pizza.IsBurnedDown) continue;
                Inventory[i] = null;
                pizzaNotFound = false;
                break;
            }
            if (pizzaNotFound) return;
            visitor.OrderIsCompleted = true;
            visitor.GoToExit();
        }
    }
}
