using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;



namespace MonoGame_Framework
{
    public class Game1 : Core
    {
        //private GraphicsDeviceManager _graphics;
        //private SpriteBatch _spriteBatch;

        public Game1() : base()
        {
            /*
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            */
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            var scene = Scene.CreateWithDefaultRenderer(Color.BurlyWood);

            var Player = scene.Content.Load<Texture2D>("Player");
            //var scene = Scene.Create(Color.BurlyWood);
            var entity = scene.CreateEntity("First-Sprite");
            var sprite = new Sprite(Player, new Rectangle(50, 50, Player.Width, Player.Height));
            entity.AddComponent<Sprite>(new Sprite(Player));
            Scene = scene;
        }
    }
}
