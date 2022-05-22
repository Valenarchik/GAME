namespace Game.Model
{
    public class Pizza
    {
        public PizzaType Type { get; set; }
        public bool IsCook { get; set; }
        public bool IsBurnedDown { get; set; }

        public Pizza()
        {
            
        }
        public Pizza(PizzaType type)
        {
            Type = type;
        }
    }
}