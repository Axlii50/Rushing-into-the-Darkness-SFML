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
    class TestEntity : IEntity
    {
        public float Speed { get; private set; } = 0;

        public Sprite EntitySprite { get; private set; } = new Sprite(new Texture("Resources/Enemy texture.png"));

        public CollidersTags collider { get; private set; } = CollidersTags.Collider;

        public TestEntity()
        {
            Random r = new Random();

            EntitySprite.Position = new Vector2f(r.Next(1, 800), r.Next(1, 600));
        }
        public Vector2f GetCords()
        {
            throw new NotImplementedException();
        }

        public float getCordsX()
        {
            throw new NotImplementedException();
        }

        public float GetCrodsY()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Move(EntityMenager eMenager)
        {
            throw new NotImplementedException();
        }

        public void CollisionOccure(EntityMenager eMenager, ref bool left, ref bool right, ref bool up, ref bool down)
        {
            throw new NotImplementedException();
        }

        public void MoveEntity(EntityMenager eMenager)
        {
            throw new NotImplementedException();
        }

        public void CollisionOccure(EntityMenager eMenager, Keyboard.Key lastkey)
        {
            throw new NotImplementedException();
        }
    }
}
