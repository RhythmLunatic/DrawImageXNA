using System;
//using System.Collections.Generic;
//using System.Linq;
using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;
using WinForms = System.Windows.Forms;
using System.IO;

namespace XNADrawImage
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public int gameWidth;
        public int gameHeight;
        Texture2D image;
        string path;

        public Game1(string[] args)
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
#if DEBUG
            gameWidth = 1920;
            gameHeight = 1080;
#else
            gameWidth = int.Parse(args[0]);
            gameHeight = int.Parse(args[1]);
#endif
            path = args[2];
            graphics.PreferredBackBufferWidth = gameWidth;
            graphics.PreferredBackBufferHeight = gameHeight;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IntPtr hWnd = this.Window.Handle;
            var control = WinForms.Control.FromHandle(hWnd);
            var form = control.FindForm();
            form.FormBorderStyle = WinForms.FormBorderStyle.None;
            form.Location = new System.Drawing.Point(0, 0);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //image = Content.Load<Texture2D>("background");
            image = Texture2D.FromStream(graphics.GraphicsDevice, File.OpenRead(path));
        }

        protected override void Update(GameTime gameTime)
        {

        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(image, new Rectangle(0, 0, gameWidth, gameHeight), Color.White);
            spriteBatch.End();
            //base.Draw(gameTime);
        }
    }
}
