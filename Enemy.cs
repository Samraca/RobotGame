using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RobotGame
{

    /// <summary>
    /// Class for the enemy and the logic of the enemies
    /// </summary>
    class Enemy
    {
        /// <summary>
        /// Variable for the utilities from Game1.
        /// </summary>
        Game1 root;

        /// <summary>
        /// Variable of type Point to save the position of the enemies
        /// </summary>
        Point positionE;

        /// <summary>
        /// Array of images of the enemy running
        /// </summary>
        Texture2D[] spriteE;

        Texture2D[] sprtiteRunningLeft;

        /// <summary>
        /// Variable of type Point to make the enemy moves
        /// </summary>
        Point velocityE;

        /// <summary>
        /// Byte por the frames per second
        /// </summary>
        byte fps;

        /// <summary>
        /// Byte for the image to draw in the indicate instant
        /// </summary>
        byte instantimg;

        /// <summary>
        /// Booleans to control the movement of the enemies in each platform
        /// </summary>
        bool emc11;
        bool emc12;
        bool isDead;


        /// <summary>
        /// Variable of type int for the size of the enemy
        /// </summary>
        int Size;

        int EnemyLife;

        SpriteFont LifeFont;


        /// <summary>
        /// Rectangle to draw the enemy
        /// </summary>
        public Rectangle positionRectangleE
        {
            get
            {
                return new Rectangle(positionE, new Point(Size));
            }
        }


        /// <summary>
        /// Builder with 2 parameters
        /// </summary>
        /// <param name="_root"></param>
        /// <param name="_position"></param>
        public Enemy(Game1 _root, Point _position)
        {
            this.root = _root;
            Size = 100;
            EnemyLife = 100;
            spriteE = new Texture2D[7];
            sprtiteRunningLeft = new Texture2D[7];
            velocityE = new Point(1, 0);
            positionE = _position;
            this.LoadContent();
            instantimg = 1;
            fps = 0;
            emc11 = true;
            emc12 = false;
            isDead = false;


        }

        /// <summary>
        /// Method to contabilize the frames per second to representate the correct images
        /// </summary>
        public void FramesPerSecond()
        {
            fps++;
            if (fps > 10)
            {
                fps = 0;
                instantimg += 1;
                if (instantimg >= 7)
                {
                    instantimg = 0;
                }
            }
        }

        /// <summary>
        /// Method to load all the array of images of the enemy running
        /// </summary>
        public void LoadContent()
        {
            for (int i = 0; i < 7; i++)
            {
                spriteE[i] = this.root.Content.Load<Texture2D>("RunE" + (i + 1));
                sprtiteRunningLeft[i] = this.root.Content.Load<Texture2D>("RunEL" + (i + 1));
            }
            LifeFont = this.root.Content.Load<SpriteFont>("txt");
        }

        /// <summary>
        /// Method for the logic of the enemy
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            this.FramesPerSecond();
            if (450 <= positionE.X && positionE.X < 680)
            {
                this.MoveControl(450, 680);
            }
            if (900 <= positionE.X && positionE.X < 1200)
            {
                this.MoveControl(950, 1180);
            }
            if (1350 <= positionE.X && positionE.X < 1580)
            {
                this.MoveControl(1350, 1580);
            }

            if (EnemyLife <= 0)
            {
                EnemyLife = 0;
                isDead = true;
            }
        }

        /// <summary>
        /// Method to control the movement of the enemies
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void MoveControl(int a, int b)
        {
            if (emc11 && isDead == false)
            {
                this.MoveRight();
            }
            if (positionE.X >= b)
            {
                emc11 = false;
                emc12 = true;
            }
            if (emc12 && isDead == false)
            {
                this.MoveLeft();
            }
            if (positionE.X <= a)
            {
                emc11 = true;
                emc12 = false;
            }
        }

        /// <summary>
        /// Method to move the object to the left
        /// </summary>
        public void MoveLeft()
        {
            positionE -= velocityE;

        }

        /// <summary>
        /// Method to move the object to the right
        /// </summary>
        public void MoveRight()
        {
            positionE += velocityE;

        }

        /// <summary>
        /// Method to draw all the enemies
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (emc11 && isDead == false)
            {

                for (int i = 0; i < 7; i++)
                {
                    spriteBatch.Draw(spriteE[instantimg], positionRectangleE, Color.White);
                }

            }

            if (emc12 && isDead == false)
            {

                for (int i = 0; i < 7; i++)
                {
                    spriteBatch.Draw(sprtiteRunningLeft[instantimg], positionRectangleE, Color.White);
                }
            }
            if (isDead==false)
            {
                spriteBatch.DrawString(LifeFont, "HP " + EnemyLife, new Vector2(positionE.X, positionE.Y - 50), Color.Red);
            }
            
        }

        /// <summary>
        /// Method that returns the position of the enemy
        /// </summary>
        /// <returns></returns>
        public Rectangle getPositionE()
        {
            return new Rectangle(positionE, new Point(Size));
        }

        public void DecreaseEnemyLife(int damage)
        {
            EnemyLife -= damage;
        }

        public Boolean getIsDead()
        {
            return isDead;
        }
    }
}
