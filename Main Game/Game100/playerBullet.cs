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
        public float bulletSpeed = 4.0f;
        public bool visible = false;
        private Texture2D playerBulletTexture;
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
            if (visible == true)
            {
                //base.Update(theGameTime, bulletSpeed, mDirection);
            }
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(playerBulletTexture, playerBulletPos, Color.White);
        }
        
    }

}
