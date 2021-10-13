using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RobotGame
{

    /// <summary>
    /// Class for the platforms in the game
    /// </summary>
    class Platform
    {
        /// <summary>
        /// Variable for the utilities from Game1.
        /// </summary>
        Game1 root;

        /// <summary>
        /// Variable of type Point for the position of the platform
        /// </summary>
        Point positionP;

        /// <summary>
        /// Variable of type Point for the size of the rectangle to draw the platform
        /// </summary>
        Point Size;



        /// <summary>
        /// Variable of type Texture2D for the image of the platform
        /// </summary>
        Texture2D spritePlatform;

        /// <summary>
        /// Rectangle where the platform is gonna to be placed. with the property get
        /// </summary>
        Rectangle positionRectangleP
        {
            get
            {
                return new Rectangle(positionP, Size);
            }
        }

        /// <summary>
        /// Builder for the class, with one parameter
        /// </summary>
        /// <param name="_root"></param>
        public Platform(Game1 _root)
        {
            this.root = _root;
            positionP = new Point(0, 450);
            Size = new Point(300, 100);
            this.LoadContent();
        }

        /// <summary>
        /// Builder with 2 parameters for the class, the second one is to know where to place the platform
        /// </summary>
        /// <param name="_root"></param>
        /// <param name="_position"></param>
        public Platform(Game1 _root, Point _position)
        {
            this.root = _root;
            positionP = _position;
            Size = new Point(300, 100);
            this.LoadContent();
        }

        /// <summary>
        /// Method to load all the content in the respective variables
        /// </summary>
        private void LoadContent()
        {
            spritePlatform = this.root.Content.Load<Texture2D>("Pad5");
        }

        /// <summary>
        /// Method to Draw the platform in the respective place
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spritePlatform, positionRectangleP, Color.White);
        }
    }
}
