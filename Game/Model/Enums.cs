namespace Game.Model
{
    public enum Ingredient
    {
        Empty = 0,
        Dough = 1,
        Tomato = 2,
        Pepperoni = 3,
        Cheese = 4,
        ChickenFillet = 5,
        TomatoSauce = 6,
        Mushroom = 7,
        Basil = 8,
    }
    
    public enum PizzaType
    {
        Greens = 0,
        Diabola = 1,
        Pepperoni = 2,
        Margaret = 3
    }
    public enum TypeVisitor
    {
        Red = 0,
        Green = 1
    }

    public enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }
}