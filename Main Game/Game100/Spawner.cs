using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Game100
{
    class Spawner
    {
        int spawnTimer = 0;
        const int TIME_TO_WAIT = 90;
        List<Asteroid> Asteroids = new List<Asteroid>();
        Random random = new Random();
        public void LoadContent(ContentManager theContentManager)
        {
            foreach (Asteroid asteroid in Asteroids)
            {
                if (asteroid.visible)
                    asteroid.LoadContent(theContentManager);
            }
        }
        public void spawn(int objectChoice)
        {
            switch (objectChoice)
            {
                case 1:
                    Asteroid asteroid = new Asteroid();
                    asteroid.spawn(new Vector2(random.Next(20, 680), 0), Vector2.UnitY);
                    Asteroids.Add(asteroid);
                    break;
            }

        }
        public void Update(GameTime theGameTime)
        {
            if (spawnTimer >= TIME_TO_WAIT)
            {
                spawn(1);
                spawnTimer = 0;
            }
            foreach (Asteroid asteroid in Asteroids)
            {
                asteroid.Update(theGameTime);
            }
            spawnTimer++;
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            foreach (Asteroid asteroid in Asteroids)
            {
                if (asteroid.visible)
                    asteroid.Draw(theSpriteBatch);
            }
        }
    }
}
