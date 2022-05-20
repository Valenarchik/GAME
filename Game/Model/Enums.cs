namespace Game.Model
{
    public enum Ingredient
    {
        Empty,
        Dough,
        Tomato,
        Pepperoni,
        Cheese
    }
    
    public enum Pizza
    {
        Empty,
        Friday,
        Rustic,
        Pepperoni,
        Greek,
        Bavarian
    }
    public enum TypeVisitor
    {
        Red,
        Green
    }

    public enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
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