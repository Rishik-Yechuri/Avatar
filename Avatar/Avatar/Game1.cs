using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Avatar
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D avatar1;
        Texture2D avatar2;
        Texture2D avatar3;
        Texture2D avatar4;
        Texture2D avatar5;
        List<Texture2D> picFrames = new List<Texture2D>();

        Rectangle avatar1Rect;
        Rectangle avatar2Rect;
        Rectangle avatar3Rect;
        Rectangle avatar4Rect;
        Rectangle avatar5Rect;

        Rectangle bigRectangle;
        List<Rectangle> rect = new List<Rectangle>();

        Texture2D redBox;
        Rectangle selectionBox;

        int xPos;
        int yPos;

        int selectLocation;
        bool nextSelection;
        bool selectThing = false;

        GamePadState padOld; 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            padOld = GamePad.GetState(PlayerIndex.One);
            xPos = 10;
            yPos = 10;

            selectionBox = new Rectangle(xPos, yPos, 120, 120);
            avatar1Rect = new Rectangle(20, 20, 100, 100);
            avatar2Rect = new Rectangle(185, 20, 100, 100);
            avatar3Rect = new Rectangle(350, 20, 100, 100);
            avatar4Rect = new Rectangle(515, 20, 100, 100);
            avatar5Rect = new Rectangle(680, 20, 100, 100);

            rect.Add(selectionBox);
            rect.Add(avatar1Rect);
            rect.Add(avatar2Rect);
            rect.Add(avatar3Rect);
            rect.Add(avatar4Rect);
            rect.Add(avatar5Rect);

            bigRectangle = new Rectangle(250, 100, 300, 300);
            selectLocation = 1;
            nextSelection = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            redBox = Content.Load<Texture2D>("Red box");
            avatar1 = Content.Load<Texture2D>("clown");
            avatar2 = Content.Load<Texture2D>("cop");
            avatar3 = Content.Load<Texture2D>("glasses");
            avatar4 = Content.Load<Texture2D>("nurse");
            avatar5 = Content.Load<Texture2D>("tennis guy");

            picFrames.Add(redBox);
            picFrames.Add(avatar1);
            picFrames.Add(avatar2);
            picFrames.Add(avatar3);
            picFrames.Add(avatar4);
            picFrames.Add(avatar5);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);


            if (selectLocation == 1)
            {
                selectionBox = new Rectangle(xPos, yPos, 120, 120);
                //avatar1Rect = new Rectangle(100, 100, 200, 200);
                nextSelection = true;
            }
            if (selectLocation == 2)
            {
                selectionBox = new Rectangle(165, 20, 120, 120);
                //avatar2Rect = new Rectangle(100, 100, 200, 200);
                nextSelection = true;
            }
            if (selectLocation == 3)
            {
                selectionBox = new Rectangle(330, 20, 120, 120);
                //avatar3Rect = new Rectangle(100, 100, 200, 200);
                nextSelection = true;
            }
            if (selectLocation == 4)
            {
                selectionBox = new Rectangle(495, 20, 120, 120);
                //avatar4Rect = new Rectangle(100, 100, 200, 200);
                nextSelection = true;
            }
            if (selectLocation == 5)
            {
                selectionBox = new Rectangle(660, 20, 120, 120);
                //avatar5Rect = new Rectangle(100, 100, 200, 200);
                nextSelection = true;
            }

            // Allows the game to exit

            //XBOX DPad BUTTONS
            if (pad1.DPad.Right == ButtonState.Pressed && padOld.DPad.Right == ButtonState.Released) { 
                selectLocation += 1;
                if (selectLocation > 5) {
                    selectLocation = 1;
                }
            }

            if (pad1.DPad.Left == ButtonState.Pressed && padOld.DPad.Left == ButtonState.Released)
            {
                selectLocation -= 1;
            }
            if (pad1.Buttons.Start == ButtonState.Pressed) {
                selectThing = true;
            }
            if (pad1.Buttons.Back == ButtonState.Pressed) {
                selectThing = false;
            }
            // TODO: Add your update logic here
            //drawBorder(rect[])
            padOld = pad1;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (selectThing)
            {
                spriteBatch.Draw(picFrames.ElementAt(selectLocation),bigRectangle,Color.White);
            }
            else
            {
                spriteBatch.Draw(redBox, selectionBox, Color.White);
                spriteBatch.Draw(avatar1, avatar1Rect, Color.White);
                spriteBatch.Draw(avatar2, avatar2Rect, Color.White);
                spriteBatch.Draw(avatar3, avatar3Rect, Color.White);
                spriteBatch.Draw(avatar4, avatar4Rect, Color.White);
                spriteBatch.Draw(avatar5, avatar5Rect, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        //private void drawBorder(Rectangle r, Color c)
        //{
        //    Texture2D rect = new Texture2D(graphics.GraphicsDevice, r.Width + 20, r.Height + 20);

        //    Color[] data = new Color[rect.Width * rect.Height];
        //    for (int i = 0; i < data.Length; ++i) data[i] = c;
        //    rect.SetData(data);

        //    Vector2 coor = new Vector2(r.X - 10, r.Y - 10);
        //    spriteBatch.Draw(rect, coor, Color.Red);
        //}
    }
}
