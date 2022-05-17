using System.Drawing;
using System.Linq;

namespace Game.Model
{
    public class Player:GameEntity
    {
        public readonly Ingredients[] Inventory;

        public Player(Game game, Point position, int speed, Size size) : base(game, position, speed, size)
        {
            Inventory = new Ingredients[10];
            Sell = MapSell.Player;
        }
        

        public Interior GetNeighbourInRadius(double radius, params TypeInterior[] types)
        {
            if (types == null)
                return null;
            var min = double.MaxValue;
            Interior result = null;
            foreach (var type in types)
            foreach (var interior in Game.Interiors[type])
            {
                if (Game.InZone(interior, this, radius))
                {
                    var distance = Game.GetDistance(interior.Centre, Centre);
                    if (!(distance < min)) continue;
                    min = distance;
                    result = interior;
                }
            }

            return result;
        }
    }

    public enum Ingredients
    {
        Empty,
        Dough,
        Tomato,
        Pepperoni,
        Cheese 
    }
}
