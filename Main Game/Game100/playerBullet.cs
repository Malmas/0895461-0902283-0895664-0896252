using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game100
{
    class PlayerBullet : Sprite
    {
        public Vector2 playerBulletPos = new Vector2(-200, -200);
        public Vector2 playerBulletDir;
        public float bulletSpeed = 7.0f;
        public bool visible = false;
        protected Texture2D playerBulletTexture;
        

        public void reset()
        {
            playerBulletPos = new Vector2(-200, 200);
        }
        public void fire(Vector2 startPosition, Vector2 direction)
        {
            playerBulletPos = startPosition;
            playerBulletDir = direction;

        }
        public void LoadContent(ContentManager theContentManager)
        {
            playerBulletTexture = theContentManager.Load<Texture2D>("laser");
        }
        public void Update(GameTime theGameTime)
        {
            if (playerBulletPos.Y < -30)
            {
                visible = false;
            }
            else
            {
                visible = true;
            }
            if (visible)
            {
                var bulletDelta = Vector2.Zero;
                playerBulletPos += playerBulletDir * bulletSpeed;
            }
            else
            {

            }
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            if (visible)
                theSpriteBatch.Draw(playerBulletTexture, playerBulletPos, Color.White);
        }
        
    }

}
