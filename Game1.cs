using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Security;
using Nez.AI.UtilityAI;


namespace MonoGame_Framework
{
    public class Game1 : Core
    {
        //private GraphicsDeviceManager _graphics;
        //private SpriteBatch _spriteBatch;

        public Game1() : base()
        {
            //_graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            // Making a new scene with default renderer for background
            Scene scene = Scene.CreateWithDefaultRenderer(Color.Red);
            scene.ClearColor = Color.Red;

            // Create player entity
            Entity player = new Entity();
            player = scene.AddEntity(player);
            //player = scene.CreateEntity("Player");

            // Loads player texture 
            Texture2D playerTexture = scene.Content.Load<Texture2D>("Player");

            // Adding a new sprite renderer component and adding my player texture
            player.AddComponent(new SpriteRenderer(playerTexture));


            // Adds player movement component to player
            player.AddComponent(new PlayerMovement());

            // This gets the player movement component in _player, no need for this just wanna try it
            PlayerMovement _player = player.GetComponent<PlayerMovement>();

            // Setting core Scene to my new scene that I made
            Scene = scene;
        }

        // Player Movement Component
        public class PlayerMovement : Component, IUpdatable
        {
            private int speed = 100;
            Entity player;

            SpriteRenderer spriteRenderer;
            // This is basically start method
            public override void OnAddedToEntity()
            {
                Transform.Position = new Vector2 (50, 50);
                Transform.Scale = new Vector2(5, 5);

                spriteRenderer = this.GetComponent<SpriteRenderer>();
                player = Transform.Entity;

                //Changing scene color 
                player.Scene.ClearColor = Color.Plum;
                Debug.Log("Test for debug");

            }
            //Component, IUpdatable lets me use the update method
            public void Update()
            {
                Vector2 move = Vector2.Zero;
                if (Input.IsKeyPressed(Keys.W))
                {
                    move.Y -= 100;
                    spriteRenderer.Color = Color.Plum;
                }
                if (Input.IsKeyPressed(Keys.S))
                {
                    move.Y += 100;
                    spriteRenderer.Color = Color.Gold;
                }
                if (Input.IsKeyPressed(Keys.A))
                {
                    move.X -= 100;
                    spriteRenderer.Color = Color.RoyalBlue;
                }
                if (Input.IsKeyPressed(Keys.D))
                {
                    move.X += 100;
                    spriteRenderer.Color = Color.Tomato;
                }
                if (Input.IsKeyDown(Keys.LeftShift))
                {
                    speed = 200;
                }
                else
                {
                    speed = 100;
                }
                // This gives a more player snap
                player.TweenLocalPositionTo(Transform.Position += move, 0.2f);

                // This moves the player like normal
                // Transform.Position += move * speed * Time.DeltaTime;
            }
        }
    }
}
