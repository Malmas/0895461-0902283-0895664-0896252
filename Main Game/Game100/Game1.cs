using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace Game100
{

    public class Game1 : Game
    {
        private Texture2D asteroid;
        private Texture2D explosion;
        private Texture2D background;
        private SoundEffect backgroundMusic;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        Boolean isAlive = true;
        Boolean isPressed = false;

        Vector2 explosionPos;
        Vector2 position;
        Vector2 asteroidPos;

        Rectangle asteroidHitbox;
        //Rectangle lazerHitbox;

        protected override void Initialize()
        {
            player1 = new Player();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player1.playerPos = new Vector2(200, 200);
            asteroidPos = new Vector2(450, 100);
            explosionPos = new Vector2(-100, -100);

            position = new Vector2(graphics.GraphicsDevice.Viewport.
                       Width / 2,
                                    graphics.GraphicsDevice.Viewport.
                                    Height / 2);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            explosion = Content.Load<Texture2D>("Ultimate_Explosion");
            background = Content.Load<Texture2D>("background");
            asteroid = Content.Load<Texture2D>("asteroid.png");
            backgroundMusic = Content.Load<SoundEffect>("Episode");
            backgroundMusic.Play();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            player1.LoadContent(this.Content);

        }




        protected override void Update(GameTime gameTime)
        {
            player1.Update(gameTime);
            player1.LoadContent(this.Content);
            asteroidHitbox = new Rectangle((int)asteroidPos.X, (int)asteroidPos.Y, 20, 20);
            //lazerHitbox = new Rectangle((int)lazerPos.X, (int)lazerPos.Y, 10, 15);

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            MouseState state = Mouse.GetState();

            position.X = state.X;
            position.Y = state.Y;

             if (keyboardState.IsKeyDown(Keys.R))
            {
                asteroidPos = new Vector2(450, 100);
                explosionPos = new Vector2(-100, -100);
                isAlive = true;
                isPressed = false;
            }


            if (keyboardState.IsKeyDown(Keys.X))
            {
                isPressed = true;
            }

            /*if (asteroidHitbox.Intersects(lazerHitbox)) {
                explosionPos = asteroidPos;
                isAlive = false;
                isPressed = false;
            } */
            else if (isAlive == false)
            {
                explosionPos = new Vector2(-100, -100);
                asteroidPos = new Vector2(-100, -100);
                
            }
            base.Update(gameTime);
        }
       

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            player1.Draw(spriteBatch);
            spriteBatch.Draw(asteroid, asteroidPos, Color.White);
            spriteBatch.Draw(explosion, explosionPos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}

    
