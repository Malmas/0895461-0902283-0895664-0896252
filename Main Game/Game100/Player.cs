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
        PlayerBullet[] playerBullets = new PlayerBullet[9];
        public float timeSinceLastShot = 0f;
        public float timeSinceLastShotBomb = 0f;
        public int lives = 3;
        float timeToWait = 0f;
        int i = 0;
        PlayerBullet[] bullets = new PlayerBullet[9];

        public static List<PlayerBullet> Bullets = new List<PlayerBullet>();
        public void LoadContent(ContentManager theContentManager)
        {
            playerTexture = theContentManager.Load<Texture2D>("ship");
            foreach (PlayerBullet bullet in Bullets)
            {
                bullet.LoadContent(theContentManager);
            }
        }
        private void shootBullet()
        {
            PlayerBullet bullet = new PlayerBullet();
            Vector2 firingPos = new Vector2((playerPos.X + 26.0f), playerPos.Y);
            bullet.fire(firingPos, -(Vector2.UnitY));
            Bullets.Add(bullet);
        }

        private void shootBomb()
        {
            Vector2 firingPos = new Vector2((playerPos.X + 26.0f), playerPos.Y);

            bullets[0] = new PlayerBullet();
            bullets[0].fire(firingPos, -1, -1);
            Bullets.Add(bullets[0]);

            bullets[1] = new PlayerBullet();
            bullets[1].fire(firingPos, -1, 1);
            Bullets.Add(bullets[1]);

            bullets[2] = new PlayerBullet();
            bullets[2].fire(firingPos, 1, -1);
            Bullets.Add(bullets[2]);


            bullets[3] = new PlayerBullet();
            bullets[3].fire(firingPos, 1, 1);
            Bullets.Add(bullets[3]);

            bullets[4] = new PlayerBullet();
            bullets[4].fire(firingPos, 0, -1);
            Bullets.Add(bullets[4]);

            bullets[5] = new PlayerBullet();
            bullets[5].fire(firingPos, -1, 0);
            Bullets.Add(bullets[5]);

            bullets[6] = new PlayerBullet();
            bullets[6].fire(firingPos, 0, 1);
            Bullets.Add(bullets[6]);

            bullets[7] = new PlayerBullet();
            bullets[7].fire(firingPos, 1, 0);
            Bullets.Add(bullets[7]);

        }

        public void Update(GameTime gameTime)
        {
            if (lives == 0)
            {

            }
            var keyboardState = Keyboard.GetState();
            timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeToWait += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastShotBomb += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Space) && timeSinceLastShot > 0.5f)
            {
                shootBullet();
                timeSinceLastShot = 0;
            }

            if (keyboardState.IsKeyDown(Keys.X))
            {
                while (i < 1 && timeSinceLastShotBomb > 0.5f)
                {
                    shootBomb();
                    timeSinceLastShotBomb = 0;
                    i++;
                }
                i = 0;
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
                bullet.Update(gameTime);
            }
            if (playerPos.X > 755)
            {
                playerPos.X = 755; 
            }
            if (playerPos.X < -20)
            {
                playerPos.X = -20;
            }
            if (playerPos.Y > 430)
            {
                playerPos.Y = 430;
            }
            if (playerPos.Y < -12)
            {
                playerPos.Y = -12;
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

/*

private void shootBullet()
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
                   
                }
            }
            if (createNew == true)
            {
                PlayerBullet bullet = new PlayerBullet();
                Vector2 firingPos = new Vector2((playerPos.X + 26.0f), playerPos.Y);
                bullet.fire(firingPos, -(Vector2.UnitY));
                Bullets.Add(bullet);
               
            }
            
        }
*/