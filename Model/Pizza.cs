using System;

namespace Model
{
    public class Pizza
    {
        public PizzaType Type { get; set; }
        public bool IsCook => progress >= 4;

        public bool IsMake;

        private int progress;

        public int Progress
        {
            get => progress;
            set => progress = Math.Min(6, value);
        }

        public bool IsBurnedDown => progress >= 6;
        
        public Pizza(PizzaType type)
        {
            Type = type;
        }
    }
}