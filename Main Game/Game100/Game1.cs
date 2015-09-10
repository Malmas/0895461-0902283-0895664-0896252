using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game100
{

    public class Game1 : Game
    {

        private Texture2D ship;
        private Texture2D lazer;
        private Texture2D asteroid;
        private Texture2D explosion;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        Boolean isAlive = true;
        Boolean isPressed = false;

        Vector2 shipPos;
        Vector2 lazerPos;
        Vector2 explosionPos;
        Vector2 position;
        Vector2 asteroidPos;

        Rectangle asteroidHitbox;
        Rectangle lazerHitbox;

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipPos = new Vector2(350, 300);
            lazerPos = new Vector2(-100,-100);
            asteroidPos = new Vector2(450, 100);
            explosionPos = new Vector2(-100, -100);

            position = new Vector2(graphics.GraphicsDevice.Viewport.
                       Width / 2,
                                    graphics.GraphicsDevice.Viewport.
                                    Height / 2);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            explosion = Content.Load<Texture2D>("Ultimate_Explosion");
            ship = Content.Load<Texture2D>("ship");
            lazer = Content.Load<Texture2D>("laser.png");
            asteroid = Content.Load<Texture2D>("asteroid.png");

            base.Initialize();
        }



        protected override void Update(GameTime gameTime)
        {

            asteroidHitbox = new Rectangle((int)asteroidPos.X, (int)asteroidPos.Y, 20, 20);
            lazerHitbox = new Rectangle((int)lazerPos.X, (int)lazerPos.Y, 10, 15);

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();


            var shipPlacement = Vector2.Zero;
            var laserDelta = Vector2.Zero;
            MouseState state = Mouse.GetState();

            position.X = state.X;
            position.Y = state.Y;


            if (keyboardState.IsKeyDown(Keys.Right))
            {
                shipPlacement += Vector2.UnitX;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                shipPlacement -= Vector2.UnitX;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                shipPlacement += Vector2.UnitY;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                shipPlacement -= Vector2.UnitY;
            }


             if (keyboardState.IsKeyDown(Keys.R))
            {
                lazerPos = new Vector2(-100, -100);
                asteroidPos = new Vector2(450, 100);
                explosionPos = new Vector2(-100, -100);
                isAlive = true;
                isPressed = false;
            }

             if (lazerPos.Y < 0)
             {
                 isPressed = false;
             }

            if (keyboardState.IsKeyDown(Keys.X) && isAlive == true && isPressed == false)
                lazerPos = new Vector2((shipPos.X + 26.0f), shipPos.Y);

            var lazerDelta = Vector2.Zero;
            lazerDelta -= Vector2.UnitY * 1.0f;
            lazerPos += lazerDelta * 7.0f;

            if (keyboardState.IsKeyDown(Keys.X))
            {
                isPressed = true;
            }

            if (asteroidHitbox.Intersects(lazerHitbox)) {
                explosionPos = asteroidPos;
                isAlive = false;
                isPressed = false;
            } 
            else if (isAlive == false)
            {
                explosionPos = new Vector2(-100, -100);
                lazerPos = new Vector2(-100, -100);
                asteroidPos = new Vector2(-100, -100);
                if (lazerPos == shipPos)
                {
                    isAlive = true;
                }
                
            }
            shipPos += shipPlacement * 5.0f;
            base.Update(gameTime);
        }
       

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(ship, shipPos, Color.White);
            spriteBatch.Draw(lazer, lazerPos, Color.White);
            spriteBatch.Draw(asteroid, asteroidPos, Color.White);
            spriteBatch.Draw(explosion, explosionPos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}

    
