using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RobotGame
{

    /// <summary>
    /// Class for the background image only
    /// </summary>
    class Background
    {

        /// <summary>
        /// Variable for the utilities from Game1.
        /// </summary>
        Game1 root;

        /// <summary>
        /// Variable of type Point for the position of the player
        /// </summary>
        Point positionB;

        /// <summary>
        /// Variable of type Texture2D to save the image of the background
        /// </summary>
        Texture2D spriteBackground;

        string fondo;

        /// <summary>
        /// Variable of type int to save the size of the rectangle where the image of the background is going to be
        /// </summary>
        int Size { get; set; }


        /// <summary>
        /// Rectangle for the image of the background
        /// </summary>
        Rectangle positionRectangleB
        {
            get
            {
                return new Rectangle(positionB, new Point(Size));
            }
        }


        /// <summary>
        /// Builder with only one parameter
        /// </summary>
        /// <param name="_root"></param>
        public Background(Game1 _root)
        {
            this.root = _root;
            positionB = new Point(0, -250);
            Size = 2000;
            fondo = "FondoNuevo";
            this.LoadContent();
        }


        /// <summary>
        /// Method to load the image into the variable for the background
        /// </summary>
        private void LoadContent()
        {
            spriteBackground = this.root.Content.Load<Texture2D>(fondo);
        }


        /// <summary>
        /// Method to draw the image in the screen
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteBackground, positionRectangleB, Color.White);
        }
    }
}
