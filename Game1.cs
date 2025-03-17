using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;



namespace MonoGame_Framework
{
    public class Game1 : Core
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //SpriteBatch
            /*
            base.Initialize();
            var scene = Scene.CreateWithDefaultRenderer(Color.BurlyWood);
            
            var Player = scene.Content.Load<Texture2D>("Player");
            //var scene = Scene.Create(Color.BurlyWood);
            //var entity = scene.CreateEntity("First-Sprite");
            //Entity player = scene.AddEntity(entity);
            var player = new Entity();
            
            scene.AddEntity(player);

            //Component _player = player.AddComponent<Component>();
            
            var sprite = new Sprite(Player, new Rectangle(50, 50, Player.Width, Player.Height));
            //Console.Write($"{entity.Components}");
            //Debug.DrawText($"{entity.Components}");
            var boom = player.AddComponent<Component>();
            //boom.Entity.Transform.
            //entity.Components
            //player
            scene.Begin();
            Scene = scene;

            scene.Begin();
            scene.Initialize();
            scene.Update();

            scene.End();
            */
        }
        public class Actor
        {
            public Entity entity;
            public bool isTurn;
            public bool WaitForTurn;
            public bool WaitAnimation;
            double animation;

            public virtual void StartTurn()
            {
                //change color 
                //entity.GetComponent<>
                isTurn = true;
                WaitForTurn = false;
            }

            public virtual void EndTurn()
            {
                isTurn = false;
                WaitForTurn = true;
            }

            public virtual void UpdateTurn(GameTime gameTime)
            {
                if (WaitForTurn)
                {
                    animation += gameTime.TotalGameTime.TotalSeconds;
                    if (animation < 15f)
                    {

                    }
                    else
                    {
                        isTurn = true;
                    }
                }
                
                
                

            }

            public virtual void Move(GameTime gameTime, Vector2 changeVector)
            {
                animation = gameTime.TotalGameTime.TotalSeconds;
                Vector2 MoveVector = new Vector2(entity.Position.X + changeVector.X, entity.Position.Y + changeVector.Y);
                entity.TweenPositionTo(MoveVector, (float)animation).Start();//SetCompletionHandler();
                
                WaitAnimation = true;

            }

        }
        public class turnManager
        {
            List<Actor> entities = new List<Actor>();

            public int order = 0;

            public void updateturn()
            {
                if (order < entities.Count && order >= entities.Count)
                {
                    var ActorTurn = entities[order];
                    if (ActorTurn.isTurn)
                    {
                        ActorTurn.StartTurn();
                    }
                    else
                    {
                        ActorTurn.EndTurn();
                    }
                    order++;
                }
                else
                {
                    order = 0;
                    var actor = entities[order];
                }
            }



        }
    }
}
