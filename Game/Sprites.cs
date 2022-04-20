using System;
using System.Drawing;
using System.IO;

namespace Game
{
    public class Sprites
    {
        private static readonly string spritesFolder =
            Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Sprites");

        public static readonly Bitmap ChefMoveDown1 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef","Move","Move Down 1.png")));

        public static readonly Bitmap ChefMoveDown2 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef","Move","Move Down 2.png")));

        public static readonly Bitmap ChefMoveLeft1 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef","Move","Move Left 1.png")));

        public static readonly Bitmap ChefMoveLeft2 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef","Move","Move Left 2.png")));

        public static readonly Bitmap ChefMoveRight1 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef","Move","Move Right 1.png")));

        public static readonly Bitmap ChefMoveRight2 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef","Move","Move Right 2.png")));

        public static readonly Bitmap ChefMoveUp1 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Up 1.png")));

        public static readonly Bitmap ChefMoveUp2 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Move", "Move Up 2.png")));

        public static readonly Bitmap ChefStandUp =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Stand", "Stand Up.png")));

        public static readonly Bitmap ChefStandDown =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Stand", "Stand Down.png")));

        public static readonly Bitmap ChefStandLeft =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Stand", "Stand Left.png")));

        public static readonly Bitmap ChefStandRight =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Chef", "Stand", "Stand Right.png")));
    }
}