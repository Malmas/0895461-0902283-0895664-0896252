using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game100
{
    class Player
    {
        public Vector2 playerPos = new Vector2(-200, -200);
        public float playerSpeed = 5.0f;
        protected Texture2D playerTexture;

        List<PlayerBullet> Bullets = new List<PlayerBullet>();
        public void LoadContent(ContentManager theContentManager)
        {
            playerTexture = theContentManager.Load<Texture2D>("ship");
            foreach (PlayerBullet bullet in Bullets)
            {
                bullet.LoadContent(theContentManager);
            }
        }
        private bool shootBullet()
        {
            bool createNew = true;
            foreach (PlayerBullet bullet in Bullets)
            {
                if (bullet.visible == false)
                {
                    createNew = false;
                    bullet.reset();
                    Vector2 firingPos = new Vector2((playerPos.X + 26.0f), playerPos.Y);
                    bullet.fire(firingPos, -(Vector2.UnitY));
                    return true;
                }
            }
            if (createNew == true);
            {
                PlayerBullet bullet = new PlayerBullet();
                Vector2 firingPos = new Vector2((playerPos.X + 26.0f), playerPos.Y);
                bullet.fire(firingPos, -(Vector2.UnitY));
                Bullets.Add(bullet);
                return true;
            }
            return false;
        }
        public void Update(GameTime gametime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                shootBullet();
            }
            var playerDelta = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                playerDelta += Vector2.UnitX;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                playerDelta -= Vector2.UnitX;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                playerDelta += Vector2.UnitY;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                playerDelta -= Vector2.UnitY;
            }
            playerPos += playerDelta * playerSpeed;

            foreach(PlayerBullet bullet in Bullets)
            {
                bullet.Update(gametime);
            }
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(playerTexture, playerPos, Color.White);
            foreach(PlayerBullet bullet in Bullets)
            {
                if (bullet.visible)
                    bullet.Draw(theSpriteBatch);
            }
        }
    }
}
