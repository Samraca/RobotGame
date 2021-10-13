using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace RobotGame
{
    /// <summary>
    /// Class Player for the player in the game, it haves all relationated with the movement and the interaction with the rest of the game
    /// </summary>
    class Player
    {
        /// <summary>
        /// Variable for the utilities from Game1.
        /// </summary>
        Game1 root;

        /// <summary>
        /// Variable of type int for the lifes of the player.
        /// </summary>
        public int lifeCounter;

        /// <summary>
        /// Variable of type Int for the size of the box for the player
        /// </summary>
        int Size { get; set; }

        /// <summary>
        /// Variable of type SpriteFont to save the font, used to write the game over and the life counter.
        /// </summary>
        private SpriteFont myFont;
        private SpriteFont FontGameOver;

        /// <summary>
        /// Variable of type boolean to detect the game over.
        /// </summary>
        bool gameover;

        bool Win;

        /// <summary>
        /// Variable of type boolean to detect movement
        /// </summary>
        bool Static;

        bool Right;
        bool Left;

        /// <summary>
        /// Variable of type byte to detect how many actualizations have been passed in the game
        /// </summary>
        byte fps;

        /// <summary>
        /// Byte variable to draw the image of the Static Array
        /// </summary>
        byte instantimgI;

        /// <summary>
        /// Byte variable to draw the image of the Running Array
        /// </summary>
        byte instantimgR;

        byte imgDead;



        /// <summary>
        /// Array for the images of the player been static
        /// </summary>
        Texture2D[] spriteI;

        /// <summary>
        /// Array for the images of the player been runnning
        /// </summary>
        Texture2D[] spriteR;
        Texture2D[] spriteL;

        Texture2D[] spriteJump;

        Texture2D[] spriteDead;

        /// <summary>
        /// Variable of type Keyboard to detect the previous state of the keyboard to avoid false positives
        /// </summary>
        KeyboardState previousKeyboardState;

        /// <summary>
        /// Rectangle for the player with his property get
        /// </summary>
        public Rectangle positionRectangle;


        Vector2 positionV;
        Vector2 velocityV;
        bool hasjumped;
        bool jump;
        Point pos;
        float actualHeight;
        Vector2 HealthPosition;

        
        
        

        /// <summary>
        /// Builder with two parameters, the second one is for where the player is gonna be
        /// </summary>
        /// <param name="_root"></param>
        /// <param name="_position"></param>
        public Player(Game1 _root, Point _position)
        {
            this.root = _root;
            spriteI = new Texture2D[9];
            spriteR = new Texture2D[7];
            spriteL = new Texture2D[7];
            spriteJump = new Texture2D[9];
            spriteDead = new Texture2D[9];
            Size = 100;
            this.LoadContent();
            previousKeyboardState = Keyboard.GetState();
            fps = 0;
            instantimgI = 1;
            instantimgR = 1;
            imgDead = 1;
            Static = true;
            Right = false;
            Left = false;
            lifeCounter = 100;
            gameover = false;
            Win = false;
            positionV = new Vector2(0, 850);
            HealthPosition = new Vector2(0, -50);
            hasjumped = true;
            jump = false;
            actualHeight = 960;
            positionRectangle = new Rectangle(pos, new Point(Size));

        }
        /// <summary>
        /// Method to load the images into their respective variables
        /// </summary>
        private void LoadContent()
        {
            for (int i = 0; i < 9; i++)
            {
                spriteI[i] = this.root.Content.Load<Texture2D>("Idle" + (i + 1));
                spriteJump[i] = this.root.Content.Load<Texture2D>("Jump" + (i + 1));
                spriteDead[i] = this.root.Content.Load<Texture2D>("Dead" + (i + 1));
            }
            for (int i = 0; i < 7; i++)
            {
                spriteR[i] = this.root.Content.Load<Texture2D>("Run" + (i + 1));
                spriteL[i] = this.root.Content.Load<Texture2D>("RunL" + (i + 1));
            }
            myFont = this.root.Content.Load<SpriteFont>("txt");
            FontGameOver = this.root.Content.Load<SpriteFont>("GameOver");
            
            
            

        }

        /// <summary>
        /// Method for the logic associated to the player
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            this.Movement(gameTime);
            this.FramesPerSecond();
            if (pos.Y > 980)
            {
                lifeCounter = 0;
                gameover = true;
                
            }

            if (lifeCounter <= 0)
            {
                lifeCounter = 0;
                gameover = true;
                
            }


            if (0 <= pos.X && pos.X <= 250)
            {
                actualHeight = 960;
                if (pos.Y > 960)
                {
                    actualHeight = 1100;
                    
                }
            }
            if (250 < pos.X && pos.X < 400)
            {
                actualHeight = 1100;
                pos.Y = 1000;
                hasjumped = true;
            }
            if (400 <= pos.X && pos.X <= 700)
            {
                actualHeight = 800;
                if (pos.Y > 800)
                {
                    actualHeight = 1100;
                    
                }
            }
            if (700 < pos.X && pos.X < 900)
            {
                actualHeight = 1100;
                pos.Y = 1000;
                hasjumped = true;
            }
            if (900 <= pos.X && pos.X <= 1200)
            {
                actualHeight = 650;
                if (pos.Y > 650)
                {
                    actualHeight = 1100;
                    
                }
            }
            if (1200 < pos.X && pos.X < 1250)
            {
                actualHeight = 1100;
                pos.Y = 1000;
                hasjumped = true;
            }
            if (1250 <= pos.X && pos.X <= 1600)
            {
                actualHeight = 500;
                if (pos.Y > 500)
                {
                    actualHeight = 1100;
                    
                }
            }
            if (1600 < pos.X && pos.X< 1800)
            {
                actualHeight = 1100;
                pos.Y = 1000;
                hasjumped = true;
            }
            if (1800 <= pos.X)
            {
                actualHeight = 350;
                Win = true;
                if (pos.Y > 350)
                {
                    
                    actualHeight = 1100;
                    
                }
            }

            
            

        }

        /// <summary>
        /// Method to draw in the screen the player, the gameover and the LifeCounter
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (jump == false && gameover == false && Win == false)
            {
                if (Static)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        spriteBatch.Draw(spriteI[instantimgI], positionRectangle, Color.White);
                    }
                }
                if (Right)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        spriteBatch.Draw(spriteR[instantimgR], positionRectangle, Color.White);
                    }
                }
                if (Left)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        spriteBatch.Draw(spriteL[instantimgR], positionRectangle, Color.White);
                    }
                }
                
            }

            if (jump && gameover==false && Win==false)
            {
                for (int i = 0; i < 9; i++)
                {
                    spriteBatch.Draw(spriteJump[instantimgI], positionRectangle, Color.White);
                }
            }

            if (gameover)
            {
                spriteBatch.DrawString(FontGameOver, "Game Over", new Vector2(600, 300), Color.Red);
                for (int i = 0; i < 9; i++)
                {
                    spriteBatch.Draw(spriteDead[imgDead], positionRectangle, Color.White);
                }

            }
            if (Win)
            {
                spriteBatch.DrawString(FontGameOver, "Well Done !", new Vector2(600, 300), Color.Green);
            }
            if (gameover==false && Win == false)
            {
                spriteBatch.DrawString(myFont, "HP " + lifeCounter, positionV + HealthPosition, Color.Black);
                spriteBatch.DrawString(myFont, "Kill all the enemies and jump to the last platform to win"+
                    "\nPress X to Shoot\nPress SpaceBar to Jump", new Vector2(85, 45), Color.BurlyWood);
                
            }
        }

        /// <summary>
        /// Method to contabilize the frames per second to representate the correct images
        /// </summary>
        public void FramesPerSecond()
        {
            if (gameover == false)
            {
                fps++;
                if (fps > 10)
                {
                    fps = 0;
                    instantimgI += 1;
                    instantimgR += 1;
                    imgDead += 1;
                    if (instantimgI >= 9)
                    {
                        instantimgI = 0;
                    }
                    if (instantimgR >= 7)
                    {
                        instantimgR = 0;
                    }
                    if (imgDead >= 9)
                    {
                        imgDead = 0;
                    }
                }

                
            }

            if (gameover)
            {
                imgDead += 1;
                if (imgDead > 8)
                {
                    imgDead = 8;
                }
            }


        }

        public void Movement(GameTime gameTime)
        {
            if (gameover == false && Win==false)
            {
                positionV += velocityV;

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    velocityV.X = 3f;
                    Static = false;
                    Left = false;
                    Right = true;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    velocityV.X = -3f;
                    Static = false;
                    Left = true;
                    Right = false;
                }
                else
                {
                    velocityV.X = 0f;
                }

                if (!Keyboard.GetState().IsKeyDown(Keys.Left) && !Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    Static = true;
                    Left = false;
                    Right = false;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasjumped == false)
                {
                    positionV.Y -= 19f;
                    velocityV.Y = -20f;
                    hasjumped = true;
                    jump = true;
                    
                }

                if (hasjumped)
                {
                    float i = 1;
                    velocityV.Y += 0.5f * i;
                }


                if (positionV.Y + positionRectangle.Height >= actualHeight)
                {
                    hasjumped = false;
                    jump = false;
                }

                if (hasjumped == false)
                {
                    velocityV.Y = 0f;

                }


                if (positionV.X <= -20)
                {
                    positionV.X = -20f;
                }
                pos = this.Vector2ToPoint(positionV, pos);

                positionRectangle.X = pos.X;
                positionRectangle.Y = pos.Y;
            }
            else
            {
                Static = true;
            }
        }

        public Point Vector2ToPoint(Vector2 newVector, Point newPoint)
        {
            newPoint.X = Convert.ToInt32(newVector.X);
            newPoint.Y = Convert.ToInt32(newVector.Y);
            return newPoint;
        }


        /// <summary>
        /// Method to decrease the lifes of the player when its detected outside of the class
        /// </summary>
        /// <param name="a"></param>
        public void decreaseCounter(int a)
        {
            lifeCounter -= a;
        }
        /// <summary>
        /// Method to give the signal for the game over
        /// </summary>
        /// <returns></returns>
        public bool GetGameOver()
        {
            return gameover;
        }

        public bool GetWin()
        {
            return Win;
        }
        public byte getFPS()
        {
            return fps;
        }

        public Vector2 getPosition()
        {
            return positionV;
        }
    }
}