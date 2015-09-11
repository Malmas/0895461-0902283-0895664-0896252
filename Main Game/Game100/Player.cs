using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game100
{
    class Player
    {
        public Vector2 playerPos = new Vector2(-200, -200);
        public float playerSpeed = 5.0f;
        private Texture2D playerTexture;

        List<PlayerBullet> Bullets = new List<PlayerBullet>()
        public void LoadContent(ContentManager theContentManager)
        {
            playerTexture = theContentManager.Load<Texture2D>("ship");
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(playerTexture, playerPos, Color.White);
        }
    }
}
