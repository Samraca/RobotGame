using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace RobotGame
{

    /// <summary>
    /// Class for the game1 who heredates from game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        /// <summary>
        /// Variable to save the song of the background
        /// </summary>
        Song Song1;

        /// <summary>
        /// Object of the class Background
        /// </summary>
        Background myBackground;

        /// <summary>
        /// Object of the class Player
        /// </summary>
        Player myPlayer;

        /// <summary>
        /// Object of the class Enemy, enemy number 1
        /// </summary>
        Enemy Enemy1;

        /// <summary>
        /// Object of the class Enemy, enemy number 2
        /// </summary>
        Enemy Enemy2;

        /// <summary>
        /// Object of the class Enemy, enemy number 3
        /// </summary>
        Enemy Enemy3;

        /// <summary>
        /// Object of the class Platform, platform 1
        /// </summary>
        Platform Platform1;

        /// <summary>
        /// Object of the class Platform, platform 2
        /// </summary>
        Platform Platform2;

        /// <summary>
        /// Object of the class Platform, platform 3
        /// </summary>
        Platform Platform3;
        
        /// <summary>
        /// Object of the class Platform, platform 4
        /// </summary>
        Platform Platform4;
        Platform Platform5;

        Bullet playerBullet;
        SoundEffect shoot;

        /// <summary>
        /// Builder for Game1. no parameters
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Method to initialize the variables
        /// </summary>
        protected override void Initialize()
        {
            
            myPlayer = new Player(this, new Point(0, 850));
            Enemy1 = new Enemy(this, new Point(450, 700));
            Enemy2 = new Enemy(this, new Point(950, 550));
            Enemy3 = new Enemy(this, new Point(1350, 400));
            Platform1 = new Platform(this, new Point(0, 930));
            Platform2 = new Platform(this, new Point(450, 780));
            Platform3 = new Platform(this, new Point(950, 630));
            Platform4 = new Platform(this, new Point(1350, 480));
            Platform5 = new Platform(this, new Point(1800, 330));
            playerBullet = new Bullet(this, myPlayer.getPosition());
            myBackground = new Background(this);
            base.Initialize();
        }

        /// <summary>
        /// Method for load the content in the respective objects
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Song1 = Content.Load<Song>("BackgroundMusic");
            MediaPlayer.Play(Song1);
            shoot = Content.Load<SoundEffect>("LaserShot");
            
        }

        /// <summary>
        /// Method who loops for the logic of the game
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            myPlayer.Update(gameTime);
            Enemy1.Update(gameTime);
            Enemy2.Update(gameTime);
            Enemy3.Update(gameTime);
            playerBullet.Update(gameTime, myPlayer.getPosition());

            if ((Enemy1.positionRectangleE.Contains(myPlayer.positionRectangle.Center) && Enemy1.getIsDead() == false) ||
                (Enemy2.positionRectangleE.Contains(myPlayer.positionRectangle.Center) && Enemy2.getIsDead()==false) ||
                (Enemy3.positionRectangleE.Contains(myPlayer.positionRectangle.Center)&& Enemy3.getIsDead()==false))
            {

                if (myPlayer.getFPS() > 9)
                {
                    myPlayer.decreaseCounter(5);
                }

            }

            if (playerBullet.getIsVisible() == true)
            {
                
                
                if (Enemy1.positionRectangleE.Contains(playerBullet.bulletRectangle.Center) && Enemy1.getIsDead() == false)
                {
                    playerBullet.setIsVisible(false);
                    Enemy1.DecreaseEnemyLife(20);
                }
                if (Enemy2.positionRectangleE.Contains(playerBullet.bulletRectangle.Center) && Enemy2.getIsDead() == false)
                {
                    playerBullet.setIsVisible(false);
                    Enemy2.DecreaseEnemyLife(20);
                }
                if (Enemy3.positionRectangleE.Contains(playerBullet.bulletRectangle.Center) && Enemy3.getIsDead() == false)
                {
                    playerBullet.setIsVisible(false);
                    Enemy3.DecreaseEnemyLife(20);
                }
                
            }
            if (myPlayer.GetGameOver() || myPlayer.GetWin())
            {
                MediaPlayer.Stop();
            }
            
            base.Update(gameTime);

        }

        /// <summary>
        /// Method who loops to draw alll the game, including the objects of other classes
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            myBackground.Draw(gameTime, _spriteBatch);
            Platform1.Draw(gameTime, _spriteBatch);
            Platform2.Draw(gameTime, _spriteBatch);
            Platform3.Draw(gameTime, _spriteBatch);
            Platform4.Draw(gameTime, _spriteBatch);
            Platform5.Draw(gameTime, _spriteBatch);
            myPlayer.Draw(gameTime, _spriteBatch);
            Enemy1.Draw(gameTime, _spriteBatch);
            Enemy2.Draw(gameTime, _spriteBatch);
            Enemy3.Draw(gameTime, _spriteBatch);
            playerBullet.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
