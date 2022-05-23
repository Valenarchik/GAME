using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Game.Model;
using Game.Sprites;

namespace Game
{
    public partial class MyForm
    {
        private void InitializationRifledBoard()
        {
            rifledBoard.Controls.Add(ingredients);
            rifledBoard.Controls.Add(closeRifledBoardButton);
            rifledBoard.MouseDown += OnPanelMouseDown;
            rifledBoard.MouseUp += OnPanelMouseUp;
            rifledBoard.MouseMove += OnPanelMouseMove;
            pizzaPictureBox.Click += OnPizzaPictureBoxClick;
            InitializationIngredientsList();
            for(var i = 0; i< ingredientsPictureBoxes.Count;i++)
            {
                var pictureBox = ingredientsPictureBoxes[i];
                rifledBoard.Controls.Add(pictureBox);
                var i1 = i;
                pictureBox.Click += (_, _) =>
                {
                    var ing = game.RifledBoard.IngredientsForCooking;
                    if (ing.Count >= i1)
                        ing.Remove(ing[i1]);
                    RifledBoardPaint();
                };
            }
            rifledBoard.Controls.Add(pizzaPictureBox);
            rifledBoard.Hide();
            Controls.Add(rifledBoard);
        }

        private void InitializationIngredientsList()
        {
            foreach (var box in ingredientsList)
            {
                box.BackColor = Color.Black;
                box.Size = new Size(ingredients.Size.Width / ingredientsList.Count - 2, ingredients.Size.Height - 1);
                box.Margin = new Padding(1);
                box.SizeMode = PictureBoxSizeMode.CenterImage;
                var name = box.Name;
                box.Click += (_, _) =>
                {
                    var ing = game.RifledBoard.IngredientsForCooking;
                    if (Enum.TryParse<Ingredient>(name, out var ingredient))
                       ing.Add(ingredient);
                    if (ing.Count == RifledBoard.MaxIngredientsCount) game.RifledBoard.MakePizza();
                    RifledBoardPaint();
                };
                ingredients.Controls.Add(box);
            }
        }
        
        private void OnPizzaPictureBoxClick(object sender, EventArgs e)
        {
            if(game.RifledBoard.RawPizza is null) return;
            if(game.Player.Inventory.Count!=Player.InventorySize)
            {
                game.Player.Inventory.Add(game.RifledBoard.RawPizza);
                game.RifledBoard.RawPizza = null;
            }
            RifledBoardPaint();
        }
        private void RifledBoardPaint()
        {
            var ing = game.RifledBoard.IngredientsForCooking;
            foreach (var pictureBox in ingredientsPictureBoxes)
                pictureBox.Image = new Bitmap(1, 1);
            for (var i = 0; i < ing.Count; i++)
                ingredientsPictureBoxes[i].Image = DecodeIngredients(ing[i]);
            pizzaPictureBox.Image = game.RifledBoard.RawPizza is not null ?
                DecodePizza(game.RifledBoard.RawPizza.Type,true) : new Bitmap(1, 1);
        }
        
        private bool a = true;
        private int x, y;

        private void OnPanelMouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            a = false;
        }

        private void OnPanelMouseUp(object sender, MouseEventArgs e)
        {
            a = true;
        }

        private void OnPanelMouseMove(object sender, MouseEventArgs e)
        {
            if (a) return;
            var mPanel = (Panel) sender;
            if (!game.IsInsideMap(new PointF(mPanel.Left + e.X - x, mPanel.Top + e.Y - y))
                || !game.IsInsideMap(new PointF(mPanel.Right + e.X - x, mPanel.Bottom + e.Y - y)))
                return;
            mPanel.Left += e.X - x;
            mPanel.Top += e.Y - y;
        }

        private static Bitmap DecodePizza(PizzaType pizza, bool isBig)
        {
            if (isBig)
                return pizza switch
                {
                    PizzaType.Pepperoni => Meal.BigPizzaPepperoni,
                    PizzaType.Margaret => Meal.BigPizzaMargaret,
                    PizzaType.Greens => Meal.BigPizzaGreen,
                    PizzaType.Diabola => Meal.BigPizzaDiabola,
                    _ => new Bitmap(1, 1)
                };
            return pizza switch
            {
                PizzaType.Pepperoni => Meal.PizzaPepperoni,
                PizzaType.Margaret => Meal.PizzaMargaret,
                PizzaType.Greens => Meal.PizzaGreen,
                PizzaType.Diabola => Meal.PizzaDiabola,
                _ => new Bitmap(1, 1)
            };
        }

        private static Bitmap DecodeIngredients(Ingredient ingredient)
        {
            return ingredient switch
            {
                Ingredient.Basil => Meal.BigBasil,
                Ingredient.Cheese => Meal.BigCheese,
                Ingredient.Dough => Meal.BigDough,
                Ingredient.Mushroom => Meal.BigMushroom,
                Ingredient.Pepperoni => Meal.BigPepperoni,
                Ingredient.Tomato => Meal.BigTomato,
                Ingredient.ChickenFillet => Meal.BigChicken,
                Ingredient.TomatoSauce => Meal.BigTomatoSauce,
                _ => new Bitmap(1,1)
            };
        }
    }
}