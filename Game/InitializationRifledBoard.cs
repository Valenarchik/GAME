﻿using System;
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
            Controls.Add(rifledBoard);
            rifledBoard.Hide();
            rifledBoard.Controls.Add(makePizzaPictureBox);
            makePizzaPictureBox.Hide();
            rifledBoard.Controls.Add(ingredients);
            rifledBoard.Controls.Add(closeRifledBoardButton);
            rifledBoard.Controls.Add(pizzaPictureBox);
            rifledBoard.MouseDown += OnPanelMouseDown;
            rifledBoard.MouseUp += OnPanelMouseUp;
            rifledBoard.MouseMove += OnPanelMouseMove;
            pizzaPictureBox.Click += OnPizzaPictureBoxClick;
            
            makePizzaPictureBox.Click += (_, _) =>
            {
                game.RifledBoard.MakePizza();
                makePizzaPictureBox.Hide();
                RifledBoardPaint();
            };
            
            InitializationIngredientButtons();
            for(var i = 0; i< ingredientsOnTable.Count;i++)
            {
                var pictureBox = ingredientsOnTable[i];
                rifledBoard.Controls.Add(pictureBox);
                var i1 = i;
                pictureBox.Click += (_, _) =>
                {
                    var ing = game.RifledBoard.IngredientsForCooking;
                    if (ing.Count >= i1)
                    {
                        ing.Remove(ing[i1]);
                        game.Money++;
                    }
                    RifledBoardPaint();
                };
            }
        

        }

        private void InitializationIngredientButtons()
        {
            foreach (var box in ingredientButtons)
            {
                box.BackColor = Color.Black;
                box.Size = new Size(ingredients.Size.Width / ingredientButtons.Count - 2, ingredients.Size.Height - 1);
                box.Margin = new Padding(1);
                box.SizeMode = PictureBoxSizeMode.CenterImage;
                var name = box.Name;
                box.Click += (_, _) =>
                {
                    var ing = game.RifledBoard.IngredientsForCooking;
                    if(ing.Count == RifledBoard.MaxIngredientsCount)
                        return;
                    if (Enum.TryParse<Ingredient>(name, out var ingredient))
                        ing.Add(ingredient);
                    if (ing.Count == RifledBoard.MaxIngredientsCount)
                    {
                        makePizzaPictureBox.Show();
                    }
                    else
                        makePizzaPictureBox.Hide();
                    game.Money--;
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
            foreach (var pictureBox in ingredientsOnTable)
                pictureBox.Image = new Bitmap(1, 1);
            for (var i = 0; i < ing.Count; i++)
                ingredientsOnTable[i].Image = DecodeIngredients(ing[i]);
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