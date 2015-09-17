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
        float spawnTimer = 0.0f;
        const float TIME_TO_WAIT = 3.0f;
        List<Asteroid> Asteroids = new List<Asteroid>();
        Random random = new Random();
        public void spawn(int objectChoice)
        {
            switch(objectChoice)
            {
                case 1:
                Asteroid asteroid = new Asteroid();
                Asteroids.Add(asteroid);
                asteroid.spawn((new Vector2(random.Next(20,380),-20)),Vector2.UnitY);
                break;
            }
            
        }
        public void Update(GameTime theGameTime)
        {
            spawnTimer += (float)(theGameTime.ElapsedGameTime.TotalSeconds);
            if (spawnTimer == TIME_TO_WAIT)
                spawn(1);
            foreach (Asteroid asteroid in Asteroids)
            {
                asteroid.Update(theGameTime);
            }
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
