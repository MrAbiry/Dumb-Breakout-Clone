using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout
{
    class Paddle : Sprite
    {
        public Paddle(Texture2D texture, Vector2 position, Vector2 speed, int collisionOffset) : base (texture, position, speed, collisionOffset) { }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {

            position += getVelocity();

            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.X > clientBounds.Width - texture.Width)
            {
                position.X = clientBounds.Width - texture.Width;
            }

            base.Update(gameTime, clientBounds);
        }

        public Vector2 getVelocity()
        {
            Vector2 velocity = Vector2.Zero;

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                velocity.X -= speed.X;
            }
            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                velocity.X += speed.X;
            }
            return velocity;
        }
    }
}
