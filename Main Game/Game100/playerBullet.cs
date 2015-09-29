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
        public bool visible = true;
        protected Texture2D playerBulletTexture;
        public Rectangle lazerHitbox;

        public void setVisible(bool b)
        {
            this.visible = b;
        }
        public void delete()
        {
            playerBulletPos = new Vector2(-100,-100);
        }
        public void reset()
        {
            playerBulletPos = new Vector2(-200, 200);
        }
        public void fire(Vector2 startPosition, Vector2 direction)
        {
            playerBulletPos = startPosition;
            playerBulletDir = direction;

        }

        public void fire(Vector2 startPosition, float direction, float direction2)
        {
            playerBulletPos = startPosition;
            playerBulletDir = new Vector2(direction,direction2);

        }
        public void LoadContent(ContentManager theContentManager)
        {
            playerBulletTexture = theContentManager.Load<Texture2D>("laser");
        }
        public void Update(GameTime theGameTime)
        {
            lazerHitbox = new Rectangle((int)playerBulletPos.X, (int)playerBulletPos.Y, 10, 15);

           
            
            if (visible)
            {
                var bulletDelta = Vector2.Zero;
                playerBulletPos += playerBulletDir * bulletSpeed;
            }
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            if (visible)
                theSpriteBatch.Draw(playerBulletTexture, playerBulletPos, Color.White);
        }
        
    }

}
