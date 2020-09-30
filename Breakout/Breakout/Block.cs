using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    class Block : Sprite
    {
        Color color;
        public bool isDead;

        public Block(Texture2D texture, Vector2 position, Color color) : base(texture, position, Vector2.Zero, 0) 
        { 
            this.color = color;
            isDead = false;
        }
    }
}
