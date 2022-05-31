using System;
using System.Drawing;
using System.Linq;

namespace Model
{
    public class Interior : GameObject
    {
        public Interior(Game game, Point position, Size size) : base(game, position, size)
        {
        }
    }

    public class TrashBox : Interior
    {
        public event Action ThrowOutTrash; 
        public TrashBox(Game game, Point position, Size size) : base(game, position, size)
        {
        }

        public void OnThrowOutTrash()
        {
            var burnedPizza = Game.Player.Inventory.FirstOrDefault(x => x.IsBurnedDown);
            if (burnedPizza is null || !Game.InZone(this,Game.Player,Player.LittleActivationRadius))
                return;
            Game.Player.Inventory.Remove(burnedPizza);
            ThrowOutTrash?.Invoke();
        }
    }
}