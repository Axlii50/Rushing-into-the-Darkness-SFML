using Rushing_into_the_darkness_SFML.Classes.Menegers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushing_into_the_darkness_SFML.Classes
{
    class Player : IEntity
    {
        public float Speed { get; private set; } = 0.7f;
        public Sprite EntitySprite { get; private set; } = new Sprite(new Texture("Resources/Player.bmp"));
        public CollidersTags collider { get; private set; } = CollidersTags.Collider;

        public Player()
        {
            EntitySprite.Position = new SFML.System.Vector2f(100,100);
        }


        public void Move(EntityMenager eMenager)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X - Speed, EntitySprite.Position.Y);
                CollisionOccure(eMenager, Keyboard.Key.A);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X + Speed, EntitySprite.Position.Y);
                CollisionOccure(eMenager, Keyboard.Key.D);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y - Speed);
                CollisionOccure(eMenager, Keyboard.Key.W);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y + Speed);
                CollisionOccure(eMenager, Keyboard.Key.S);
            }
        }

        private void CollisionOccure(EntityMenager eMenager, Keyboard.Key lastkey)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();

            // loop through each block we need to check for collisions with
            foreach (var block in eMenager.EntitiesSpritesCollision)
            {
                // get the block bounds
                var blockbounds = block.GetGlobalBounds();

                // this will have the overlap value from the Intersects(...) result
                FloatRect overlap;

                // check if the player bounds interset with the block bounds
                if (playerbounds.Intersects(blockbounds, out overlap))
                {
                    // if the bounds intersect the overlap variable will have the
                    // length of overlap

                    // now find the direction we were moving and move us backwards
                    // equal to the overlap

                    if (lastkey == Keyboard.Key.A)
                        EntitySprite.Position += new Vector2f(overlap.Width, 0);
                    else if (lastkey == Keyboard.Key.D)
                        EntitySprite.Position += new Vector2f(-overlap.Width, 0);
                    else if (lastkey == Keyboard.Key.W)
                        EntitySprite.Position += new Vector2f(0, overlap.Height);
                    else if (lastkey == Keyboard.Key.S)
                        EntitySprite.Position += new Vector2f(0, -overlap.Height);
                }
            }
        }

        public Vector2f GetCords()
        {
            return EntitySprite.Position;
        }

        public float getCordsX()
        {
            return EntitySprite.Position.X;
        }

        public float GetCrodsY()
        {
            return EntitySprite.Position.Y;
        }
    }
}
