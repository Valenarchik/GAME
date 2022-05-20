using System;
using System.Drawing;
using System.Linq;

namespace Game.Model
{
    public class Player:GameEntity
    {
        public readonly Pizza[] Inventory = new Pizza[10];
        public const int ActivationRadius = 65;

        public Player(Game game, Point position, int speed, Size size) : base(game, position, speed, size)
        {
        }
        

        public GameObject GetNeighbourInRadius(double radius, params Type[] types)
        {
            if (types == null) return null;
            var min = double.MaxValue;
            GameObject result = null;
            foreach (var type in types)
            foreach (var obj in Game.Objects)
            {
                if(obj.GetType() != type) continue;
                if (!Game.InZone(obj, this, radius)) continue;
                var distance = Game.GetDistance(obj.Centre, Centre);
                if (distance >= min) continue;
                min = distance;
                result = obj;
            }
            return result;
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
            // for (int i = 0; i < Inventory.Length; i++)
            // {
            //     if(i==Inventory.Length - 1) return;
            //     if(Inventory[i] != visitor.WantPizza) continue;
            //     Inventory[i] = Pizza.Empty;
            //     break;
            // }
            if (Game.InZone(this,visitor,ActivationRadius))
            {
                visitor.OrderIsCompleted = true;
                visitor.GoToExit();
            }
        }
    }
}
