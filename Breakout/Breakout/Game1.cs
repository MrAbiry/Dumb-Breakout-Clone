using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Breakout
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Ball ball;

        int blockCol = 6;
        int blockRow = 6;

        List<List<Block>> blocks = new List<List<Block>>();

        Paddle player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 135;  
            _graphics.PreferredBackBufferHeight = 200; 
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = new Ball(Content.Load<Texture2D>("Images/ballsmall"), new Vector2(100, 100), new Vector2(-1, -2), 0);
            player = new Paddle(Content.Load<Texture2D>("Images/paddle"), new Vector2((Window.ClientBounds.Width / 2 - 8), 160), new Vector2(3, 3), 0);
            for (int i = 0; i < blockCol; i++)
            {
                blocks.Add(new List<Block>());
                for (int j = 0; j < blockRow; j++)
                {
                    blocks[i].Add(new Block(Content.Load<Texture2D>("Images/block"), new Vector2((20 * i) + 10, (10 * j) + 5), Color.White ));
                }
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ball.Update(gameTime, Window.ClientBounds);
            foreach (List<Block> col in blocks)
            {
                foreach (Block block in col)
                {
                    if (!block.isDead)
                    {
                        if (ball.getCollisionRect().Intersects(block.getCollisionRect()))
                        {
                            if ((ball.getRect().Width + ball.getPos().X) > block.getPos().X && ball.getPos().X < (block.getRect().Width + block.getPos().X))
                            {
                                ball.bounceY();
                            }
                            if ((ball.getRect().Height + ball.getPos().Y) > block.getPos().Y && ball.getPos().Y < (block.getRect().Height + block.getPos().Y))
                            {
                                ball.bounceX();
                            }
                            block.isDead = true;
                        }
                    }
                }
            }

            if (ball.getCollisionRect().Intersects(player.getCollisionRect()))
            {
                ball.bounceY();
                //if ((ball.getRect().Width + ball.getPos().X) > player.getPos().X && ball.getPos().X < (player.getRect().Width + player.getPos().X))
                //{
                //    ball.bounceY();
                //}
                //if ((ball.getRect().Height + ball.getPos().Y) > player.getPos().Y && ball.getPos().Y < (player.getRect().Height + player.getPos().Y))
                //{
                //    ball.bounceX();
                //}
            }

            player.Update(gameTime, Window.ClientBounds);

            if (ball.getPos().Y > 200)
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            ball.Draw(gameTime, _spriteBatch);

            foreach (List<Block> col in blocks)
            {
                foreach (Block block in col)
                {
                    if (!block.isDead)
                    {
                        block.Draw(gameTime, _spriteBatch);
                    }
                }
            }

            player.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
