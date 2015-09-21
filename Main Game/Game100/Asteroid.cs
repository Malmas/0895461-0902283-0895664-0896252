using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game100
{
    class Asteroid
    {
        public Vector2 asteroidPos = new Vector2(-200, -200);
        public Vector2 asteroidDir;
        public float asteroidSpeed = 1.5f;
        protected Texture2D asteroidTexture;
        public bool visible = true;
        public Rectangle asteroidHitbox;

        public void setVisible(bool b)
        {
            this.visible = b;
        }

        public void LoadContent(ContentManager theContentManager)
        {
            asteroidTexture = theContentManager.Load<Texture2D>("asteroid");
        }
        public void spawn(Vector2 startPosition, Vector2 direction)
        {
            asteroidPos = startPosition;
            asteroidDir = direction;

        }

        public void delete()
        {
            asteroidPos = new Vector2(-100, -100);
        }

        public void Update(GameTime theGameTime)
        {
            asteroidHitbox = new Rectangle((int)asteroidPos.X, (int)asteroidPos.Y, 21, 20);


            if (visible)
            {
                var bulletDelta = Vector2.Zero;
                asteroidPos += asteroidSpeed * asteroidDir;
            }
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            if (visible)
                theSpriteBatch.Draw(asteroidTexture, asteroidPos, Color.White);
        }
    }
}
