using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rushing_into_the_darkness_SFML.Classes.Menegers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Rushing_into_the_darkness_SFML.Classes.Entitis
{
    class Enemy : IEntity
    {
        public float Speed { get; set; } = 0.5f;

        public Sprite EntitySprite { get; set; } = new Sprite(new Texture("Resources/slime_idle_anim_f0.png"));

        public CollidersTags collider => CollidersTags.Collider;


        public Enemy()
        {
            Random r = new Random();
            EntitySprite.Position = new Vector2f(40, 40);
        }


        public void MoveEntity(EntityMenager eMenager)
        {
            //way
            int ver = eMenager._Player.EntitySprite.Position.X < EntitySprite.Position.X ? 3 : 1;
            int hor = eMenager._Player.EntitySprite.Position.Y < EntitySprite.Position.Y ? 4 : 2;

            float distance = Functions.CalculateDistance(EntitySprite.Position.X, EntitySprite.Position.Y, eMenager._Player.EntitySprite.Position.X, eMenager._Player.EntitySprite.Position.Y);
            if (!(distance < 100))
                return;

            //deleting necessery movements 
            if (this.EntitySprite.Position.X == eMenager._Player.EntitySprite.Position.X)
                ver = 0;
            if (this.EntitySprite.Position.Y == eMenager._Player.EntitySprite.Position.Y - this.EntitySprite.TextureRect.Height
                || this.EntitySprite.Position.Y == eMenager._Player.EntitySprite.Position.Y + this.EntitySprite.TextureRect.Height
                || this.EntitySprite.Position.Y == eMenager._Player.EntitySprite.Position.Y)
                hor = 0;

            if (ver == 3)//left
            {
                if (Collision_l(eMenager))
                    EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X - Speed, EntitySprite.Position.Y);
            }
            else if (ver == 1)//right
            {
                if (Collision_r(eMenager))
                    EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X + Speed, EntitySprite.Position.Y);
            }
            if (hor == 4)//up
            {
                EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y - Speed);
                CollisionOccureWay(eMenager, hor);
            }
            else if (hor == 2)//down
            {
                EntitySprite.Position = new SFML.System.Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y + Speed);
                CollisionOccureWay(eMenager, hor);
            }
        }

        public bool Collision_r(EntityMenager eMenager)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();
            playerbounds.Left += Speed;
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
            list.Add(this.EntitySprite);
            var _blockbounds = eMenager._Player.EntitySprite.GetGlobalBounds();
            FloatRect overlap;
            if (playerbounds.Intersects(_blockbounds, out overlap))
            {
                return false;
            }
            return true;
        }

        #region Collision
        public bool Collision_l(EntityMenager eMenager)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();
            playerbounds.Left -= Speed;
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
            list.Add(this.EntitySprite);
            var _blockbounds = eMenager._Player.EntitySprite.GetGlobalBounds();
            FloatRect overlap;
            if (playerbounds.Intersects(_blockbounds, out overlap))
            {
                return false;
            }
            return true;
        }
        public void CollisionOccureWay(EntityMenager eMenager, int way)
        {
            var playerbounds = EntitySprite.GetGlobalBounds();
            var list = eMenager.EntitiesSpritesCollision;

            list.Remove(this.EntitySprite);
            foreach (var block in list)
            {
                var blockbounds = block.GetGlobalBounds();
                FloatRect _overlap;

                if (playerbounds.Intersects(blockbounds, out _overlap))
                {
                    if (way == 4)
                        this.EntitySprite.Position = new Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y + _overlap.Height);
                    else if (way == 2)
                        this.EntitySprite.Position = new Vector2f(EntitySprite.Position.X, EntitySprite.Position.Y - _overlap.Height);
                }
            }
            list.Add(this.EntitySprite);
        } 
        #endregion
        public void CollisionOccureKey(EntityMenager eMenager, Keyboard.Key lastkey)
        {
            throw new NotImplementedException();
        }

        public Vector2f GetCords()
        {
            throw new NotImplementedException();
        }
    }
}
//bugi z kolzija
