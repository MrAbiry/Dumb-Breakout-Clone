using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    abstract class Sprite
    {
        protected Texture2D texture;
        protected Vector2 speed;
        protected Vector2 position;
        int collisionOffset;
        public Rectangle getCollisionRect() => new Rectangle((int)position.X + collisionOffset, (int)position.Y + collisionOffset, texture.Width - collisionOffset * 2, texture.Height - collisionOffset * 2);
        public Rectangle getRect() => new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        public Vector2 getPos() => position;

        public Sprite(Texture2D texture, Vector2 position, Vector2 speed, int collisionOffset)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.collisionOffset = collisionOffset;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
