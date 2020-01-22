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
        public float Speed { get; private set; } = 1f;
        public Sprite EntitySprite { get; private set; } = new Sprite(new Texture("Resources/knight_idle_anim_f0.png"));
        public CollidersTags collider { get; private set; } = CollidersTags.Collider;
        public Camera _camera;
        public View ViewPoint;
        /// <summary>
        /// Default x = 100 y = 100
        /// </summary>
        public Player(Camera camera, View Viewpoint)
        {
            this.ViewPoint = Viewpoint;
            _camera = camera;
            _camera.Move(this);
            EntitySprite.Position = new SFML.System.Vector2f(100,100);
            ViewPoint.Center = new SFML.System.Vector2f(EntitySprite.Position.X - Speed, EntitySprite.Position.Y);
        }

        public void MoveEntity(EntityMenager eMenager)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                if (Collision_l(eMenager))
                {
                    EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X - Speed, EntitySprite.Position.Y);
                    CollisionOccureKey(eMenager, Keyboard.Key.A);
                    _camera.Move(this);
                    ViewPoint.Move(new Vector2f(-Speed, 0));
                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                if (Collision_r(eMenager))
                {
                    EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X + Speed, EntitySprite.Position.Y);
                    CollisionOccureKey(eMenager, Keyboard.Key.D);
                    _camera.Move(this);
                    ViewPoint.Move(new Vector2f(Speed, 0));
                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                if (Collision_u(eMenager))
                {
                    EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y - Speed);
                    CollisionOccureKey(eMenager, Keyboard.Key.W);
                    _camera.Move(this);
                    ViewPoint.Move(new Vector2f(0, -Speed));
                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                if (Collision_d(eMenager))
                {
                    EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y + Speed);
                    CollisionOccureKey(eMenager, Keyboard.Key.S);
                    _camera.Move(this);
                    ViewPoint.Move(new Vector2f(0, Speed));
                }
            }
            ViewPoint.Center = new Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y);
        }

        public void CollisionOccureKey(EntityMenager eMenager, Keyboard.Key lastkey)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();

            foreach (var block in eMenager.EntitiesSpritesCollision)
            {
                var blockbounds = block.GetGlobalBounds();
                FloatRect overlap;

                if (playerbounds.Intersects(blockbounds, out overlap))
                {
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
        #region Collision_fur
        private bool Collision_r(EntityMenager eMenager)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();
            playerbounds.Left += Speed;
            var list = eMenager.EntitiesSpritesCollision;
            foreach (var block in list)
            {
                var blockbounds = block.GetGlobalBounds();
                FloatRect _overlap;

                if (playerbounds.Intersects(blockbounds, out _overlap))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Collision_l(EntityMenager eMenager)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();
            playerbounds.Left -= Speed;
            var list = eMenager.EntitiesSpritesCollision;
            foreach (var block in list)
            {
                var blockbounds = block.GetGlobalBounds();
                FloatRect _overlap;

                if (playerbounds.Intersects(blockbounds, out _overlap))
                {
                    return false;
                }
            }

            return true;
        }
        private bool Collision_u(EntityMenager eMenager)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();
            playerbounds.Top -= Speed;
            var list = eMenager.EntitiesSpritesCollision;
            list.Remove(this.EntitySprite);
            foreach (var block in list)
            {
                var blockbounds = block.GetGlobalBounds();
                FloatRect _overlap;

                if (playerbounds.Intersects(blockbounds, out _overlap))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Collision_d(EntityMenager eMenager)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();
            playerbounds.Top += Speed;
            var list = eMenager.EntitiesSpritesCollision;
            list.Remove(this.EntitySprite);
            foreach (var block in list)
            {
                var blockbounds = block.GetGlobalBounds();
                FloatRect _overlap;

                if (playerbounds.Intersects(blockbounds, out _overlap))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region NotImplemented
        public Vector2f GetCords()
        {
            return EntitySprite.Position;
        }

        

        public void CollisionOccureWay(EntityMenager eMenager, int way)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
