using System.Collections.Generic;
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
        
        public static readonly Bitmap Ok = new(Image.FromFile(Path.Combine(spritesFolder, "Ok.png")));
        public static readonly Bitmap Dream = new(Image.FromFile(Path.Combine(spritesFolder, "Dream.png")));
        public static readonly Bitmap BackgroundImage = new(Image.FromFile(Path.Combine(spritesFolder, "Background.png")));
        public static readonly Bitmap RifledBoard = new (Image.FromFile(Path.Combine(spritesFolder, "RifledBoard.png")));
        public static readonly Bitmap CloseButton = new (Image.FromFile(Path.Combine(spritesFolder, "closeButton.png")));
        public static readonly Bitmap TabBar = new(Image.FromFile(Path.Combine(spritesFolder, "tabbar.png")));
        public static readonly Bitmap Coin = new(Image.FromFile(Path.Combine(spritesFolder, "Coin.png")));
        
        public static readonly Bitmap ButtonE = new(Path.Combine(spritesFolder, "buttonE.gif"));

        private static  readonly string loadSpritesFolder = Path.Combine(spritesFolder, "Load");
        public static readonly List<Bitmap> Load = new()
        {
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load1.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load2.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load3.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load4.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load5.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load6.png"))),
            new Bitmap(Image.FromFile(Path.Combine(loadSpritesFolder, "Load7.png")))
        };
    }

    public static class Meal
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Meal");
        
        public static readonly Bitmap Steam = new(Image.FromFile(Path.Combine(spritesFolder, "Steam.png")));
        
        public static readonly Bitmap Cheese = new(Image.FromFile(Path.Combine(spritesFolder, "Cheese.png")));
        public static readonly Bitmap Dough = new(Image.FromFile(Path.Combine(spritesFolder, "Dough.png")));
        public static readonly Bitmap Pepperoni = new(Image.FromFile(Path.Combine(spritesFolder, "Pepperoni.png")));
        public static readonly Bitmap Tomato = new(Image.FromFile(Path.Combine(spritesFolder, "Tomato.png")));
        public static readonly Bitmap TomatoSauce = new(Image.FromFile(Path.Combine(spritesFolder, "TomatoSauce.png")));
        public static readonly Bitmap Basil = new(Image.FromFile(Path.Combine(spritesFolder, "Basil.png")));
        public static readonly Bitmap Mushroom = new(Image.FromFile(Path.Combine(spritesFolder, "Mushroom.png")));
        public static readonly Bitmap Chicken = new(Image.FromFile(Path.Combine(spritesFolder, "Chicken.png")));
        
        public static readonly Bitmap BigCheese = new(Image.FromFile(Path.Combine(spritesFolder, "BigCheese.png")));
        public static readonly Bitmap BigDough = new(Image.FromFile(Path.Combine(spritesFolder, "BigDough.png")));
        public static readonly Bitmap BigPepperoni = new(Image.FromFile(Path.Combine(spritesFolder, "BigPepperoni.png")));
        public static readonly Bitmap BigTomato = new(Image.FromFile(Path.Combine(spritesFolder, "BigTomato.png")));
        public static readonly Bitmap BigTomatoSauce = new(Image.FromFile(Path.Combine(spritesFolder, "BigTomatoSauce.png")));
        public static readonly Bitmap BigBasil = new(Image.FromFile(Path.Combine(spritesFolder, "BigBasil.png")));
        public static readonly Bitmap BigMushroom = new(Image.FromFile(Path.Combine(spritesFolder, "BigMushroom.png")));
        public static readonly Bitmap BigChicken = new(Image.FromFile(Path.Combine(spritesFolder, "BigChicken.png")));
        
        public static readonly Bitmap PizzaDiabola = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaDiabola.png")));
        public static readonly Bitmap PizzaGreen = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaGreens.png")));
        public static readonly Bitmap PizzaMargaret = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaMargaret.png")));
        public static readonly Bitmap PizzaPepperoni = new(Image.FromFile(Path.Combine(spritesFolder, "PizzaPepperoni.png")));
        public static readonly Bitmap BurntPizza = new(Image.FromFile(Path.Combine(spritesFolder, "BurntPizza.png")));
        
        public static readonly Bitmap BigPizzaDiabola = new(Image.FromFile(Path.Combine(spritesFolder, "BigPizzaDiabola.png")));
        public static readonly Bitmap BigPizzaGreen = new(Image.FromFile(Path.Combine(spritesFolder, "BigPizzaGreens.png")));
        public static readonly Bitmap BigPizzaMargaret = new(Image.FromFile(Path.Combine(spritesFolder, "BigPizzaMargaret.png")));
        public static readonly Bitmap BigPizzaPepperoni = new(Image.FromFile(Path.Combine(spritesFolder, "BigPizzaPepperoni.png")));
    }

    public static class Interior
    {
        private static readonly string spritesFolder = Path.Combine(Sprites.SpritesFolder, "Interior");

        public static readonly Bitmap Clock = new(Path.Combine(spritesFolder, "clock.gif"));
        public static readonly Bitmap Furnace = new(Path.Combine(spritesFolder, "furnaceTypeOne.gif"));
        public static readonly Bitmap Flashlight = new(Path.Combine(spritesFolder, "flashlight.gif"));

        public static readonly Bitmap Wardrobe = new(Image.FromFile(Path.Combine(spritesFolder, "wardrobe.png")));
        public static readonly Bitmap Cup = new(Image.FromFile(Path.Combine(spritesFolder, "cup.png")));
        public static readonly Bitmap Wall = new(Image.FromFile(Path.Combine(spritesFolder, "wall.png")));
        public static readonly Bitmap Barrels = new(Image.FromFile(Path.Combine(spritesFolder, "barrels.png")));
    }
}