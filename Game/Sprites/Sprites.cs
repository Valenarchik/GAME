using System.Drawing;
using System.IO;

namespace Game
{
    public class Sprites
    {
        private static readonly string spritesFolder =
            Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent?.Parent?.Parent?.FullName ?? string.Empty, "Sprites");

        public class Chef
        {
            public static readonly Bitmap MoveDown1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Down 1.png")));

            public static readonly Bitmap MoveDown2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Down 2.png")));

            public static readonly Bitmap MoveLeft1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Left 1.png")));

            public static readonly Bitmap MoveLeft2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Left 2.png")));

            public static readonly Bitmap MoveRight1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Right 1.png")));

            public static readonly Bitmap MoveRight2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Right 2.png")));

            public static readonly Bitmap MoveUp1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Up 1.png")));

            public static readonly Bitmap MoveUp2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Up 2.png")));

            public static readonly Bitmap StandUp =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Stand", "Stand Up.png")));

            public static readonly Bitmap StandDown =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Stand", "Stand Down.png")));

            public static readonly Bitmap StandLeft =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Stand", "Stand Left.png")));

            public static readonly Bitmap StandRight =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Stand", "Stand Right.png")));
        }

        public class VisitorOne
        {
            public static readonly Bitmap MoveDown1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Move", "Move Down 1.png")));

            public static readonly Bitmap MoveDown2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Move", "Move Down 2.png")));

            public static readonly Bitmap MoveLeft1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Move", "Move Left 1.png")));

            public static readonly Bitmap MoveLeft2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Move", "Move Left 2.png")));

            public static readonly Bitmap MoveRight1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Move", "Move Right 1.png")));

            public static readonly Bitmap MoveRight2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Move", "Move Right 2.png")));

            public static readonly Bitmap MoveUp1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Move", "Move Up 1.png")));

            public static readonly Bitmap MoveUp2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Move", "Move Up 2.png")));

            public static readonly Bitmap StandUp =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Stand", "Stand Up.png")));

            public static readonly Bitmap StandDown =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Stand", "Stand Down.png")));

            public static readonly Bitmap StandLeft =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Stand", "Stand Left.png")));

            public static readonly Bitmap StandRight =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor One", "Stand", "Stand Right.png")));
        }
        public class VisitorTwo
        {
            public static readonly Bitmap MoveDown1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Move", "Move Down 1.png")));

            public static readonly Bitmap MoveDown2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Move", "Move Down 2.png")));

            public static readonly Bitmap MoveLeft1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Move", "Move Left 1.png")));

            public static readonly Bitmap MoveLeft2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Move", "Move Left 2.png")));

            public static readonly Bitmap MoveRight1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Move", "Move Right 1.png")));

            public static readonly Bitmap MoveRight2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Move", "Move Right 2.png")));

            public static readonly Bitmap MoveUp1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Move", "Move Up 1.png")));

            public static readonly Bitmap MoveUp2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Move", "Move Up 2.png")));

            public static readonly Bitmap StandUp =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Stand", "Stand Up.png")));

            public static readonly Bitmap StandDown =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Stand", "Stand Down.png")));

            public static readonly Bitmap StandLeft =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Stand", "Stand Left.png")));

            public static readonly Bitmap StandRight =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "NPS", "Visitor Two", "Stand", "Stand Right.png")));
        }
        
        public class Other
        {
            public static readonly Bitmap BackgroundImage =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Background and Interface", "Background.png")));
            public static readonly Bitmap TabBar =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Background and Interface", "tabbar.png")));
        }
        
        public class Meal
        {
            public static readonly Bitmap Cheese =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Meal", "cheese.png")));
            public static readonly Bitmap Dough =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Meal", "dough.png")));
            public static readonly Bitmap Peperoni =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Meal", "pepperoni.png")));
            public static readonly Bitmap Tomato =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Meal", "tomato.png")));
        }
        
        public class Interior
        {
            public static readonly Bitmap Chest =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "chest.png")));
            public static readonly Bitmap Wardrobe =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "wardrobe.png")));
            public static readonly Bitmap Cup =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "cup.png")));
            public static readonly Bitmap Clock1 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "clock1.png")));
            public static readonly Bitmap Clock2 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "clock2.png")));
            public static readonly Bitmap Clock3 =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "clock3.png")));
            public static readonly Bitmap Wall =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "wall.png")));
            public static readonly Bitmap Barrels =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "barrels.png")));
        }
    }
}