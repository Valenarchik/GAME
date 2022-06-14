using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.SpritesAndMusic;
using Model;
using Interior = Game.SpritesAndMusic.Interior;

namespace Game
{
    public partial class MyForm
    {
        private void OnPaint(object sender, PaintEventArgs e)
        {
            PlayWalkSound();
            ImageAnimator.UpdateFrames();
            PaintTrashBox(e.Graphics);
            PaintCoin(e.Graphics);
            PaintFurnace(e.Graphics);
            PaintClock(e.Graphics);
            PaintVisitor(e.Graphics, game.Visitors.Where(x => x.Position.Y <= game.Player.Position.Y));
            PaintPlayer(e.Graphics);
            PaintVisitor(e.Graphics, game.Visitors.Where(x => x.Position.Y > game.Player.Position.Y));
            PaintInterior(e.Graphics);
            PaintTabBar(e.Graphics);
        }

        private void PaintTrashBox(Graphics g) => g.DrawImage(SpritesAndMusic.Interior.TrashBox, new Point(837, 198));
        private void PaintCoin(Graphics g) => g.DrawImage(Interface.Coin, new Point(18, 9));
        private void PaintClock(Graphics g) => g.DrawImage(Interior.Clock, new Point(62, 94));
        
        private void PaintFurnace(Graphics g)
        {
            foreach (var furnace in game.Furnaces.Where(furnace => furnace.IsKindled))
            {
                g.DrawImage(Interior.Furnace, furnace.Position);
                g.DrawImage(Interface.Load[furnace.Pizza.Progress],furnace.Position-new Size(7,36));
            }
            
        }

        private void PaintTabBar(Graphics g)
        {
            g.DrawImage(Interface.TabBar, new Point(481, 636));
            var offset = new Size(50, 0);
            var currentPos = new Point(491, 642);
            foreach (var pizza in game.Player.Inventory)
            {
                if(pizza is null) continue;
                if(pizza.IsBurnedDown)
                    g.DrawImage(Meal.BurntPizza,currentPos);
                else
                {
                    var pizzaSprite = DecodePizza(pizza.Type, false);
                    g.DrawImage(pizzaSprite, currentPos);
                    if (pizza.IsCook)
                        g.DrawImage(Meal.Steam, currentPos);
                }
                currentPos += offset;
            }
        }
        
        private void PaintPlayer(Graphics g)
        {
            EntityAnimation(g, game.Player, chefSprites);
            var visitor = game.Visitors.FirstOrDefault(x => !x.OrderIsCompleted);
            if (visitor is not null
                && visitor.OrderIsActivated
                && !visitor.OrderIsCompleted
                && global::Model.Game.InZone(game.Player, visitor, Player.ActivationRadius)
                || global::Model.Game.InZone(game.Player, game.RifledBoard, Player.LittleActivationRadius)
                || game.Furnaces.Any(interior => global::Model.Game.InZone(game.Player, interior, Player.LittleActivationRadius))
                || global::Model.Game.InZone(game.Player, game.TrashBox, Player.LittleActivationRadius))
            {
                buttonE.Show();
                buttonE.Location = game.Player.Position + new Size(30, -48);
            }
            else
                buttonE.Hide();
        }

        private void PaintVisitor(Graphics g, IEnumerable<Visitor> visitors)
        {
            foreach (var visitor in visitors)
            {
                if (visitor.TypeVisitor == TypeVisitor.Green)
                    EntityAnimation(g, visitor, visitorOneSprites);
                else
                    EntityAnimation(g, visitor, visitorTwoSprites);
                if(visitor.OrderIsActivated && !visitor.OrderIsCompleted)
                {
                    g.DrawImage(Interface.Dream,
                        visitor.Position + new Size(15, -75));
                    g.DrawImage(DecodePizza(visitor.WantPizzaType, false),
                        visitor.Position + new Size(32, -68));
                    g.DrawImage(Meal.Steam,
                        visitor.Position + new Size(32, -68));
                }
            }
        }

        private void PaintInterior(Graphics g)
        {
            if (game.Player.Position.Y <= 328)
                g.DrawImage(Interior.Wall, new Point(611, 278));
            if (game.Player.Position.Y <= 650)
                g.DrawImage(Interior.Barrels, new Point(40, 608));
            if (game.Player.Position.Y <= 161)
                g.DrawImage(Interior.Wardrobe, new Point(577, 127));
            if (game.Player.Position.Y <= 344)
                g.DrawImage(Interior.Cup, new Point(424, 336));
            if (game.Player.Position.Y <= game.TrashBox.Position.Y)
                g.DrawImage(Interior.TrashBox, new Point(837, 198));
        }
    }
}