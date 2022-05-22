using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Game.Model;
using Game.Sprites;
using Interior = Game.Sprites.Interior;

namespace Game
{
    public partial class MyForm
    {
        private void OnPaint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();
            //PaintMatrix(e.Graphics);
            PaintFurnace(e.Graphics);
            PaintClock(e.Graphics);
            PaintVisitor(e.Graphics, game.Visitors.Where(x => x.Position.Y <= game.Player.Position.Y));
            PaintPlayer(e.Graphics);
            PaintVisitor(e.Graphics, game.Visitors.Where(x => x.Position.Y > game.Player.Position.Y));
            PaintInterior(e.Graphics);
            PaintTabBar(e.Graphics);
        }

        private void PaintClock(Graphics g)
        {
            g.DrawImage(Interior.Clock, new Point(62, 94));
        }

        private void PaintFurnace(Graphics g)
        {
            foreach (var furnace in game.Furnaces.Where(x => x.IsKindled))
                g.DrawImage(Interior.Furnace,furnace.Position);
        }

        private void PaintTabBar(Graphics g)
        {
            g.DrawImage(Interface.TabBar, new Point(481, 636));
            var offset = new Size(50, 0);
            var currentPos = new Point(491, 642);
            foreach (var pizza in game.Player.Inventory)
            {
                if(pizza is null) continue;
                switch (pizza.Type)
                {
                    case PizzaType.Diabola:
                        g.DrawImage(Meal.PizzaDiabola,currentPos);
                        break;
                    case PizzaType.Greens:
                        g.DrawImage(Meal.PizzaGreen,currentPos);
                        break;
                    case PizzaType.Margaret:
                        g.DrawImage(Meal.PizzaMargaret,currentPos);
                        break;
                    case PizzaType.Pepperoni:
                        g.DrawImage(Meal.PizzaPepperoni,currentPos);
                        break;
                }

                currentPos += offset;
            }
        }
        
        private void PaintPlayer(Graphics g)
        {
            EntityAnimation(g, game.Player, chefSprites);
            var visitor = game.Visitors.FirstOrDefault(x => !x.OrderAccepted || x.OrderAccepted && !x.OrderIsCompleted);
            if (visitor is not null
                && visitor.OrderIsActivated
                && !visitor.OrderIsCompleted
                && Model.Game.InZone(game.Player, visitor, Player.ActivationRadius)
                || Model.Game.InZone(game.Player, game.RifledBoard, 10)
                || game.Furnaces.Any(interior => Model.Game.InZone(game.Player, interior, 10)))
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
            }
        }

        private void PaintInterior(Graphics g)
        {
            if (game.Player.Position.Y <= 328)
                g.DrawImage(Sprites.Interior.Wall, new Point(611, 278));
            if (game.Player.Position.Y <= 650)
                g.DrawImage(Sprites.Interior.Barrels, new Point(40, 608));
            if (game.Player.Position.Y <= 161)
                g.DrawImage(Sprites.Interior.Wardrobe, new Point(577, 127));
            if (game.Player.Position.Y <= 344)
                g.DrawImage(Sprites.Interior.Cup, new Point(424, 336));
        }

        private void PaintMatrix(Graphics g)
        {
            foreach (var o in game.Objects)
                g.FillRectangle(Brushes.Chartreuse, new Rectangle(o.Position, o.Size));
        }
    }
}