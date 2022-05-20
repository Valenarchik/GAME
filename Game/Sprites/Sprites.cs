using System.Drawing;
using System.IO;

namespace Game.Sprites
{
    public static class Sprites
    {
        public static readonly string SpritesFolder =
            Path.Combine
            (
                new DirectoryInfo
                (
                    Directory.GetCurrentDirectory()
                ).Parent?.Parent?.Parent?.FullName ?? string.Empty,
                "Sprites"
            );

        public static Size EntitySpriteSize = new Size(48, 64);
    }

    public abstract class EntitySprites
    {
        public Bitmap MoveUp;
        public Bitmap MoveRight;
        public Bitmap MoveDown;
        public Bitmap MoveLeft;

        public Bitmap StandUp;
        public Bitmap StandRight;
        public Bitmap StandDown;
        public Bitmap StandLeft;
    }

    public class ChefSprites : EntitySprites
    {
        public ChefSprites()
        {
            var spritesFolder = Path.Combine(Sprites.SpritesFolder, "Chef");
            var move = Path.Combine(spritesFolder, "Move");
            var stand = Path.Combine(spritesFolder, "Stand");
            MoveDown = new Bitmap(Path.Combine(move, "Move Down.gif"));
            MoveLeft = new Bitmap(Path.Combine(move, "Move Left.gif"));
            MoveRight = new Bitmap(Path.Combine(move, "Move Right.gif"));
            MoveUp = new Bitmap(Path.Combine(move, "Move Up.gif"));
            StandUp = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Up.png")));
            StandDown = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Down.png")));
            StandLeft = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Left.png")));
            StandRight = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Right.png")));
        }
    }

    public class VisitorOneSprites : EntitySprites
    {
        public VisitorOneSprites()
        {
            var spritesFolder = Path.Combine(Sprites.SpritesFolder, "NPS","Visitor One");
            var move = Path.Combine(spritesFolder, "Move");
            var stand = Path.Combine(spritesFolder, "Stand");
            MoveDown = new Bitmap(Path.Combine(move, "Move Down.gif"));
            MoveLeft = new Bitmap(Path.Combine(move, "Move Left.gif"));
            MoveRight = new Bitmap(Path.Combine(move, "Move Right.gif"));
            MoveUp = new Bitmap(Path.Combine(move, "Move Up.gif"));
            StandUp = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Up.png")));
            StandDown = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Down.png")));
            StandLeft = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Left.png")));
            StandRight = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Right.png")));
        }
    }

    public class VisitorTwoSprites : EntitySprites
    {
        public VisitorTwoSprites()
        {
            var spritesFolder = Path.Combine(Sprites.SpritesFolder, "NPS","Visitor Two");
            var move = Path.Combine(spritesFolder, "Move");
            var stand = Path.Combine(spritesFolder, "Stand");
            MoveDown = new Bitmap(Path.Combine(move, "Move Down.gif"));
            MoveLeft = new Bitmap(Path.Combine(move, "Move Left.gif"));
            MoveRight = new Bitmap(Path.Combine(move, "Move Right.gif"));
            MoveUp = new Bitmap(Path.Combine(move, "Move Up.gif"));
            StandUp = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Up.png")));
            StandDown = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Down.png")));
            StandLeft = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Left.png")));
            StandRight = new Bitmap(Image.FromFile(Path.Combine(stand, "Stand Right.png")));
        }
    }

    public static class Interface
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Background and Interface");

        public static readonly Bitmap BackgroundImage =
            new(Image.FromFile(Path.Combine(spritesFolder, "Background.png")));

        public static readonly Bitmap TabBar = new(Image.FromFile(Path.Combine(spritesFolder, "tabbar.png")));

        public static readonly Bitmap ButtonE = new(Path.Combine(spritesFolder, "buttonE.gif"));
    }

    public static class Meal
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Meal");
        public static readonly Bitmap Cheese = new(Image.FromFile(Path.Combine(spritesFolder, "cheese.png")));
        public static readonly Bitmap Dough = new(Image.FromFile(Path.Combine(spritesFolder, "dough.png")));
        public static readonly Bitmap Peperoni = new(Image.FromFile(Path.Combine(spritesFolder, "pepperoni.png")));
        public static readonly Bitmap Tomato = new(Image.FromFile(Path.Combine(spritesFolder, "tomato.png")));
    }

    public static class Interior
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Interior");

        public static readonly Bitmap Clock = new(Path.Combine(spritesFolder, "clock.gif"));
        public static readonly Bitmap FurnaceTypeOne = new(Path.Combine(spritesFolder, "furnaceTypeOne.gif"));
        public static readonly Bitmap Flashlight = new(Path.Combine(spritesFolder, "flashlight.gif"));

        public static readonly Bitmap Wardrobe = new(Image.FromFile(Path.Combine(spritesFolder, "wardrobe.png")));
        public static readonly Bitmap Cup = new(Image.FromFile(Path.Combine(spritesFolder, "cup.png")));
        public static readonly Bitmap Wall = new(Image.FromFile(Path.Combine(spritesFolder, "wall.png")));
        public static readonly Bitmap Barrels = new(Image.FromFile(Path.Combine(spritesFolder, "barrels.png")));
    }
}