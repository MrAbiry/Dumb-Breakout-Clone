using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Breakout
{
    class Ball : Sprite
    {
        Random r = new Random();

        public Ball(Texture2D texture, Vector2 position, Vector2 speed, int collisionOffset) : base(texture, position, speed, collisionOffset){ }

        public Vector2 getVelocity()
        {
            return speed;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {

            if (position.X < 0)
            {
                speed.X = -speed.X;
            }
            if (position.Y < 0)
            {
                speed.Y = -speed.Y;
            }
            if (position.X > clientBounds.Width - texture.Width)
            {
                speed.X = -speed.X;
            }

            position += getVelocity();

            base.Update(gameTime, clientBounds);
        }

        public void bounceX()
        {
            speed.X = -speed.X;
            if (speed.X > 0)
            {
                speed.X = r.Next(1, 3);
            }
            if (speed.X < 0)
            {
                speed.X = r.Next(-3, -1);
            }
        }

        public void bounceY()
        {
            speed.Y = -speed.Y;
            if (speed.X > 0)
            {
                speed.X = r.Next(1, 3);
            }
            if (speed.X < 0)
            {
                speed.X = r.Next(-3, -1);
            }
        }
    }
}
