using System;
using System.Drawing;

namespace Game.Model
{
    public class Interior : GameObject
    {
        public readonly TypeInterior Type;
        public Interior(Game game, Point position, Size size,TypeInterior type)
            : base(game, position, size)
        {
            Type = type;
        }

    }

    public enum TypeInterior
    {
        Furnace,
        Table,
        Chair,
        Bench,
        Wall,
        Chest,
        Piano,
        Clock,
        Barrels,
        Wardrobe
    }
}