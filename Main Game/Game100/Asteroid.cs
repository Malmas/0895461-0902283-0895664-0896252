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
        public float asteroidSpeed = 6.0f;
        protected Texture2D asteroidTexture;
        public bool visible = false;
        public void LoadContent(ContentManager theContentManager)
        {
            asteroidTexture = theContentManager.Load<Texture2D>("laser");
        }
        public void spawn(Vector2 startPosition, Vector2 direction)
        {
            asteroidPos = startPosition;
            asteroidDir = direction;

        }
        public void Update(GameTime theGameTime)
        {
            if (asteroidPos.Y < -30)
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
                asteroidPos += asteroidSpeed * asteroidDir;
            }
            else
            {

            }
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            if (visible)
                theSpriteBatch.Draw(asteroidTexture, asteroidPos, Color.White);
        }
    }
}
