using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace RobotGame
{
    class Bullet
    {

        Game1 root;
        Vector2 VectorPosition;
        Vector2 velocity;
        Point bulletPosition;
        Texture2D spriteBullet;
        bool isVisible;
        
        public Rectangle bulletRectangle
        {
            get
            {
                return new Rectangle(bulletPosition, new Point(40));
            }
        }
        public Bullet(Game1 _root, Vector2 _position)
        {
            this.root = _root;
            VectorPosition = _position;
            velocity = new Vector2(25,0);
            this.LoadContent();
            isVisible = false;
        }

        private void LoadContent()
        {
            
            spriteBullet = this.root.Content.Load<Texture2D>("Bullet0");
            

        }

        public void Update(GameTime gameTime, Vector2 originalPosition)
        {
            if (!isVisible)
            {
                VectorPosition = originalPosition;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.X) && isVisible==false)
            {
                
                isVisible = true;
                
            }

            if (isVisible)
            {
                VectorPosition += velocity;
                
            }
            if (VectorPosition.X > 2000 && isVisible==true)
            {
                isVisible = false;
                VectorPosition = originalPosition;
            }
            bulletPosition = this.Vector2ToPoint(VectorPosition,bulletPosition);
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                for (int i = 0; i < 4; i++)
                {
                    spriteBatch.Draw(spriteBullet, bulletRectangle, Color.White);
                }
                
            }
            
        }

            public Point Vector2ToPoint(Vector2 newVector, Point newPoint)
        {
            newPoint.X = Convert.ToInt32(newVector.X);
            newPoint.Y = Convert.ToInt32(newVector.Y);
            return newPoint;
        }

        public void setIsVisible(bool change)
        {
            isVisible = change;
        }

        public Boolean getIsVisible()
        {
            return isVisible;
        }
    }

    
}
