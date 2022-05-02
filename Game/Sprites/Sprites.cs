using System.Drawing;
using System.IO;

namespace Game
{
    public class Sprites
    {
        private static readonly string spritesFolder =
            Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Sprites");

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
        
        public class Background
        {
            public static readonly Bitmap BackgroundImage =
                new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Background", "Background.png")));
        }
        
        // public class Interior
        // {
        //     public static readonly Bitmap Furnace =
        //         new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "furnace.png")));
        //     public static readonly Bitmap Crane =
        //         new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "crane.png")));
        //     public static readonly Bitmap Cups =
        //         new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "cups.png")));
        //     public static readonly Bitmap Table =
        //         new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Interior", "table.png")));
        // }
    }
}