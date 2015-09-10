using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week1_Game
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        Vector2 shipPosition;
        Vector2 bulletPosition;
        Texture2D spaceShip;
        Texture2D bullet;
        protected override void Initialize()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipPosition = new Vector2(400, 400);
            bulletPosition = new Vector2(-200,-200);
            spaceShip = Content.Load<Texture2D>("xspr5.png");
            bullet = Content.Load<Texture2D>("bullet.png");
            base.Initialize();
        }
        protected override void LoadContent()
        {
            
        }

        protected override void UnloadContent()
        {
        }
        protected float toUnit(bool b)
        {
            if (b)
            {
                return 1.0f;
            }
            else
            {
                return 0.0f;
            }
        }
        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();
            var shipDelta = Vector2.Zero;
            shipDelta += Vector2.UnitX * toUnit(keyboardState.IsKeyDown(Keys.Right));
            shipDelta -= Vector2.UnitX * toUnit(keyboardState.IsKeyDown(Keys.Left));
            shipDelta += Vector2.UnitY * toUnit(keyboardState.IsKeyDown(Keys.Down));
            shipDelta -= Vector2.UnitY * toUnit(keyboardState.IsKeyDown(Keys.Up));
            shipPosition += shipDelta * 5.0f;

            if (keyboardState.IsKeyDown(Keys.Space))
                bulletPosition = new Vector2((shipPosition.X + 47.0f), shipPosition.Y);
            var bulletDelta = Vector2.Zero;
            bulletDelta -= Vector2.UnitY * 1.0f;
            bulletPosition += bulletDelta * 2.0f;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, null);
            spriteBatch.Draw(spaceShip, shipPosition, Color.AliceBlue);
            spriteBatch.Draw(bullet, bulletPosition, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}